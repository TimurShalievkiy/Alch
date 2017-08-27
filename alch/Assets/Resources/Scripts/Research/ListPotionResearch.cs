using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPotionResearch : MonoBehaviour {

    public List<PotionResearch> listPotionReserch;
	// Use this for initialization
	void Start () {
        listPotionReserch = new List<PotionResearch>() {
            new PotionResearch(1,3),
            new PotionResearch(1,2,2,2)
        };

    }
	

}
