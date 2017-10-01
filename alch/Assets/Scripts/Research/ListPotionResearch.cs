using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListPotionResearch : MonoBehaviour
{

    public  GameObject ResearchTree;
    public static int currentSelectResearch = -1;
    public List<PotionResearch> listPotionReserch;
    // Use this for initialization
    void Start()
    {
        //ResearchTree = GameObject.Find("ResearchTree");
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
            if (item.isOpen)
            {
                item.transform.GetComponent<Image>().color = Color.white;
                foreach (var item2 in item.nextResearch)
                {
                    item2.transform.GetComponent<Image>().color = Color.gray;
                }
            }
            else
                foreach (var item2 in item.nextResearch)
                {
                    item2.transform.GetComponent<Image>().color = Color.black;
                }

        }

    }

    public void UnlockResearch()
    {
        foreach (var i in listPotionReserch)
        {
            
            if (i.idResipe == currentSelectResearch)
            {
                i.UnlockResearch();
                foreach (var item in listPotionReserch)
                {
                    if (item.isOpen)
                    {
                        item.transform.GetComponent<Image>().color = Color.white;
                        foreach (var item2 in item.nextResearch)
                        {
                            item2.transform.GetComponent<Image>().color = Color.gray;
                        }
                    }
                    else
                        foreach (var item2 in item.nextResearch)
                        {
                            item2.transform.GetComponent<Image>().color = Color.black;
                        }
                }
                break;
            }
        }
       
    }

}
