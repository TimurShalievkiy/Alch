using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingSlider : MonoBehaviour
{

    float minValSlider = 0; //максимальное значение слайдера
    float maxValSlider = 10; //минимальное значение слайдера

    float minGreenZoneVal = 4; //минимальное значение зеленой зоны
    float maxGreenZoneVal = 6; //максимальное значение зеленой зоны

    public float curPos; // текущая позиция



    public bool pause; //приостановка значения
    bool newIng = true;
    bool upDown;

    public float changeValSlider = 0; //значение прироста\убывания слайдера
    public float minRandChangeVal = 0.01f; //минимальное рандомное значение изменения
    public float maxRandChangeVal = 0.03f; //максимальное рандомное значение изменения

    public float timeChangeStage; //Время стадии изменения
    public float minRandTime = 3.0f; //минимальная граница времени стадии
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



            //  if (upDown && /*curPos < minValSlider &&*/ (curPos + changeValSlider)< maxValSlider)
            //       curPos -= changeValSlider;
            //   else if(!upDown &&/* curPos > maxValSlider*/(curPos - changeValSlider) > minValSlider)
            //       curPos += changeValSlider;

            if ((curPos + changeValSlider) < maxValSlider && (curPos + changeValSlider) > minValSlider)
            {
                if(upDown)
                    curPos += changeValSlider;
                else
                    curPos -= changeValSlider;
            }
               
        }
            this.GetComponent<Slider>().value = curPos;
        
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
        //Debug.Log(timeChangeStage + " " + changeValSlider);

        if (Random.Range(0, 100) >= 50)
            upDown = true;
        else
            upDown = false;


    }

    public void ChangeVariableVal(float x)
    {
       // if (upDown)
            changeValSlider += x; 
       //else if(!upDown)
       //     changeValSlider -= x;        
    }
    public bool RInGreenZone()
    {
        if (curPos >= minGreenZoneVal && curPos <= maxGreenZoneVal)
        {
          //this.GetComponent<Slider>().handleRect.GetComponent<Image>().color = Color.green;
            return true;
        }
        //this.GetComponent<Slider>().handleRect.GetComponent<Image>().color = Color.red;

        return false;
    }

    public float ChangeValSlider
    {
        get
        {
            return changeValSlider;
        }
    }
    public void ResetSlider()
    {
        pause = false;
        minValSlider = 0; //максимальное значение слайдера
        maxValSlider = 10; //минимальное значение слайдера
        curPos = 0; // текущая позиция
        newIng = true;
        timeChangeStage = 0; //Время стадии изменения
        //this.GetComponent<Slider>().handleRect.GetComponent<Image>().color = Color.red;
        this.GetComponent<Slider>().value = curPos;

    }


}
