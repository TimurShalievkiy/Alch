using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //image a = ConteinerIngr;
            var a = Instantiate(ConteinerIngr, gridSequence.transform.position, Quaternion.identity);
            a.transform.SetParent(gridSequence.transform);
            a.transform.localScale =new Vector3(1, 1, 1);
        }
    }
}
