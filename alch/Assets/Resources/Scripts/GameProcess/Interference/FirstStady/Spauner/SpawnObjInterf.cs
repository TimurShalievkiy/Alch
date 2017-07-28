using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjInterf : MonoBehaviour  {

    //количество здоровья
    public int helth = 1;

    //скорость 
    float speed = 1;


    //Нанесение урона по обьекту
    public void DoDamag()
    {
       // Debug.Log("DoDamag");

        helth--;
        if (helth <= 0)
            Destroy(this.gameObject);
    }
}
