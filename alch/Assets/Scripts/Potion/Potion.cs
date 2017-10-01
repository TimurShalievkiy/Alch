using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    int id;
    public string namePotion;
    public int price;
    public string spritePas;

    public Potion(int id, string namePotion, int price, string spritePas)
    {
        this.id = id;
        this.namePotion = namePotion;
        this.price = price;
        this.spritePas = spritePas;
    }

    public int Id{get{return id;}
    }
}
