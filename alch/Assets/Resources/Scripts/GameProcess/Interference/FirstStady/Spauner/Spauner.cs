using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spauner : MonoBehaviour {

    //работает ли спавнер
    public bool working;

    public float chans;

    public GameObject spawnObj;

    public float timeDelay;

    public int xForse;

    public int yForse;

    float currentTimeDelay;



    void Update () {
        //если работает
        if (working)
        {
            //если время задержки закончилось
            if (currentTimeDelay <= 0)
            {
                //метод спавна обьекта
                SpawnObj();
                currentTimeDelay = timeDelay;
            }
            else
                currentTimeDelay -= Time.deltaTime;

        }
		
	}


    //сложность спавнеров
    public void SetSpawnerHard(float chans, float timeDelay)
    {
        this.chans = chans;
        this.timeDelay = timeDelay;
    }

    public void SpawnObj()
    {
        //шанс на спавн обьекта 
        if (Random.Range(1, 100) <= chans)
        {
            //создание нового обькта 
            GameObject g = Instantiate(spawnObj, transform.position,Quaternion.identity );
            GetItemFromList(ref g);


            //назначение родительским элементом этот обьект
        g.transform.SetParent(this.transform);
        g.gameObject.SetActive(true);

           //переменные поправок для 3 разных направлений
            int x = 0;
            int y = 0;
            int z = 1;
            //выбор направления и задание поправок
            switch (Random.Range(0, 3))
            {
                case 0:
                    Debug.Log(0);
                    if (xForse > 0)
                    {
                        x = -100;
                        y = 100;
                        z = -z;
                    }
                    else {
                        x = 100;
                        y = 100;
                    }
                    break;
                case 1:
                    Debug.Log(1);
                    break;
                case 2:
                    Debug.Log(2);
                    if (xForse > 0)
                    {
                        x = +100;
                        y = -100;
                        z = -z;
                    }
                    else
                    {
                        x = -100;
                        y = -100;
                    }
                    break;
            }

            //придание импульса с поправками
            g.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForse + x, yForse + y), ForceMode2D.Impulse);
            g.GetComponent<Rigidbody2D>().AddTorque(100000f,ForceMode2D.Force);
            g.name = "-2";
         }

    }

    public void GetItemFromList(ref GameObject g)
    {

        int x = Random.Range(0, 100);

        if (x < 50)
        {
           g.GetComponent< SpawnObjInterf>().helth = ListInterfSprites.listInterfItem[0].helth;
            g.GetComponent<Image>().sprite = Resources.Load < Sprite > (ListInterfSprites.listInterfItem[0].spr);
        }
        else if (x >= 50 && x < 80)
        {
            g.GetComponent<SpawnObjInterf>().helth = ListInterfSprites.listInterfItem[1].helth;
            g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListInterfSprites.listInterfItem[1].spr);
        }
        else if (x >= 80 && x < 100)
        {
            g.GetComponent<SpawnObjInterf>().helth = ListInterfSprites.listInterfItem[2].helth;
            g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListInterfSprites.listInterfItem[2].spr);
        }
    }
}
