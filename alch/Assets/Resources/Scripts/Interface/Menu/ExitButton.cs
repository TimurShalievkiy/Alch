using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    public void DeactivateParrent()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
