using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListInterfSprites : MonoBehaviour {
    public struct InterferensItem
    {
        public int id;
        public int helth;
        public string spr;

    }


    public static List<InterferensItem> listInterfItem;
	// Use this for initialization
	void Start () {
        listInterfItem = new List<InterferensItem>()
        {
            new InterferensItem{ id = 0,  helth =1 , spr = "Images/Interference/1"},
             new InterferensItem{ id = 1,  helth =2 , spr = "Images/Interference/2"},
              new InterferensItem{ id = 2,  helth =3 , spr = "Images/Interference/3"}
        };
    }

 
}
