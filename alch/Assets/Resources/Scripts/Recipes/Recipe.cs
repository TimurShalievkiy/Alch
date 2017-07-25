using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {
    //индентификатор ингредиента
    int id;
    //масив ингредиентов входящих в рецепт
    int[] massIngr;
    //количество трубок
    int hard;

    //текущий ингредиент 
    int currentIngr;

    //статус рецепта доступен или нет
    bool recipeStatus;

    public Recipe(int id, int hard, int[] massIngr)
    {
        this.id = id;
        this.massIngr = massIngr;
        this.hard = hard;
        currentIngr = 0;
        recipeStatus = true;

    }

    //инкремент ингредиента
    public void NextStepIngr()
    {
        //если сследующий ингрединт меньше длинны масива ингредиентов то инкрементируем
        if (currentIngr + 1 < massIngr.Length)
        {
            currentIngr++;
        }
        //иначе текущий ингредиент устанавливается в -1
        else
            currentIngr =-1;
    }


    //доступность ингредиента для готовки
    public bool RecipeStatus
    {
        get { return recipeStatus; }
        set { recipeStatus = value; }
    }

    //проверка на соответсвие текущего ингредиента и 
    public bool EqualsIngr(int x)
    {
        Debug.Log("currentIngr = " + currentIngr);
        if (x == massIngr[currentIngr])
        {
            return true;
        }
        else return false;
    }


    public int Id
    {
        get { return id;  }
    }

    public int[] MassIngr
    {
        get { return massIngr; }
    }

    //свойство дял получения количества трубок
    public int Hard
    {
        get { return hard; }
    }

    //текущий индентефикатр ингредиента
    public int CurrentIngrId
    {
        get { return massIngr[currentIngr]; }
    }

    //следующий ингредиент
    public int NxtIngr
    {
        get {
            if (currentIngr + 1 < massIngr.Length)
                return massIngr[currentIngr + 1];
            else return -1;
        }
    }

    //получить спрайт текущего ингредиента
    public Sprite GetCurrentSpriteIngr
    {
        get { return Resources.Load<Sprite>(ListIngredient.GetSpritePassById(massIngr[currentIngr])); }
    }

    //получить спрайт следующего ингредиента
    public Sprite GetNextSpriteIngr
    {
        get { return Resources.Load<Sprite>(ListIngredient.GetSpritePassById(massIngr[currentIngr +  1])); }
    }

    //достижение конца рецепта 
    public bool EndOfRecipe
    {
        get { if (currentIngr >= 0)
                return false;
            else return true;
        }
    }
}
