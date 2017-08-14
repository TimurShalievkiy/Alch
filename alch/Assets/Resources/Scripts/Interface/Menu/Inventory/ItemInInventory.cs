using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInInventory {

   public int id { get; set; }
   public int count { get; set; }
   public string type { get; set; }
    public string title { get; set; }
    public string spritePass { get; set; }
    public bool stackabl { get; set; }
    public string itemType { get; set; }
    public int price { get; set; }
}

public class LisItemInInventory{

   public  List<ItemInInventory> list = new List<ItemInInventory>();

    public LisItemInInventory()
    {
        list = new List<ItemInInventory>();
       // { new ItemInInventory {id = 10 } };
    }

}

