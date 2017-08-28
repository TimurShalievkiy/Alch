using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (ListItems.itemList.list[i].id == firstPotionId && count1 > 0)
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

