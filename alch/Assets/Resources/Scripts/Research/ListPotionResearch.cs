using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPotionResearch : MonoBehaviour {

    GameObject ResearchTree;
    public List<PotionResearch> listPotionReserch;
	// Use this for initialization
	void Start () {
        ResearchTree = GameObject.Find("ResearchTree");
        listPotionReserch = new List<PotionResearch>();

        for (int i = 0; i < ResearchTree.transform.childCount; i++)
        {
            if (ResearchTree.transform.GetChild(i).transform.GetComponent<PotionResearch>())
            {
                listPotionReserch.Add(ResearchTree.transform.GetChild(i).transform.GetComponent<PotionResearch>());
            }
        }


        foreach (var item in listPotionReserch)
        {
            Debug.Log(item.firstPotionId + " " + item.firstPotionCount);
        }

    }
	

}
