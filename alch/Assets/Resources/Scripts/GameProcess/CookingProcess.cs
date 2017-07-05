using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProcess : MonoBehaviour
{
    public Camera camera;

    public GameObject gridSequence;
    public GameObject ConteinerIngr;
    public GameObject nextIngrView;

    public GameObject ExitButton;

    public GameObject RecipesButton;

    public GameObject SliderR;
    public GameObject SliderG;
    public GameObject SliderB;
    // public GameObject RImage;
    // public GameObject GImage;
    // public GameObject BImage;


    public static Recipe recipe;
    public static int currentIngr;

    public int currenSlider = -1;
    //public Text timerByStady;
    // public Text progressView;



    bool readyToAddIngr;
    bool readyToStady;


    public static int R;
    public static int G;
    public static int B;


    public float progressIngr;
    //float timeByRefine = 30f;

    public static int currentRecipeIngr = -1;


    public float currentChangeVall = 0.02f; //временная переменная для изменениея значения по клику 


    public static int recipeHard = 0; // сложность рецепта влияет на количество слайдеров

    void Start()
    {
        readyToAddIngr = true;
        currentRecipeIngr = -1;
    }


    // Update is called once per frame
    void Update()
    {

        if (currentRecipeIngr != -1 && nextIngrView.transform.GetChild(1).name != recipe.MassIngr[currentRecipeIngr].ToString())
        {
            nextIngrView.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(recipe.MassIngr[currentRecipeIngr]));
            nextIngrView.transform.GetChild(1).name = recipe.MassIngr[currentRecipeIngr].ToString();
            ResetAllSlider();
        }

        if (readyToStady)
        {

            if (ChekGreenZoneAllSlider())
            {
                if (progressIngr <= 0)
                {
                    readyToStady = false;
                    readyToAddIngr = true;
                    if (currentRecipeIngr != recipe.MassIngr.Length - 1)
                    {
                        currentRecipeIngr = currentRecipeIngr + 1;
                        nextIngrView.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(recipe.MassIngr[currentRecipeIngr]));
                        progressIngr = 0;
                    }
                    else
                    {
                        EndCooking();
                    }
                }
                else
                {
                    nextIngrView.transform.GetChild(0).GetComponent<Image>().fillAmount += 1.0f / (R + G + B) * Time.deltaTime;
                    progressIngr -= Time.deltaTime;
                }

            }

            // if (timeByRefine > 0)
            // {
            // DirectionSircl();
            //timeByRefine -= Time.deltaTime;
            // timerByStady.text = timeByRefine.ToString("0.0");

            // RImage.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = R.ToString();
            // GImage.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = G.ToString();
            //  BImage.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = B.ToString();
            //}
            //else
            //{
            //    readyToStady = false;
            //    readyToAddIngr = true;
            // timerByStady.text = "";
            //}


            //if (R == 0 && G == 0 && B == 0)
            //{
            //    readyToStady = false;
            //    readyToAddIngr = true;
            //    if (currentRecipeIngr != recipe.MassIngr.Length - 1)
            //    {

            //        currentRecipeIngr = currentRecipeIngr+1;
            //        nextIngrView.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(recipe.MassIngr[currentRecipeIngr]));
            //        Debug.Log(recipe.MassIngr[currentRecipeIngr] + " " + currentRecipeIngr);
            //    }
            //    else
            //    {
            //        EndCooking();
            //    }
            //}


        }
    }

    public void EndCooking()
    {
        ResetAllSlider();
        gridSequence.SetActive(false);
        ExitButton.SetActive(false);
        RecipesButton.SetActive(true);
        currentRecipeIngr = -1;
        readyToAddIngr = true;
        currentIngr = -1;
        recipe = null;

        //progressView.transform.gameObject.SetActive(false);

        //R = -1;
    }

    public void DirectionSircl() { }



    //добавление ингредиента для обработки 
    public void AddIngredientToKattle()
    {
        if (readyToAddIngr && currentIngr != -1)
        {
            ListIngredient.ingredients[currentIngr].GetRGBIngr(out R, out G, out B);
            progressIngr = R + G + B;
            readyToAddIngr = false;
            readyToStady = true;

            InitAllSlider();
        }
    }


    //инициализация процесса готовки.
    public void LoadIngrInSequence()
    {
        //удаление дочерних єлементов из очереди.
        if (gridSequence.transform.childCount > 0)
            for (int i = 0; i < gridSequence.transform.childCount; i++)
                Destroy(gridSequence.transform.GetChild(i).gameObject);

        //активация очереди ингредиентов
        gridSequence.SetActive(true);
        gridSequence.GetComponent<GeneratorIngrSeq>().Repeat();//метод повторения спавна ингредиентов

    }



    public bool ChekGreenZoneAllSlider()
    {
        switch (recipeHard)
        {
            case 0:
                return SliderR.GetComponent<CookingSlider>().RInGreenZone();
                break;
            case 1:
                return SliderR.GetComponent<CookingSlider>().RInGreenZone() & SliderG.GetComponent<CookingSlider>().RInGreenZone();
                break;
            case 2:
                return SliderR.GetComponent<CookingSlider>().RInGreenZone() & SliderG.GetComponent<CookingSlider>().RInGreenZone() & SliderB.GetComponent<CookingSlider>().RInGreenZone();
                break;
        }
        return false;
    }



    public void ResetAllSlider()
    {
        switch (recipeHard)
        {
            case 0:
                SliderR.GetComponent<CookingSlider>().ResetSlider();
                break;
            case 1:
                SliderR.GetComponent<CookingSlider>().ResetSlider();
                SliderG.GetComponent<CookingSlider>().ResetSlider();
                break;
            case 2:
                SliderR.GetComponent<CookingSlider>().ResetSlider();
                SliderG.GetComponent<CookingSlider>().ResetSlider();
                SliderB.GetComponent<CookingSlider>().ResetSlider();
                break;
        }
        nextIngrView.transform.GetChild(0).GetComponent<Image>().fillAmount = 0;
    }



    public void InitAllSlider()
    {

        Debug.Log(recipeHard);
        switch (recipeHard)
        {
            case 0:
                SliderR.GetComponent<CookingSlider>().pause = true;
                break;
            case 1:
                SliderR.GetComponent<CookingSlider>().pause = true;
                SliderG.GetComponent<CookingSlider>().pause = true;
                break;
            case 2:
                SliderR.GetComponent<CookingSlider>().pause = true;
                SliderG.GetComponent<CookingSlider>().pause = true;
                SliderB.GetComponent<CookingSlider>().pause = true;
                break;
        }
    }

    public void UpButtonCook(int x)
    {
        switch (x)
        {
            case 0:
                SliderR.GetComponent<CookingSlider>().ChangeVariableVal(currentChangeVall);
                break;
            case 1:
                SliderG.GetComponent<CookingSlider>().ChangeVariableVal(currentChangeVall);
                break;
            case 2:
                SliderB.GetComponent<CookingSlider>().ChangeVariableVal(currentChangeVall);
                break;
        }
    }
    public void DownButtonCook(int x)
    {
        switch (x)
        {
            case 0:
                SliderR.GetComponent<CookingSlider>().ChangeVariableVal(-currentChangeVall);
                break;
            case 1:
                SliderG.GetComponent<CookingSlider>().ChangeVariableVal(-currentChangeVall);
                break;
            case 2:
                SliderB.GetComponent<CookingSlider>().ChangeVariableVal(-currentChangeVall);
                break;
        }
    }

    //alternativ cooking
    //------------------------------------------------
    public void UpButtonCook()
    {
        switch (currenSlider)
        {
            case 0:
                SliderR.GetComponent<CookingSlider>().ChangeVariableVal(currentChangeVall);
                break;
            case 1:
                SliderG.GetComponent<CookingSlider>().ChangeVariableVal(currentChangeVall);
                break;
            case 2:
                SliderB.GetComponent<CookingSlider>().ChangeVariableVal(currentChangeVall);
                break;
        }
    }
    public void DownButtonCook()
    {
        switch (currenSlider)
        {
            case 0:
                SliderR.GetComponent<CookingSlider>().ChangeVariableVal(-currentChangeVall);
                break;
            case 1:
                SliderG.GetComponent<CookingSlider>().ChangeVariableVal(-currentChangeVall);
                break;
            case 2:
                SliderB.GetComponent<CookingSlider>().ChangeVariableVal(-currentChangeVall);
                break;
        }
    }

    public void SetCurrentSliderVal(int x)
    {
        currenSlider = x;
    }
    //-------------------------------------------------

}
