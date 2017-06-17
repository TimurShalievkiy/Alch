using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRotationTriger : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
     
        if (coll.transform.name == "R")
        {
            coll.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("R enter");
        }
    }
     void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.name == "R")
        {
            coll.transform.GetChild(1).gameObject.SetActive(false);
            Debug.Log("R exit");
        }
    }
}
