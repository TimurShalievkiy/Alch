using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPotins : MonoBehaviour {

    List<Potion> potions;
	// Use this for initialization
	void Start () {
        potions = new List<Potion>() {
            new Potion(0,"tea",5),
            new Potion(1,"helth",10),
            new Potion(2, "poison",15)
        };
    
    }
    public Potion GetIngredietnById(int x)
    {
        return potions.Find(i => i.Id == x);
    }


}
