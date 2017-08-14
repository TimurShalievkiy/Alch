using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItems : MonoBehaviour {

    LisItemInInventory itemList;
    private void Start()
    {
        LoadFromDB();
        SaveInDB();
        Debug.Log(itemList.list[0].id);
    }

    public void LoadFromDB()
    {
        if (PlayerPrefs.HasKey("itemList"))
        {
            itemList = SerializerDeserializer.Deserialize<LisItemInInventory>(PlayerPrefs.GetString("itemList"));
        }
        else
        {
            itemList = new LisItemInInventory();
            SaveInDB();
            Debug.Log("NEw save");

         
        }
    }



    public void SaveInDB()
    {
        PlayerPrefs.SetString("itemList", SerializerDeserializer.Serialize<LisItemInInventory>(itemList));
    }


}
