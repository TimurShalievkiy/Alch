using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {

    int id;
    string nameIngr;
    string spritePass;

    int R;
    int G;
    int B;

    public Ingredient(int id, string nameIngr, string spass, int R, int G, int B)
    {
        this.id = id;
        this.nameIngr = nameIngr;
        this.spritePass = spass;
        this.R = R;
        this.G = G;
        this.B = B;
    }

    public int Id{ get{return id;} }

    public string SpritePass
    {
        get
        {
            return spritePass;
        }

    }
    public void GetRGBIngr(out int R, out int G, out int B)
    {
        R = this.R;
        G = this.G;
        B = this.B;
    }
}
