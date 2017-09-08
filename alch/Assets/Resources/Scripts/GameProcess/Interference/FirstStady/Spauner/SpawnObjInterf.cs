using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjInterf : MonoBehaviour  {

    //количество здоровья
    public int helth = 1;



    public float xVal;
    public float yVal;
    public int way;
    public float pVal;
    public float heightScale;
    public float movementSpeed;

    public void InitObj(float xVal,float yVal, int way,
    float pVal,
    float heightScale,
    float movementSpeed)
    {
        this.xVal = xVal;
        this.yVal = yVal;
        this.way = way;
        this.pVal = pVal;
        this.heightScale = heightScale;
        this.movementSpeed = movementSpeed;
    }
    private void Start()
    {
        this.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
    void FixedUpdate()
    {
        xVal = this.transform.localPosition.x - (Time.deltaTime * movementSpeed * way);
        yVal = way * pVal * heightScale * xVal;

        this.transform.Rotate(0, 0, this.transform.localRotation.z + Time.deltaTime * way * 3, 0);
        this.transform.localPosition = new Vector3(xVal, Mathf.Sqrt(yVal), 0);
    }
    //Нанесение урона по обьекту
    public void DoDamag()
    {
       // Debug.Log("DoDamag");

        helth--;
        if (helth <= 0)
            Destroy(this.gameObject);
    }
}
