﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZone : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
       // Debug.Log("enter");
        Destroy(coll.gameObject);

    }
}
