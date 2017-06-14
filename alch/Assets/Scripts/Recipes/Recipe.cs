using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {
    int id;
    int[] MassIngr;

    public Recipe(int id, int[] MassIngr)
    {
        this.id = id;
        this.MassIngr = MassIngr;
    }
}
