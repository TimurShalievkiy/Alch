using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingSlider : MonoBehaviour
{

    float minValSlider = 0; //максимальное значение слайдера
    float maxValSlider = 10; //минимальное значение слайдера

    float minTryeVal; //минимальное значение зеленой зоны
    float maxTrueVal; //максимальное значение зеленой зоны

    public float curPos; // текущая позиция



    public bool pause; //приостановка значения
    bool newIng = true;
    bool upDown;

    public float changeValSlider; //значение прироста\убывания слайдера
    public float minRandChangeVal = 0.01f; //минимальное рандомное значение изменения
    public float maxRandChangeVal = 0.1f; //максимальное рандомное значение изменения

    public float timeChangeStage; //Время стадии изменения
    public float minRandTime = 1.0f; //минимальная граница времени стадии
    public float maxRandTime = 10.0f; //максммальное граница времени стадии


    void Update()
    {
        if (pause)
        {
            if (timeChangeStage <= 0)
            {
                SetNewStageValues();
                
            }

            timeChangeStage -= Time.deltaTime;
            if(!upDown && curPos >= minValSlider)
                curPos -=  changeValSlider;
            else if(curPos <= maxValSlider)
                curPos += changeValSlider;

            this.GetComponent<Slider>().value = curPos;


        }
    }
    void InitCookingSlider()
    {
        this.GetComponent<Slider>().minValue = minValSlider;
        this.GetComponent<Slider>().maxValue = maxValSlider;
        newIng = false;
    }

    void SetNewStageValues()
    {
        if (newIng)
            InitCookingSlider();


        timeChangeStage = Random.Range(minRandTime, maxRandTime);
        changeValSlider = Random.Range(minRandChangeVal, maxRandChangeVal);
        Debug.Log(timeChangeStage + " " + changeValSlider);

        if (Random.Range(0, 100) >= 50)
            upDown = true;
        else
            upDown = false;
    }




}
