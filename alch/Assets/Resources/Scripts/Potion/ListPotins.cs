using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPotins : MonoBehaviour {

    public static List<Potion> potions;
	// Use this for initialization
	void Start () {
        potions = new List<Potion>() {
            new Potion(0,"tea",5, "Images/Sprites/Potions/potion1"),
            new Potion(1,"helth",10, "Images/Sprites/Potions/potion2"),
            new Potion(2, "poison",15, "Images/Sprites/Potions/potion3"),
            new Potion(3, "poison",20, "Images/Sprites/Potions/potion4")
        };

       // Debug.Log("Potions done!");

    }
    public  Potion GetIngredietnById(int x)
    {
        return potions.Find(i => i.Id == x);
    }



}
