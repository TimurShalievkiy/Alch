using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public float speed;
    public Vector2 moveDir;
	// Update is called once per frame
	void Update () {
        transform.Translate(moveDir * Time.deltaTime * speed);
	}
}
