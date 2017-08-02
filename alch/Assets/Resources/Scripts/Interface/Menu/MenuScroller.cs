using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScroller : EventTrigger
{
    //включена ли обработка инерции
    bool doInertia;
    //направление инерции
    bool way;
    //предыдущая позиция тача
    float oldPos = 0;
    //разница между предыдущей и нынешней позицией тача
    float current;
    //переменная для замедления в прощете инерции
    float antiInert;


    //обработка инерции
    public void FixedUpdate()
    {
        //если инерция включена
        if (doInertia)
        {
            //непревышает ли смещение максимально допустим границ
            if (current > 75)
                current = 75;
            if (current < -75)
                current = -75;
            //если инерция в правую сторону
            if (way)
            {
                //отнимаем от смещения переменную замедления
                current -= antiInert;
                //увеличиваем переменную замедления 
                antiInert += Time.deltaTime * 5;

                //смещение элементов меню
                this.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(0).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(1).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(1).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(2).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(2).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(3).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(3).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(4).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(4).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(5).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(5).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(6).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(6).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(7).transform.position.y);

                //если смещение меньше переменной замедления 
                if (current < antiInert)
                {
                    //обнуляем переменную замедления
                    antiInert = 0;
                    //останавливаем инецию
                    doInertia = false;
                }
            }
            //если направление инерции влево
            else
            {
                //прибавляем переменную замедления к смещению
                current += antiInert;
                //увеличиваем переменную замедления 
                antiInert += Time.deltaTime * 5;

                //смещение элементов меню
                this.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(0).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(1).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(1).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(2).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(2).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(3).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(3).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(4).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(4).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(5).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(5).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(6).transform.position.y);
                this.transform.GetChild(0).transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(6).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(7).transform.position.y);

                //если смещение превысило 0
                if (current > 0)
                {
                    //обнуляем переменную замедления
                    antiInert = 0;
                    //останавливаем инецию
                    doInertia = false;
                }
            }
        }
    }


    //при начале перетаскивания
    public override void OnBeginDrag(PointerEventData data)
    {
        //останавливаем инерцию
        doInertia = false;
        //обнуляем переменную замедления
        antiInert = 0;
        //задаем предыдущую позицию смещения тача
        oldPos = data.position.x;
    }

    //в момент перетаскивания
    public override void OnDrag(PointerEventData data)
    {
        //выщитываем разницу между предыдущей и нынешней позицией тача
        current = data.position.x - oldPos;

        //проверяем на выход за допустимый диапазон
        if (current > 75)
            current = 75;
        if (current < -75)
            current = -75;

        //смещаем элементы меню
        this.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(0).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(1).transform.position.y);
        this.transform.GetChild(0).transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(1).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(2).transform.position.y);
        this.transform.GetChild(0).transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(2).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(3).transform.position.y);
        this.transform.GetChild(0).transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(3).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(4).transform.position.y);
        this.transform.GetChild(0).transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(4).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(5).transform.position.y);
        this.transform.GetChild(0).transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(5).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(6).transform.position.y);
        this.transform.GetChild(0).transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(6).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(7).transform.position.y);

        //переопреназначаем старую позициюж
        oldPos = data.position.x;

    }

    //по завершении перетаскивания
    public override void OnEndDrag(PointerEventData data)
    {
        //проверяем на выход за допустимый диапазон
        if (current > 75)
            current = 75;
        if (current < -75)
            current = -75;

        //уменьшаем в два раза значение разницы 
        current = (data.position.x - oldPos) / 2;

        //определяем в какую сторуну идет инерция
        if (current > 0)
            way = true;
        else if (current < 0)
            way = false;
        oldPos = 0;

        //запускаем инерцию
        doInertia = true;

    }


}
