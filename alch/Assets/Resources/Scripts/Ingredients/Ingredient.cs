using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {

    int id;
    string nameIngr;
    string spritePass;


    public Ingredient(int id, string nameIngr, string spass)
    {
        this.id = id;
        this.nameIngr = nameIngr;
        this.spritePass = spass;
    }

    public int Id{ get{return id;} }

    public string SpritePass
    {
        get
        {
            return spritePass;
        }

    }

}
