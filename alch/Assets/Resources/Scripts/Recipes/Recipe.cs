using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {
    int id;
    int[] massIngr;

    public Recipe(int id, int[] massIngr)
    {
        this.id = id;
        this.massIngr = massIngr;
    }

    public int Id
    {
        get
        {
            return id;
        }
    }
    public int MassSize
    {
        get { return massIngr.Length; }
    }
    public int[] MassIngr
    {
        get { return massIngr; }
    }
}
