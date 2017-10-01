using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScroller : EventTrigger
{
    public static float xcurrent = 0;
    //направление инерции
    public static bool way;
    //предыдущая позиция тача
    public static float oldPos = 0;
    //разница между предыдущей и нынешней позицией тача
    public static float current;
 

    public static int reiteration;

    GameObject go;
    public void Start()
    {
        go = GameObject.Find("MenuButtonsPanel");

        //тут растояние между кнопками
    }

    public void FixedUpdate()
    {
       // если инерция включена

        if (reiteration > 0)
        {
            //  Debug.Log(reiteration);
            //смещаем элементы меню
            if (way)
                for (int i = 0; i < go.transform.GetChild(0).transform.childCount; i++)
                {
                    go.transform.GetChild(0).transform.GetChild(i).transform.position = new Vector2(go.transform.GetChild(0).transform.GetChild(i).transform.position.x + Time.deltaTime * (1000), go.transform.GetChild(0).transform.GetChild(1).transform.position.y);
                }
            else
                for (int i = 0; i < go.transform.GetChild(0).transform.childCount; i++)
                    go.transform.GetChild(0).transform.GetChild(i).transform.position = new Vector2(go.transform.GetChild(0).transform.GetChild(i).transform.position.x - Time.deltaTime * (1000), go.transform.GetChild(0).transform.GetChild(1).transform.position.y);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {

        //переопреназначаем старую позициюж
        oldPos = eventData.position.x;
    }
    //в момент перетаскивания
    public override void OnDrag(PointerEventData data)
    {
        //выщитываем разницу между предыдущей и нынешней позицией тача
         current = data.position.x - oldPos;

    
        //уменьшаем в два раза значение разницы 
        current = (data.position.x - oldPos);

        xcurrent = current;


        if (xcurrent < 0)
            xcurrent *= -1;

        if (xcurrent > 5 && xcurrent < 100)
            reiteration = 1;
        else if (xcurrent >= 100)
            reiteration = 2;

     

        //определяем в какую сторуну идет инерция
        if (current > 0)
            way = true;
        else if (current < 0)
            way = false;
        
        //переопреназначаем старую позициюж
        oldPos = data.position.x;




    }


    public override void OnEndDrag(PointerEventData data)
    {
        oldPos = 0;
    }



}
