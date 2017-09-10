using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListRecipes : MonoBehaviour {

    public GameObject panelRecipeView;

   public static List<Recipe> recipes;
	// Use this for initialization
	void Start () {
        recipes = new List<Recipe>() {
            new Recipe(0,0,1, "Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",2) },new int[]{ 2,3,4,0,3,4,2,1,3,2}),

            new Recipe(1,1,3, "Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",2) } , new int[]{ 3,2,4,2,4}),

            new Recipe(2,2,5, "Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",3) },new int[]{ 4,3,2}),

            new Recipe(3,3, 7,"Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",3) },new int[]{ 4,3,4,2,4,3,4})
        };
        recipes[0].IsOpen = true;



    }

  

    public void LoadRecipeIntoView()
    {


        for (int i = 0; i < panelRecipeView.transform.childCount; i++)
        {
            if (i < recipes.Count)
            {
                if (recipes[i].IsOpen)
                {
                    panelRecipeView.transform.GetChild(i).gameObject.SetActive(true);
                    panelRecipeView.transform.GetChild(i).name = recipes[i].Id.ToString();
                    panelRecipeView.transform.GetChild(i).Find("Title").GetComponent<Text>().text = ListPotins.potions[recipes[i].Id].namePotion;
                    panelRecipeView.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(ListPotins.potions[recipes[i].Id].spritePas);
                    panelRecipeView.transform.GetChild(i).Find("RecipePrice").GetComponent<Text>().text = recipes[i].price.ToString();
                    continue;
                }
                else
                    panelRecipeView.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                panelRecipeView.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }



}
