using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public GameObject recipePanel;
    public GameObject inventoryPanel;
    public GameObject achievementsPanel;
    public GameObject ShopPanel;
    public GameObject ThreePanel;
    public GameObject QuestPanel;


    public void ButtonController(int idButton)
    {
        if (TrigerZoneMenuButton.currentButton == idButton)
            switch (idButton)
            {
                case 1:
                    ThreePanel.SetActive(true);
                    break;
                case 2:
                    achievementsPanel.SetActive(true);
                    break;
                case 3:
                    QuestPanel.SetActive(true);
                    break;
                case 4:
                    recipePanel.SetActive(true);
                    break;
                case 5:
                    inventoryPanel.SetActive(true);
                    break;
                case 6:
                    ShopPanel.SetActive(true);
                    break;

            }
    }

}
