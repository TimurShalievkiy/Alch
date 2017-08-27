using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionResearch : MonoBehaviour {
    //=========================================================
    public struct ReqPotion {
        public int potionId;
        public int countP;
        public ReqPotion(int id, int count)
        {
            potionId = id;
            countP = count;
        }    
    }
    //=========================================================


    public ReqPotion firstPotion;
    public ReqPotion secondPotion;
    public ReqPotion thirdPotion;

    bool isOpen = false;

  
    public PotionResearch(int idFirst, int countFirst)
    {
        firstPotion = new ReqPotion(idFirst, countFirst);
        secondPotion = new ReqPotion(-1, -1);
        thirdPotion = new ReqPotion(-1, -1);
    }
    public PotionResearch(int idFirst, int countFirst,int idSecond,int countSecond)
    {
        firstPotion = new ReqPotion(idFirst, countFirst);
        secondPotion = new ReqPotion(idSecond, countSecond);
        thirdPotion = new ReqPotion(-1, -1);
    }
    public PotionResearch(int idFirst, int countFirst, int idSecond, int countSecond, int idThird, int countThird)
    {
        firstPotion = new ReqPotion(idFirst, countFirst);
        secondPotion = new ReqPotion(idSecond, countSecond);
        thirdPotion =  new ReqPotion(idThird, countThird);
    }

    

    public bool CheckReqInInventory()
    {
        int count1 = firstPotion.countP;
        int count2 = secondPotion.countP;
        int count3 = thirdPotion.countP;

        for (int i = 0; i < ListItems.itemList.list.Count; i++)
        {
            if (ListItems.itemList.list[i].id == firstPotion.potionId && count1 > 0)
            {
                count1 -= ListItems.itemList.list[i].count;
            }
        }
        if (count1 <= 0 && count2 <= 0 && count3 <= 0)
            return true;
        //ListItems.itemList

        return false;
    }

}

