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

    // public enum itemType {recipe = 1, potion =2 }
    public List<ItemInInventory> list;

    public LisItemInInventory()
    {
  
    }
    public List<ItemInInventory> StartInventory()
    {
        return new List<ItemInInventory>()
        { new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item1"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item2"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item3"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item4"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item5"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item6"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item7"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item8"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item9"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item10"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item11"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item12"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item13"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item14"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item15"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item16"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item17"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item18"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item19"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item20"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item21"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item22"},
        new ItemInInventory {id = 0 ,count = 1, spritePass ="Images/Sprites/Recipes/r2", title = "item23"},
        new ItemInInventory {id = 1 ,count = 99, spritePass ="Images/Sprites/Recipes/r1", title = "item24"},
        new ItemInInventory {id = 1 ,count = 99, spritePass ="Images/Sprites/Recipes/r1", title = "item25"},
        new ItemInInventory {id = 1 ,count = 99, spritePass ="Images/Sprites/Recipes/r1", title = "item26"},
        new ItemInInventory {id = 1 ,count = 99, spritePass ="Images/Sprites/Recipes/r1", title = "item27"}};

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


