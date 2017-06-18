using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIngrFromSequense : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D coll)
    {
        CookingProcess.currentIngr = System.Convert.ToInt32(coll.transform.name);
        this.gameObject.GetComponent<Image>().color = new Color(255, 255, 0);
    
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        CookingProcess.currentIngr = -1;
        this.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);


    }
}
