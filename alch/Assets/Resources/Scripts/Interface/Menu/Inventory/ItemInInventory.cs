using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInInventory
{

    public int id { get; set; }
    public string type { get; set; }
    public string spritePass { get; set; }
    public int count { get; set; }
    public string title { get; set; }
    public bool stackabl { get; set; }
    public int price { get; set; }

    public ItemInInventory(int id,
    string type,
    string spritePass,
    int count,
    string title,
    bool stackabl,
    int price)
    {
        this.id = id;
        this.type = type;
        this.spritePass = spritePass;
        this.count = count;
        this.title = title;
        this.stackabl = stackabl;
        this.price = price;
    }
    public ItemInInventory()
    { }
}

public class LisItemInInventory
{
    public List<ItemInInventory> list;

    public LisItemInInventory()
    {
  
    }
    public List<ItemInInventory> StartInventory()
    {
        return new List<ItemInInventory>()
        { new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 0 ,count = 1, spritePass =ListPotins.potions[0].spritePas, title = ListPotins.potions[0].namePotion},
        new ItemInInventory {id = 1 ,count = 99, spritePass =ListPotins.potions[1].spritePas, title = ListPotins.potions[1].namePotion},
        new ItemInInventory {id = 1 ,count = 99, spritePass =ListPotins.potions[1].spritePas, title = ListPotins.potions[1].namePotion},
        new ItemInInventory {id = 1 ,count = 99, spritePass =ListPotins.potions[1].spritePas, title = ListPotins.potions[1].namePotion},
        new ItemInInventory {id = 1 ,count = 99, spritePass =ListPotins.potions[1].spritePas, title = ListPotins.potions[1].namePotion}
        };
    }

    public ItemInInventory AddItemInInventory(int id, string type)
    {
        switch (type)
        {
            case "potion":
               // Debug.Log(ListPotins.potions[id].namePotion + " " + ListPotins.potions[id].price);
                return new ItemInInventory(id, "potion", ListPotins.potions[id].spritePas, 1, ListPotins.potions[id].namePotion, true, ListPotins.potions[id].price);
                break;
            case "recipe":

                break;
              
        }
        return null;

    }

    public bool CheckItemInInventory(ItemInInventory it)
    {
        foreach (var item in list)
        {
            if (item.id == it.id && item.type == it.type)
                return true;
        }


            return false;
    }

}


