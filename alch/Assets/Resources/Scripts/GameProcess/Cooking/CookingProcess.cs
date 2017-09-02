using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProcess : MonoBehaviour
{

    public GameObject gridSequence;
    
    public GameObject nextIngrView;
    public GameObject spauners;

    public GameObject CookingPanelControl;
    public GameObject StartPanelControl;
    //public GameObject uoDownButton;
    public GameObject pauseButton;

 
    public GameObject SpaunerIngredient;


    //обьект котел
    public GameObject Kattle;

 
    //пойнтер зоны для переключения между трубками
    public GameObject PointerZones;

    //текущий рецепт
    public static Recipe recipe;


    public static int currentIngr;

    public int currenSlider = -1;

    bool readyToAddIngr;
    //bool readyToStady;

    public static bool firstStady = false;
 

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
            if (lifeFirstStadyCooking <= 0)
                EndCooking();

            //если рецепт доступен и не достигнут конец рецепта
            if (recipe.IsOpen && !recipe.EndOfRecipe)
            {
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


        //spauners.SetActive(false);
        gridSequence.SetActive(false);
        CookingPanelControl.SetActive(false);
        StartPanelControl.SetActive(true);
        readyToAddIngr = true;
        currentIngr = -1;
        firstStady = false;
        recipe.IsOpen = false;

        gridSequence.GetComponent<GeneratorIngrSeq>().ResetSequensParametrs();
        SpaunerIngredient.SetActive(false);

    }



    //инициализация процесса готовки.
    public void LoadIngrInSequence()
    {
        SpaunerIngredient.SetActive(true);

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



    //public void SetCurrentSliderVal(int x)
    //{       
    //    currenSlider = x;
    //    Debug.Log(currenSlider + " SetCurrentSliderVal");
    //}
}
