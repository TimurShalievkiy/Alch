using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZone : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.GetComponent<SpawnObjInterf>())
        {
            Spauner.DeleteFromList(coll.gameObject);
        }
        else
            Destroy(coll.gameObject);

    }
}
