using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBButtons : MonoBehaviour {



    public void DecrementR()
    {
        if(CookingProcess.R>0)
            CookingProcess.R -= 1;
    }
    public void DecrementG()
    {
        if (CookingProcess.G > 0)
            CookingProcess.G -= 1;
    }
    public void DecrementB()
    {
        if (CookingProcess.B > 0)
            CookingProcess.B -= 1;
    }
}
