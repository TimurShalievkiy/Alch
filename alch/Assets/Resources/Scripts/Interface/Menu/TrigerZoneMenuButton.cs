using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerZoneMenuButton : MonoBehaviour
{


    //при входе элемента в тригер зону
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //проверяем есть ли у этого элемента скрипт MenuButton
        if (collision.transform.GetComponent<MenuButton>())
        {
            //переменная растояния между кнопками меню
            float p = collision.bounds.size.x * 2.5f;

            //увеличение скейла кнопки
            collision.transform.localScale = new Vector2(1.5f, 1.5f);
         
            //в зависимости какая кнопка зашла в тригер перемещаем крайние на нужные позиции
            switch (collision.name)
            {
                case "1":
                    this.transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(5).position.x - p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(2).position.x + p, this.transform.GetChild(0).position.y);
                    break;
                case "2":
                    this.transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(6).position.x - p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(3).position.x + p, this.transform.GetChild(0).position.y);
                    break;
                case "3":
                    this.transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(0).position.x - p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(4).position.x + p, this.transform.GetChild(0).position.y);
                    break;
                case "4":
                    this.transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(1).position.x - p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(5).position.x + p, this.transform.GetChild(0).position.y);
                    break;
                case "5":
                    this.transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(6).position.x + p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(2).position.x - p, this.transform.GetChild(0).position.y);              
                    break;
                case "6":
                    this.transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(0).position.x + p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(3).position.x - p, this.transform.GetChild(0).position.y);
                    break;
                case "7":
                    this.transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(1).position.x + p, this.transform.GetChild(0).position.y);
                    this.transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(4).position.x - p, this.transform.GetChild(0).position.y);
                    break;
            }


        }      
    }

    //при выходе из тригера
    private void OnTriggerExit2D(Collider2D collision)
    {
        //проверяем есть ли у этого элемента скрипт MenuButton
        if (collision.transform.GetComponent<MenuButton>())
        {
            //возвращаем скейл в нормальное положение
            collision.transform.localScale = new Vector2(1, 1);

        }
    }
}
