using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingToub : MonoBehaviour {

    //заполняющая плоскость
    public GameObject fillArea;

    //маска для отображения заполняющей плоскости
    public GameObject toubMask;

    //длина зоны которая заполняеться в трубе
    float weightFillZone;

    //текущее значение заполненности трубы
    public float currVal = 1;

    //переменная изменяющая текущее значение трубы
    public float currChangVal = 0.1f;

    //максимальное значение заполняемости трубы
    float maxValToube;

    //минимальная высота зеленой зоны
    float minWeightGreenZone;

    //максимальная высота зеленой зоны
    float maxWeightGreenZone;

    //соотношение длины заполняемой зоны к максимальному значению трубы
    float ratioMaxAndCurVal = 0;

    //переменная времени действия рандомного направления 
    public float timeRandDirection = 0;


    //включена ли труба
    public bool toubWork;

    public bool val = true;

    public void Update()
    {
        if (toubWork)
        {
            if (val)
            {
                IninToub();
                val = false;
            }
            else
            {

                //если время таймера закончилось выполняется переназначение 
                if (timeRandDirection <= 0)
                {
                    RandVal();
                }
                else
                {

                    //вызов метода изменения значения трубки
                    ChangeCurVal(currChangVal);

                    //таймер до изменения напрвления и вызова метода  RandVal()
                    timeRandDirection -= Time.deltaTime;
                }

            }
        }
    }

    //инициализация трубы для работы 
    public void IninToub()
    {


        //задаем текущее значение трубки 
        currVal = 1;

        //максимальное значение трубки
        maxValToube = 20;

        //длина заполняемой зоны
        weightFillZone = toubMask.GetComponent<RectTransform>().rect.height;

        //соотношение максимального значения к высоте
        ratioMaxAndCurVal = weightFillZone / maxValToube;

        //помещение заполняющей плоскости в стартовую позицию
        fillArea.transform.localPosition = new Vector2(0f, -weightFillZone);


        //включение трубки в работу 
        toubWork = true;

    }


    //сброс значений трубы 
    public void ResetToub()
    {
       
    }

    public void RandVal()
    {
        //задание времени которое будет сохранятся данное направление изменения значения трубки
        timeRandDirection = Random.Range(5, 7);

        //изменение направления с шансом 60%
        if (Random.Range(1, 100) > 40)
            currChangVal = -currChangVal;
        
    }

    //изменение текущего значения трубки 
    public void ChangeCurVal(float x)
    {
        //если текущее значение трубы меньше максимального значения и больше нуля 
        if (currVal + x < maxValToube && currVal + x > 0)
        {
            //добавление переменной к текущему значению
            currVal += x;

            //перемещение заполняющей плоскости
            fillArea.transform.localPosition = new Vector2(0f, -(weightFillZone - (currVal * ratioMaxAndCurVal)));
        }
    }

}
