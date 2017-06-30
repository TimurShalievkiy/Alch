using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {
    int id;
    int[] massIngr;
    int hard;
    public Recipe(int id, int hard, int[] massIngr)
    {
        this.id = id;
        this.massIngr = massIngr;
        this.hard = hard;
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
    public int Hard
    {
        get { return hard; }
    }
}
