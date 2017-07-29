using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerZoneMenuButton : MonoBehaviour
{

    public GameObject NextPosition;


    public GameObject LeftPosition;
    public GameObject RightPosition;


    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.transform.GetComponent<MenuButton>() && curentTransportName != collision.name)
    //    {
    //        Debug.Log("triger " + this.name);
    //        curentTransportName = collision.name;
    //        collision.transform.position = NextPosition.transform.position;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<MenuButton>())
        {
            collision.transform.localScale = new Vector2(1.5f, 1.5f);
            switch (collision.name)
            {
                case "1":
                    this.transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(5).position.x - 300, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(2).position.x + 300, this.transform.GetChild(0).position.y);

                    break;
                case "2":
                    this.transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(6).position.x - 300, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(3).position.x + 300, this.transform.GetChild(0).position.y);

                    break;
                case "3":
                    this.transform.GetChild(6).transform.position = new Vector2( this.transform.GetChild(0).position.x -300, this.transform.GetChild(0).position.y) ;
                    this.transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(4).position.x + 300, this.transform.GetChild(0).position.y);
                    break;
                case "4":
                    this.transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(1).position.x - 300, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(5).position.x + 300, this.transform.GetChild(0).position.y);

                    break;
                case "5":
                    this.transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(6).position.x + 300, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(2).position.x - 300, this.transform.GetChild(0).position.y);

                    break;
                case "6":
                    this.transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(0).position.x + 300, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(3).position.x - 300, this.transform.GetChild(0).position.y);

                    break;
                case "7":
                    this.transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(1).position.x + 300, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(4).position.x - 300, this.transform.GetChild(0).position.y);

                    break;
                default:
                    break;
            }

        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<MenuButton>())
        {
            collision.transform.localScale = new Vector2(1, 1);

        }
    }
}
