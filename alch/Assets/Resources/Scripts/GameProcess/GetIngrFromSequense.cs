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
            try
            {
               
                CookingProcess.currentIngr = System.Convert.ToInt32(collision.transform.name);
                g.GetComponent<CookingProcess>().AddIngredientToKattle();
                Destroy(collision.gameObject);
            }
            catch
            {
            }
        }
    }

}
