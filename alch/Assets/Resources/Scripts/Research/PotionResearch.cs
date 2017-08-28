using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionResearch : MonoBehaviour
{

    public bool isOpen = false;

    public int firstPotionId;
    public int firstPotionCount;

    public int secondPotionId;
    public int secondPotionCount;

    public int thirdPotionId;
    public int thirdPotionCount;

    public int idResipe;

    public PotionResearch(int idFirst, int countFirst, int idResipe)
    {
        firstPotionId = idFirst;
        firstPotionCount = countFirst;

        secondPotionId = -1;
        secondPotionCount = -1;

        thirdPotionId = -1;
        thirdPotionCount = -1;
        this.idResipe = idResipe;
    }
    public PotionResearch(int idFirst, int countFirst, int idSecond, int countSecond, int idResipe)
    {
        firstPotionId = idFirst;
        firstPotionCount = countFirst;

        secondPotionId = idSecond;
        secondPotionCount = countSecond;

        thirdPotionId = -1;
        thirdPotionCount = -1;
        this.idResipe = idResipe;
    }
    public PotionResearch(int idFirst, int countFirst, int idSecond, int countSecond, int idThird, int countThird, int idResipe)
    {
        firstPotionId = idFirst;
        firstPotionCount = countFirst;

        secondPotionId = idSecond;
        secondPotionCount = countSecond;

        thirdPotionId = idThird;
        thirdPotionCount = countThird;
        this.idResipe = idResipe;
    }



    public bool CheckReqInInventory()
    {
        int count1 = firstPotionCount;
        int count2 = secondPotionCount;
        int count3 = thirdPotionCount;

        for (int i = 0; i < ListItems.itemList.list.Count; i++)
        {
            if (ListItems.itemList.list[i].type == "potion")
                {
                if (ListItems.itemList.list[i].id == firstPotionId && count1 > 0)
                {
                    count1 -= ListItems.itemList.list[i].count;
                }
                if (ListItems.itemList.list[i].id == secondPotionId && count2 > 0)
                {
                    count2 -= ListItems.itemList.list[i].count;
                }
                if (ListItems.itemList.list[i].id == thirdPotionId && count3 > 0)
                {
                    count3 -= ListItems.itemList.list[i].count;
                }
            }
        }
        if (count1 <= 0 && count2 <= 0 && count3 <= 0)
            return true;
        //ListItems.itemList

        return false;
    }



    public void FillViewResearch()
    {
        GameObject g =  GameObject.Find("ViewInfo");
        g.transform.Find("PotionImage").transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListPotins.potions[idResipe].spritePas);
        g.transform.Find("Title").transform.GetComponent<Text>().text = ListPotins.potions[idResipe].namePotion;

        if (!isOpen)
        {
            //====================================================================
            if (firstPotionId != -1)
            {
                g.transform.Find("FiratPotionImage").gameObject.SetActive(true);
                g.transform.Find("FiratPotionImage").transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListPotins.potions[firstPotionId].spritePas);
                g.transform.Find("FiratPotionImage").transform.GetChild(0).transform.GetComponent<Text>().text ="x"+ firstPotionCount.ToString();
            }
            else
            {
                g.transform.Find("FiratPotionImage").gameObject.SetActive(false);
            }
            //------------------------------------------------------------------
            if (secondPotionId != -1)
            {
                g.transform.Find("SecondPotionImage").gameObject.SetActive(true);
                g.transform.Find("SecondPotionImage").transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListPotins.potions[secondPotionId].spritePas);
                g.transform.Find("SecondPotionImage").transform.GetChild(0).transform.GetComponent<Text>().text = "x" + secondPotionCount.ToString();
            }
            else
            {
                g.transform.Find("SecondPotionImage").gameObject.SetActive(false);
            }
            //------------------------------------------------------------------
            if (thirdPotionId != -1)
            {
                g.transform.Find("ThirdPotionImage").gameObject.SetActive(true);
                g.transform.Find("ThirdPotionImage").transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListPotins.potions[thirdPotionId].spritePas);
                g.transform.Find("ThirdPotionImage").transform.GetChild(0).transform.GetComponent<Text>().text = "x" + thirdPotionCount.ToString();
            }
            else
            {
                g.transform.Find("ThirdPotionImage").gameObject.SetActive(false);
            }
            //====================================================================
            if (CheckReqInInventory())
            {
                g.transform.Find("AcceptButton").transform.GetComponent<Image>().color = Color.green;
            }
            else
                g.transform.Find("AcceptButton").transform.GetComponent<Image>().color = Color.red;


        }
        else {
            g.transform.Find("FiratPotionImage").gameObject.SetActive(false);
            g.transform.Find("SecondPotionImage").gameObject.SetActive(false);
            g.transform.Find("ThirdPotionImage").gameObject.SetActive(false);
            g.transform.Find("AcceptButton").transform.GetComponent<Image>().color = Color.grey;
        }
        

    }

}

