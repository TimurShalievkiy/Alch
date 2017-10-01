using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            progressMix -= Time.deltaTime * 0.3f;
    }


    public void DoRightMix()
    {
        if (UnlockMixtControl)
        {
            CurrentPos = 0;
            this.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cooking/MixAndHeat/ladle_1");
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
                progressMix += 0.3f;
                this.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

                //this.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Cooking/MixAndHeat/ladle_2");
                // Debug.Log("Right " +progressMix);
            }
        }
    }


    public void ResetHeatControl()
    {
        this.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        UnlockMixtControl = false;
        CurrentPos = -1;
        progressMix = 0;
       // Debug.Log("Reset Mix");
    }
}
