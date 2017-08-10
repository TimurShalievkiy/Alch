using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListIngredient : MonoBehaviour {

    int id;

    public static List<Ingredient> ingredients;

	// Use this for initialization
	void Start () {
        ingredients = new List<Ingredient>() {
            new Ingredient(0,"salt","Images/Ingr/salt",5),
            new Ingredient(1, "lavanda", "Images/Ingr/lavanda",6),
            new Ingredient(2, "gold","Images/Ingr/gold",7),
            new Ingredient(3, "root","Images/Ingr/root",8),
            new Ingredient(4, "silver", "Images/Ingr/silver",9)
        };
       // Debug.Log("Ingredients done!");
	}

    public Ingredient GetIngredietnById(int x)
    {     
        return ingredients.Find(i => i.Id == x);
    }
    public static string GetSpritePassById(int x)
    {
        return  ingredients[x].SpritePass;
    }

}
