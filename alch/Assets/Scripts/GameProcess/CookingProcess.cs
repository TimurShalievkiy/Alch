using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingProcess : MonoBehaviour {
    public GameObject gridSequence;
    public GameObject ConteinerIngr;
	// Use this for initialization
	void Start () {
        LoadIngrInSequence();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void LoadIngrInSequence()
    {
        
        for (int i = 0; i < 4; i++)
        {
            GameObject a = ConteinerIngr;
            GameObject.Instantiate(a);//.SetParent(gridSequence.transform);
            a.transform.SetParent(gridSequence.transform);

        }
    }
}
