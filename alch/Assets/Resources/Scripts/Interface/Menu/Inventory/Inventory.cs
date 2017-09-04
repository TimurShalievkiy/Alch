using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int currentPage = 0;
    public static bool changList;
    int currentSlot = -1;

    private void Update()
    {
        if (changList)
        {
            LoadInvetory();
            changList = false;
        }
    }
    public void LoadInvetory()
    {
        this.GetComponent<ListItems>().LoadFromDB();

        for (int i = 0; i < slotPanel.transform.childCount; i++)
        {
            slotPanel.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }

        //Debug.Log( "list count"+ ListItems.itemList.list.Count);
        for (int i = slotPanel.transform.childCount * currentPage; i < slotPanel.transform.childCount * currentPage + slotPanel.transform.childCount; i++)
        {
            //Debug.Log("i = "+i);
            if (ListItems.itemList.list.Count > i && ListItems.itemList.list[i].id > -1)
            {
                int j = i - slotPanel.transform.childCount * currentPage;
                slotPanel.transform.GetChild(j).GetChild(0).gameObject.SetActive(true);
                slotPanel.transform.GetChild(j).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListItems.itemList.list[i].spritePass);
                slotPanel.transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<Text>().text = ListItems.itemList.list[i].count.ToString();
            }
        }
    }

    public void UpPage()
    {
        if (ListItems.itemList.list.Count < slotPanel.transform.childCount * currentPage + slotPanel.transform.childCount)
        {
            GameObject.Find("RightButton").GetComponent<Image>().color = Color.black;
        }
        else
        {
            currentPage++;
            if (ListItems.itemList.list.Count < slotPanel.transform.childCount * currentPage + slotPanel.transform.childCount)
                GameObject.Find("RightButton").GetComponent<Image>().color = Color.black;
        }

        LoadInvetory();
    }
    public void DpwnPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            LoadInvetory();
            GameObject.Find("RightButton").GetComponent<Image>().color = Color.white;
        }
    }




    public void Start()
    {

        LoadInvetory();
        changList = false;
    }

    public void ViewCurrentItem(int slot)
    {
        if (slotPanel.transform.GetChild(slot).transform.GetChild(0).gameObject.activeSelf)
        {
            GameObject g = GameObject.Find("ViewIngredient");
            g.transform.GetChild(0).transform.GetComponent<Image>().sprite = slotPanel.transform.GetChild(slot).transform.GetChild(0).transform.GetComponent<Image>().sprite;
            g.transform.GetChild(1).transform.GetComponent<Text>().text = ListItems.itemList.list[slotPanel.transform.childCount * currentPage + slot].title;
            currentSlot = slot;
        }
        else
        {
            GameObject g = GameObject.Find("ViewIngredient");
            g.transform.GetChild(0).transform.GetComponent<Image>().sprite = null;
            g.transform.GetChild(1).transform.GetComponent<Text>().text = "Title";
            currentSlot = -1;
        }
    }

    public void DeleteCurrentItem()
    {
        if (ListItems.itemList.list[slotPanel.transform.childCount * currentPage + currentSlot].count > 1)
        {
            ListItems.itemList.list[slotPanel.transform.childCount * currentPage + currentSlot].count--;
            this.GetComponent<ListItems>().SaveInDB();
  
            
        }
        else
        {
            ListItems.itemList.list.Remove(ListItems.itemList.list[slotPanel.transform.childCount * currentPage + currentSlot]);
            this.GetComponent<ListItems>().SaveInDB();
            
           
        }
        LoadInvetory();
    }


        
        public static void RemoveItemsFromInventoryResearch(int idFirst, int countFirst, int idSecond, int countSecond, int idThird, int countThird)
    {
        List<ItemInInventory> removeList = new List<ItemInInventory>();
        foreach (var item in ListItems.itemList.list)
        {
            if (countFirst <= 0 && countSecond<=0&& countThird<=0)
                break;

            if (item.type == "potion")
            {
                //============================================================ 
                if (item.id == idFirst)
                {
                    if (item.count == countFirst)
                    {
                        countFirst = -1;
                        removeList.Add(item);
                    }
                    else if (item.count < countFirst && countFirst > 0)
                    {
                        countFirst -= item.count;
                        removeList.Add(item);
                    }
                    else if (item.count > countFirst && countFirst > 0)
                    {
                        item.count -= countFirst;
                        countFirst = -1;
                    }                    
                }
                //============================================================
                if (item.id == idSecond)
                {
                    if (item.count == countSecond)
                    {
                        countSecond = -1;
                        removeList.Add(item);
                    }
                    else if (item.count < countSecond && countSecond > 0)
                    {
                        countSecond -= item.count;
                        removeList.Add(item);
                    }
                    else if (item.count > countSecond && countSecond > 0)
                    {
                        item.count -= countSecond;
                        countSecond = -1;
                    }
                }
                //============================================================
                if (item.id == idThird)
                {
                    if (item.count == countThird)
                    {
                        countThird = -1;
                        removeList.Add(item);
                    }
                    else if (item.count < countThird && countThird > 0)
                    {
                        countThird -= item.count;
                        removeList.Add(item);
                    }
                    else if (item.count > countThird && countThird > 0)
                    {
                        item.count -= countThird;
                        countThird = -1;
                    }
                }
                //============================================================
            }
        }
        for (int i = removeList.Count-1; i >=0 ; i--)
        {
            ListItems.itemList.list.Remove(removeList[i]);
        }
        GameObject.Find("Inventory").transform.GetComponent<ListItems>().SaveInDB();
       // GameObject.Find("Inventory").transform.GetComponent<ListItems>().LoadFromDB();
        GameObject.Find("Inventory").transform.GetComponent<Inventory>().LoadInvetory();
    }


    public void SellCurrenItem()
    { }



}

