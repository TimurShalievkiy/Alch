using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    public void SetTimeZero()
    {
        Time.timeScale = 0.001f;
    }
    public void SetTimeNormal()
    {
        Time.timeScale = 1f;
    }

}
