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


    public GameObject RImage;
    public GameObject GImage;
    public GameObject BImage;


    public static Recipe recipe;
    public static int currentIngr;
    public Text timerByStady;



    bool readyToAddIngr;
    bool readyToStady;


    public static int R;
    public static int G;
    public static int B;

    float timeByRefine = 30f;

    public static int currentRecipeIngr = -1;

    void Start()
    {
        readyToAddIngr = true;
         currentRecipeIngr = -1; 

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentRecipeIngr + "   " + recipe.MassIngr[currentRecipeIngr]);
        if (currentRecipeIngr != -1 && nextIngrView.transform.GetChild(0).name != recipe.MassIngr[currentRecipeIngr].ToString())
        {
            nextIngrView.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(recipe.MassIngr[currentRecipeIngr]));
            nextIngrView.transform.GetChild(0).name = recipe.MassIngr[currentRecipeIngr].ToString();
        }
      
        if (readyToStady)
        {
            

            if (timeByRefine > 0)
            {
                DirectionSircl();
                timeByRefine -= Time.deltaTime;
                timerByStady.text = timeByRefine.ToString("0.0");

                RImage.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = R.ToString();
                GImage.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = G.ToString();
                BImage.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = B.ToString();
            }
            else
            {
                readyToStady = false;
                readyToAddIngr = true;
                timerByStady.text = "";
            }
            if (R == 0 && G == 0 && B == 0)
            {
                readyToStady = false;
                readyToAddIngr = true;
                if (currentRecipeIngr != recipe.MassIngr.Length - 1)
                {
                   
                    currentRecipeIngr = currentRecipeIngr+1;
                    nextIngrView.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(recipe.MassIngr[currentRecipeIngr]));
                    Debug.Log(recipe.MassIngr[currentRecipeIngr] + " " + currentRecipeIngr);
                }
                else
                {
                    EndCooking();
                }
            }


        }
    }

    public void EndCooking()
    {
        gridSequence.SetActive(false);
        ExitButton.SetActive(false);
        RecipesButton.SetActive(true);
        currentRecipeIngr = -1;
        currentIngr = -1;
        recipe = null;
        R = -1;
    }
    public void DirectionSircl()
    {



    }



    //добавление ингредиента для обработки 
    public void AddIngredientToKattle()
    {
        if (readyToAddIngr && currentIngr != -1)
        {
            ListIngredient.ingredients[currentIngr].GetRGBIngr(out R, out G, out B);
            readyToAddIngr = false;
            readyToStady = true;
            timeByRefine = 30f;
            Debug.Log(ListIngredient.ingredients[currentIngr].Id);
        }
    }


    //инициализация процесса готовки.
    public void LoadIngrInSequence()
    {       
        //удаление дочерних єлементов из очереди.
        if(gridSequence.transform.childCount > 0)
        for (int i = 0; i < gridSequence.transform.childCount; i++)
            Destroy(gridSequence.transform.GetChild(i).gameObject);

        
        gridSequence.SetActive(true);
        gridSequence.GetComponent<GeneratorIngrSeq>().Repeat();


    }



}
