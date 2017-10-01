using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatControl : MonoBehaviour {

    public static bool UnlockHeatControl = false;
    public int CurrentPos = -1;
    public float progressHeat = 0;
    public void Update()
    {
        if (progressHeat >= 1)
        {
            ResetHeatControl();
            CookingProcess.recipe.NextStepIngr();
        }
        if (UnlockHeatControl && progressHeat>0)
            progressHeat -= Time.deltaTime * 0.3f;
    }


    public void DoUpHeat()
    {
        if (UnlockHeatControl)
        {
            CurrentPos = 0;
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cooking/MixAndHeat/1");
        }
    }

    public void DoDownHeat()
    {
        if (UnlockHeatControl)
        {
            if (CurrentPos == 0)
            {
                this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cooking/MixAndHeat/2");
                CurrentPos = 1;
                progressHeat += 0.3f;
               // Debug.Log(progressHeat);
            }
        }
    }


    public void ResetHeatControl()
    {
        UnlockHeatControl = false;
        CurrentPos = -1;
        progressHeat = 0;
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cooking/MixAndHeat/1");
        //  Debug.Log("Reset Heat");
    }
}
