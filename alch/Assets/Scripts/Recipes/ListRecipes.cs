using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListRecipes : MonoBehaviour {

   public static List<Recipe> recipes;
	// Use this for initialization
	void Start () {
        recipes = new List<Recipe>() {
            new Recipe(0,new int[]{ 0,1,2,3,4}),
            new Recipe(1,new int[]{ 3,2,1,0,4}),
            new Recipe(2,new int[]{ 4,3,4,3,4}),
            new Recipe(3,new int[]{ 4,3,4,3,4,3,4})
        };

        //Debug.Log("Recipes done!");
    }


}
