using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

    public struct interference {
        public string nameInterf;
        public int hard;
        public interference(string n, int h)
        {
            nameInterf = n;
            hard = h;
        }
    }
    public List<interference> listReferences;


    //индентификатор ингредиента
    int id;

    //масив ингредиентов входящих в рецепт
    int[] massIngr;

    //текущий ингредиент 
    int currentIngr;

   //id зелья которое получится в результате завершения рецепта 
    public int idPotion;

    //статус рецепта доступен или нет
    bool isOpen;

    //путь к спрайту рецепта 
    public string spritePas;

    public int price;

    public Recipe(int id, int idPotion, int price, string spritePas, List<interference> lr, int[] massIngr)
    {
        this.id = id;
        this.price = price;
        this.massIngr = massIngr;
        this.spritePas = spritePas;
        currentIngr = 0;
        isOpen = true;
        this.idPotion = idPotion;
        listReferences = lr;
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
    public bool IsOpen
    {
        get { return isOpen; }
        set { isOpen = value; }
    }

    //проверка на соответсвие текущего ингредиента и 
    public bool EqualsIngr(int x)
    {
       // Debug.Log("currentIngr = " + currentIngr);
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
    //значение для обработки во второй стадии 
    public float GetValueAllIngredient
    {
        get
        {
            float ret = 0;
            for (int i = 0; i < massIngr.Length; i++)
            {
               ret+= ListIngredient.ingredients[massIngr[i]].GetValueIngr;
            }
            return ret;
        }
    }
}
