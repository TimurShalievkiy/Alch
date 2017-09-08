using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterferencesManager : MonoBehaviour {

    public GameObject spauner;
    public GameObject SpaunerPosition;

    List<GameObject> listCurrentInterferences;

    public void Start()
    {
        listCurrentInterferences = new List<GameObject>();
    }

    public void RemoveAllInterferences()
    {
        foreach (var item in listCurrentInterferences)
        {
            Destroy(item);
        }
        listCurrentInterferences = new List<GameObject>();
    }

    public void CreateInterferences(List<Recipe.interference> l)
    {

        foreach (var item in l)
        {
            switch (item.nameInterf)
            {
                case "spauner":
                    

                    GameObject g = Instantiate(spauner);
                    g.transform.SetParent(SpaunerPosition.transform);
                    g.transform.GetComponent<Spauner>().way = 1;
                    g.transform.localPosition = new Vector3(0, 0, 0);
                    g.transform.localScale = new Vector3(1, 1, 1);
                    g.transform.GetComponent<Spauner>().SetSpawnerHard(item.hard);


                    GameObject g1 = Instantiate(spauner);
                    g1.transform.SetParent(SpaunerPosition.transform);
                    g1.transform.GetComponent<Spauner>().way = -1;
                    g1.transform.localPosition = new Vector3(0, 0, 0);
                    g1.transform.localScale = new Vector3(1, 1, 1);
                    g1.transform.GetComponent<Spauner>().SetSpawnerHard(item.hard);


                    listCurrentInterferences.Add(g);
                    listCurrentInterferences.Add(g1);
                    break;
                case "portal":
                    Debug.Log("created - " + item.nameInterf);
                    break;
            }
        }
   
    }
}
