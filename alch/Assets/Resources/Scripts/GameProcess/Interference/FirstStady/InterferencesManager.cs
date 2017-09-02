using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterferencesManager : MonoBehaviour {

    public static List<GameObject> GetListInterferencesAsGameObject(List<Recipe.interference> l)
    {
        foreach (var item in l)
        {


            switch (item.nameInterf)
            {
                case "spauner":
                    Debug.Log("created - " + item.nameInterf);
                    break;
                case "portal":
                    Debug.Log("created - " + item.nameInterf);
                    break;
            }
        }
        return null;
    }
}
