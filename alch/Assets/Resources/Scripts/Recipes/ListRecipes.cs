using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListRecipes : MonoBehaviour {
    public GameObject conteinerRecipe;
    public GameObject panelRecipe;

   public static List<Recipe> recipes;
	// Use this for initialization
	void Start () {
        recipes = new List<Recipe>() {
            new Recipe(0,0,1, "Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",1) },new int[]{ 0,1,2,3,4}),

            new Recipe(1,1,3, "Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",2) } , new int[]{ 3,2,1,0,4}),

            new Recipe(2,2,5, "Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",3) },new int[]{ 4,3,2}),

            new Recipe(3,2, 7,"Images/Ingr/salt",new List<Recipe.interference>(){ new Recipe.interference("spauner",4) },new int[]{ 4,3,4,2,4,3,4})
        };
       
    }

    public void LoadRecipeIntoView()
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            if (recipes[i].IsOpen)
            {
                GameObject g =  conteinerRecipe;
                g.name = recipes[i].Id.ToString();
                Instantiate(g);
                Debug.Log(recipes[i].Id);
                panelRecipe.transform.SetParent(g.transform);
               
                g.transform.Find("Title").transform.GetComponent<Text>().text = ListPotins.potions[recipes[i].idPotion].namePotion;
                g.transform.Find("Image").transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(recipes[i].spritePas);
                g.transform.Find("RecipePrice").transform.GetComponent<Text>().text = recipes[i].price.ToString();
                
            }
        }
    }



}
