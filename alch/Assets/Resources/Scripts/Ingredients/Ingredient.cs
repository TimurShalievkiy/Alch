using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {

    int id;
    string nameIngr;
    string spritePass;

    float valueIngr;

    public Ingredient(int id, string nameIngr, string spass, float valueIngr)
    {
        this.id = id;
        this.nameIngr = nameIngr;
        this.spritePass = spass;
        this.valueIngr = valueIngr;
    }

    public int Id{ get{return id;} }

    public string SpritePass
    {
        get
        {
            return spritePass;
        }

    }
    public float GetValueIngr
    {
        get { return valueIngr; }
    }
}
