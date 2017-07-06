using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetIngrFromSequense : MonoBehaviour {

    public GameObject g;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DragEndDrop>())
        {
            Destroy(collision.gameObject);
            CookingProcess.currentIngr = System.Convert.ToInt32(collision.transform.name);
            //Debug.Log(123123123);
            //this.gameObject.GetComponent<Image>().color = new Color(255, 255, 0);
            g.GetComponent<CookingProcess>().AddIngredientToKattle();
        }
    }

}
