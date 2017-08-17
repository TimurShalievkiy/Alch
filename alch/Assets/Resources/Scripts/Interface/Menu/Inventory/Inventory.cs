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
    public void LoadInvetory()
    {
        this.GetComponent< ListItems >().LoadFromDB();
 
        for (int i = 0; i < slotPanel.transform.childCount; i++)
        {
            slotPanel.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }

        for (int i = 0; i < ListItems.itemList.list.Count - 15 * currentPage; i++)
        {
            if (ListItems.itemList.list[i].id > -1)
            {
                // Debug.Log(i);
                slotPanel.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                slotPanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListItems.itemList.list[i].spritePass);
                slotPanel.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text = ListItems.itemList.list[i].count.ToString();
            }
        }
    }




    public void Start()
    {
        LoadInvetory();
    }



}

