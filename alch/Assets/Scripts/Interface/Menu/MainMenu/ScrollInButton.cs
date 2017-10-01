using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollInButton : EventTrigger {




    public override void OnBeginDrag(PointerEventData eventData)
    {

        //переопреназначаем старую позициюж
        MenuScroller.oldPos = eventData.position.x;
    }
    //в момент перетаскивания
    public override void OnDrag(PointerEventData data)
    {
        //выщитываем разницу между предыдущей и нынешней позицией тача
        MenuScroller.current = data.position.x - MenuScroller.oldPos;


        //уменьшаем в два раза значение разницы 
        MenuScroller.current = (data.position.x - MenuScroller.oldPos);

        MenuScroller.xcurrent = MenuScroller.current;


        if (MenuScroller.xcurrent < 0)
            MenuScroller.xcurrent *= -1;

        if (MenuScroller.xcurrent > 5 && MenuScroller.xcurrent < 100)
            MenuScroller.reiteration = 1;
        else if (MenuScroller.xcurrent >= 100)
            MenuScroller.reiteration = 2;



        //определяем в какую сторуну идет инерция
        if (MenuScroller.current > 0)
            MenuScroller.way = true;
        else if (MenuScroller.current < 0)
            MenuScroller.way = false;

        //переопреназначаем старую позициюж
        MenuScroller.oldPos = data.position.x;




    }


    public override void OnEndDrag(PointerEventData data)
    {
        MenuScroller.oldPos = 0;
    }

}
