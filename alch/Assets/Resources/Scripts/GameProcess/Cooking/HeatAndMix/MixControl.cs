using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixControl : MonoBehaviour {

    public static bool UnlockMixtControl = false;
    public int CurrentPos = -1;
    public float progressMix = 0;

    public void Update()
    {
        if (progressMix >= 1)
        {
            ResetHeatControl();
            CookingProcess.recipe.NextStepIngr();
        }
        if (UnlockMixtControl && progressMix > 0)
            progressMix -= Time.deltaTime * 0.5f;
    }


    public void DoRightMix()
    {
        if (UnlockMixtControl)
        {
            CurrentPos = 0;
           // Debug.Log("Left");
        }
    }

    public void DoLeftMix()
    {
        if (UnlockMixtControl)
        {
            if (CurrentPos == 0)
            {

                CurrentPos = 1;
                progressMix += 0.2f;
               // Debug.Log("Right " +progressMix);
            }
        }
    }


    public void ResetHeatControl()
    {
        UnlockMixtControl = false;
        CurrentPos = -1;
        progressMix = 0;
       // Debug.Log("Reset Mix");
    }
}
