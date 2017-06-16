using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    int id;
    string namePotion;
    int price;

    public Potion(int id, string namePotion, int price)
    {
        this.id = id;
        this.namePotion = namePotion;
        this.price = price;
    }

    public int Id{get{return id;}
    }
}
