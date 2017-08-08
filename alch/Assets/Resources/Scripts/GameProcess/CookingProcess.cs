using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProcess : MonoBehaviour
{
    public Camera camera;

    public GameObject gridSequence;
    //public GameObject ConteinerIngr;
    public GameObject nextIngrView;
    public GameObject spauners;

    public GameObject CookingPanelControl;
    public GameObject StartPanelControl;
    public GameObject uoDownButton;
    public GameObject pauseButton;


    //обьект котел
    public GameObject Kattle;

    //измерителььные трубки
    public GameObject CookingToubs;

    //пойнтер зоны для переключения между трубками
    public GameObject PointerZones;



    //public GameObject SliderR;
    //public GameObject SliderG;
    //public GameObject SliderB;


    //текущий рецепт
    public static Recipe recipe;


    public static int currentIngr;

    public int currenSlider = -1;

    bool readyToAddIngr;
    bool readyToStady;

    public static bool firstStady = false;
    bool secondStady;


    public static int R;
    public static int G;
    public static int B;

    public int allCounrRGB;

    public float progressIngr;
    //float timeByRefine = 30f;

    // public static int currentRecipeIngr = -1;
    // public  int currentPosRecipeIngr = -1;


    public float currentChangeVall = 0.02f; //временная переменная для изменениея значения по клику 


    public static int recipeHard = 0; // сложность рецепта влияет на количество слайдеров

    public static int lifeFirstStadyCooking;//количество жизней первой стадии готовки
    public Text lifeText;

    void Start()
    {
        readyToAddIngr = true;
        // currentRecipeIngr = -1;
    }


    // Update is called once per frame
    void Update()
    {
        //первая стадия готовки
        if (firstStady)
        {
            //если показатель жизней равен 0 заканчиваем готовку
            if (lifeFirstStadyCooking == 0)
                EndCooking();

            //если рецепт доступен и не достигнут конец рецепта
            if (recipe.RecipeStatus && !recipe.EndOfRecipe)
            {
                //устанавливаем спрайт и имя панели отображения текущего ингредиента 
                nextIngrView.transform.GetChild(1).GetComponent<Image>().sprite = recipe.GetCurrentSpriteIngr;
                nextIngrView.transform.GetChild(1).name = recipe.CurrentIngrId.ToString();
            }
        }
        //вторая стадия
        if (secondStady)
        {
            uoDownButton.gameObject.SetActive(true);
            spauners.SetActive(false);
            nextIngrView.gameObject.SetActive(false);
            Kattle.GetComponent<Animator>().SetBool("kettleUp", true);
            Debug.Log("SecondStady");
            pauseButton.transform.position = new Vector2(Screen.width - 120, Screen.height - 120);
            //InitAllSlider();


            ActivatePointerZonesByHard();
            ActivateCookingToubsByHard();
            secondStady = false;
            gridSequence.SetActive(false);
            lifeText.transform.parent.gameObject.SetActive(false);
        }

    }

    //добавление ингредиента для обработки 
    public void AddIngredientToKattle()
    {
        //если заброшенный ингредиент равен текущему ингредиенту рецепта
        if (recipe.EqualsIngr(currentIngr))
        {
            //инкрементируем ингредиент в рецепте
            recipe.NextStepIngr();

            //при достижении конца рецепта переход на следующую стадию
            if (recipe.EndOfRecipe)
            {
                firstStady = false;
                secondStady = true;
            }
        }
        //иначе уменьшаем показатель жизней
        else
        {
            lifeFirstStadyCooking--;
            lifeText.text = lifeFirstStadyCooking.ToString();
        }
    }




    public void EndCooking()
    {

        if (gridSequence.transform.childCount > 0)
            for (int i = 0; i < gridSequence.transform.childCount; i++)
                Destroy(gridSequence.transform.GetChild(i).gameObject);

        uoDownButton.gameObject.SetActive(false);
        DeactivateCookingToubsByHard();
        DeactivatePointerZonesByHard();

        spauners.SetActive(false);
        gridSequence.SetActive(false);
        CookingPanelControl.SetActive(false);
        StartPanelControl.SetActive(true);
        readyToAddIngr = true;
        currentIngr = -1;
        firstStady = false;
        recipe.RecipeStatus = false;
        allCounrRGB = 0;


        gridSequence.GetComponent<GeneratorIngrSeq>().ResetSequensParametrs();

    }



    //инициализация процесса готовки.
    public void LoadIngrInSequence()
    {
        Kattle.GetComponent<Animator>().SetBool("kettleUp", false);
        //удаление дочерних єлементов из очереди.
        if (gridSequence.transform.childCount > 0)
            for (int i = 0; i < gridSequence.transform.childCount; i++)
                Destroy(gridSequence.transform.GetChild(i).gameObject);

        //активация очереди ингредиентов
        gridSequence.SetActive(true);
        gridSequence.GetComponent<GeneratorIngrSeq>().Repeat();//метод повторения спавна ингредиентов

        nextIngrView.gameObject.SetActive(true);

        lifeFirstStadyCooking = 3;
        lifeText.text = lifeFirstStadyCooking.ToString();
        lifeText.transform.parent.gameObject.SetActive(true);

        spauners.SetActive(true);
        Spauner.DeleteAllFromList();

        pauseButton.transform.position = new Vector2(Screen.width - 120, 120 );
    }



    public void SetCurrentSliderVal(int x)
    {
        
        currenSlider = x;
        Debug.Log(currenSlider + " SetCurrentSliderVal");
    }




    //активация и инициализация трубок в зависимости от сложности рецепта 
    public void ActivateCookingToubsByHard()
    {
        // Debug.Log(recipeHard);
        switch (recipeHard)
        {
            case 0:
                CookingToubs.transform.GetChild(0).gameObject.SetActive(true);
                CookingToubs.transform.GetChild(0).transform.GetChild(0).GetComponent<CookingToub>().IninToub();
                break;
            case 1:
                CookingToubs.transform.GetChild(1).gameObject.SetActive(true);
                CookingToubs.transform.GetChild(1).transform.GetChild(0).GetComponent<CookingToub>().IninToub();
                CookingToubs.transform.GetChild(1).transform.GetChild(1).GetComponent<CookingToub>().IninToub();
                break;
            case 2:
                CookingToubs.transform.GetChild(2).gameObject.SetActive(true);
                CookingToubs.transform.GetChild(2).transform.GetChild(0).GetComponent<CookingToub>().IninToub();
                CookingToubs.transform.GetChild(2).transform.GetChild(1).GetComponent<CookingToub>().IninToub();
                CookingToubs.transform.GetChild(2).transform.GetChild(2).GetComponent<CookingToub>().IninToub();
                break;
        }

    }

    //деактивация трубок в зависимости от сложности рецепта 
    public void DeactivateCookingToubsByHard()
    {
        //Debug.Log(recipeHard);
        switch (recipeHard)
        {
            case 0:
                CookingToubs.transform.GetChild(0).gameObject.SetActive(false);
                CookingToubs.transform.GetChild(0).transform.GetChild(0).GetComponent<CookingToub>().ResetToub();
                break;
            case 1:
                CookingToubs.transform.GetChild(1).gameObject.SetActive(false);
                CookingToubs.transform.GetChild(1).transform.GetChild(0).GetComponent<CookingToub>().ResetToub();
                CookingToubs.transform.GetChild(1).transform.GetChild(1).GetComponent<CookingToub>().ResetToub();
                break;
            case 2:
                CookingToubs.transform.GetChild(2).gameObject.SetActive(false);
                CookingToubs.transform.GetChild(2).transform.GetChild(0).GetComponent<CookingToub>().ResetToub();
                CookingToubs.transform.GetChild(2).transform.GetChild(1).GetComponent<CookingToub>().ResetToub();
                CookingToubs.transform.GetChild(2).transform.GetChild(2).GetComponent<CookingToub>().ResetToub();
                break;
        }

    }

    //активация пойнтер зон для переключения между трубками в зависимости от сложности рецепта 
    public void ActivatePointerZonesByHard()
    {
        // Debug.Log(recipeHard);
        switch (recipeHard)
        {
            case 0:
                PointerZones.transform.GetChild(0).gameObject.SetActive(true);
                currenSlider = 0;
                break;
            case 1:
                PointerZones.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                PointerZones.transform.GetChild(2).gameObject.SetActive(true);
                break;
        }

    }

    //деактивация пойнтер зон для переключения между трубками в зависимости от сложности рецепта 
    public void DeactivatePointerZonesByHard()
    {
        // Debug.Log(recipeHard);
        switch (recipeHard)
        {
            case 0:
                PointerZones.transform.GetChild(0).gameObject.SetActive(false);
                currenSlider = -1;
                break;
            case 1:
                PointerZones.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 2:
                PointerZones.transform.GetChild(2).gameObject.SetActive(false);
                break;
        }

    }
    //-----------------------------------------------------------------------------------------------------------
    public void UpButtonDown()
    {
       
        switch (recipeHard)
        {
            case 0:
                Debug.Log("hard 0");
                switch (currenSlider)
                {
                    case 0:
                        CookingToubs.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<CookingToub>().ChangeCuurenValue(currentChangeVall);
                        Debug.Log("hard 1 slider 0");
                        break;
                }
                break;
            case 1:
                Debug.Log("hard 1");
                switch (currenSlider)
                {
                    case 0:
                        Debug.Log("slider 0");
                        CookingToubs.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<CookingToub>().ChangeCuurenValue(currentChangeVall);
                        break;
                    case 1:
                        Debug.Log("slider 1");
                        CookingToubs.transform.GetChild(1).transform.GetChild(1).transform.GetComponent<CookingToub>().ChangeCuurenValue(currentChangeVall);
                        break;
                }
                break;
            case 2:
                Debug.Log("hard 2");
                switch (currenSlider)
                {
                    case 0:
                        Debug.Log("slider 0");
                        CookingToubs.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<CookingToub>().ChangeCuurenValue(currentChangeVall);
                        break;
                    case 1:
                        Debug.Log("slider 1");
                        CookingToubs.transform.GetChild(2).transform.GetChild(1).transform.GetComponent<CookingToub>().ChangeCuurenValue(currentChangeVall);
                        break;
                    case 2:
                        Debug.Log("slider 2");
                        CookingToubs.transform.GetChild(2).transform.GetChild(2).transform.GetComponent<CookingToub>().ChangeCuurenValue(currentChangeVall);
                        break;
                }
                break;
        }

    }
    //-----------------------------------------------------------------------------------------------------------
    public void DownButtonDown()
    {
        switch (recipeHard)
        {
            case 0:
                switch (currenSlider)
                {
                    case 0:
                        CookingToubs.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<CookingToub>().ChangeCuurenValue(-currentChangeVall);
                        break;
                }
                break;
            case 1:
                switch (currenSlider)
                {
                    case 0:
                        CookingToubs.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<CookingToub>().ChangeCuurenValue(-currentChangeVall);
                        break;
                    case 1:
                        CookingToubs.transform.GetChild(1).transform.GetChild(1).transform.GetComponent<CookingToub>().ChangeCuurenValue(-currentChangeVall);
                        break;
                }
                break;
            case 2:
                switch (currenSlider)
                {
                    case 0:
                        CookingToubs.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<CookingToub>().ChangeCuurenValue(-currentChangeVall);
                        break;
                    case 1:
                        CookingToubs.transform.GetChild(2).transform.GetChild(1).transform.GetComponent<CookingToub>().ChangeCuurenValue(-currentChangeVall);
                        break;
                    case 2:
                        CookingToubs.transform.GetChild(2).transform.GetChild(2).transform.GetComponent<CookingToub>().ChangeCuurenValue(-currentChangeVall);
                        break;
                }
                break;
        }

    }

}
