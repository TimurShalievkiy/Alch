using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRotationTriger : MonoBehaviour {

    
    void OnCollisionEnter2D(Collision2D coll)
    {
        
       
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.name == "R")
        {
            coll.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
