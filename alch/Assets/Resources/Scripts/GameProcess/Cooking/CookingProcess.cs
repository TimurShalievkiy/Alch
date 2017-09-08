using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProcess : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CookingPanel;


    public GameObject gridSequence;

    public GameObject nextIngrView;

    public GameObject StartPanelControl;

    public GameObject pauseButton;


    public GameObject SpaunerIngredient;


    //обьект котел
    public GameObject Kattle;


    //пойнтер зоны для переключения между трубками
    public GameObject PointerZones;

    //текущий рецепт
    public static Recipe recipe;

    public static int currentIngr;

    bool readyToAddIngr;

    public static bool firstStady = false;


    public static int lifeFirstStadyCooking;//количество жизней первой стадии готовки
    public Text lifeText;

    void Start()
    {
        readyToAddIngr = true;
    }


    // Update is called once per frame
    void Update()
    {
        //первая стадия готовки
        if (firstStady)
        {
            //если показатель жизней равен 0 заканчиваем готовку
            if (lifeFirstStadyCooking <= 0)
                EndCooking();

            if(recipe.EndOfRecipe)
                EndCooking();
            //если рецепт доступен и не достигнут конец рецепта
            if (recipe.IsOpen && !recipe.EndOfRecipe)
            {

                if (recipe.MassIngr[recipe.currentIngr] == 0 && !HeatControl.UnlockHeatControl)
                {
                    //Debug.Log("++++++++++++");
                    HeatControl.UnlockHeatControl = true;
                }
                else if (recipe.MassIngr[recipe.currentIngr] == 1 && !MixControl.UnlockMixtControl)
                {
                   // Debug.Log("-----------");
                    MixControl.UnlockMixtControl = true;
                }



                //устанавливаем спрайт и имя панели отображения текущего ингредиента              
                nextIngrView.transform.GetChild(1).GetComponent<Image>().sprite = recipe.GetCurrentSpriteIngr;
                nextIngrView.transform.GetChild(1).name = recipe.CurrentIngrId.ToString();
            }
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
                EndCooking();
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


        GameObject.Find("InterferencesManager").transform.GetComponent<InterferencesManager>().RemoveAllInterferences();

        gridSequence.SetActive(false);
        StartPanelControl.SetActive(true);
        readyToAddIngr = true;
        currentIngr = -1;
        firstStady = false;
        recipe.IsOpen = false;

        gridSequence.GetComponent<GeneratorIngrSeq>().ResetSequensParametrs();
        SpaunerIngredient.SetActive(false);
        CookingPanel.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }



    //инициализация процесса готовки.
    public void LoadIngrInSequence()
    {
        CookingPanel.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);

        SpaunerIngredient.SetActive(true);


        //удаление дочерних єлементов из очереди.
        if (gridSequence.transform.childCount > 0)
            for (int i = 0; i < gridSequence.transform.childCount; i++)
                Destroy(gridSequence.transform.GetChild(i).gameObject);

        //активация очереди ингредиентов
        gridSequence.SetActive(true);
        gridSequence.GetComponent<GeneratorIngrSeq>().Repeat();//метод повторения спавна ингредиентов

        nextIngrView.gameObject.SetActive(true);

        lifeFirstStadyCooking = 100;
        lifeText.text = lifeFirstStadyCooking.ToString();
        lifeText.transform.parent.gameObject.SetActive(true);

        GameObject.Find("InterferencesManager").transform.GetComponent<InterferencesManager>().CreateInterferences(ListRecipes.recipes[recipe.Id].listInterferences);

        pauseButton.transform.position = new Vector2(Screen.width - 120, 120);
    }




}
