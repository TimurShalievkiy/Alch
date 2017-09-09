using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanels : MonoBehaviour
{

    public GameObject winPanel;
    public GameObject failPanel;
    public GameObject endPanel;


    public void ShowDialogWindow(bool b, int idPotion)
    {
        
        endPanel.gameObject.SetActive(true);
        if (b)
        {
            GameObject.Find("Inventory").transform.GetComponent<ListItems>().AddItem(idPotion, "potion");
            winPanel.gameObject.SetActive(true);
            winPanel.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(ListPotins.potions[idPotion].spritePas);
        }
        else
        {
            failPanel.gameObject.SetActive(true);

        }
        Time.timeScale = 0.001f;
    }

    public void OkButtonConfirmPanel()
    {
        Debug.Log("Ok");
        winPanel.gameObject.SetActive(false);
        failPanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(false);
        this.GetComponent<CookingProcess>().EndCooking();
        Time.timeScale = 1f;
 
        
    }
}
