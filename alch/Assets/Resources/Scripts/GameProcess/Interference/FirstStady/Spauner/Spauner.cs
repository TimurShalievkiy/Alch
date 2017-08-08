using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spauner : MonoBehaviour
{

    //работает ли спавнер
    public bool working;

    public float chans;

    public GameObject spawnObj;

    public float timeDelay;

    public int way;

    public int yForse;

    float currentTimeDelay;
    public GameObject kattle;

    public float heightScale;
    public float pVal;
    public float movementSpeed;

    float xVal = 0;
    float yVal = 0;

    public static List<GameObject> ListSpawnObj;

    private void Start()
    {
        ListSpawnObj = new List<GameObject>();
        pVal = 2;
    }

    void FixedUpdate()
    {
        //если работает
        if (working)
        {
            //  if (ListSpawnObj.Count > 0)
            //  MoveSpawnObject();
            //если время задержки закончилось
            if (currentTimeDelay <= 0)
            {
                //метод спавна обьекта
                //SpawnObj();
                SpawnObjByParabola();

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

    double sqrtX;
    public void MoveSpawnObject()
    {

        foreach (GameObject item in ListSpawnObj)
        {

            xVal = item.transform.localPosition.x - (Time.deltaTime * movementSpeed * way);

            yVal = way * pVal * heightScale * xVal;


            item.transform.localPosition = new Vector3(xVal, Mathf.Sqrt(yVal), 0);
        }

    }
    public void SpawnObjByParabola()
    {
        //шанс на спавн обьекта 
        if (Random.Range(1, 100) <= chans)
        {
            float x = Screen.width / 2 + Screen.width * way;
            float y = heightScale * way * pVal * x;
            //создание нового обькта 

            GameObject g = Instantiate(spawnObj);
            g.GetComponent<SpawnObjInterf>().InitObj(x, y, way, pVal, heightScale, movementSpeed);
            g.transform.localPosition = new Vector2(x, y);

            GetItemFromList(ref g);


            //назначение родительским элементом этот обьект
            g.transform.SetParent(this.transform);
            g.gameObject.SetActive(true);


            g.name = "-2";
            ListSpawnObj.Add(g);
        }
    }


    public void SpawnObj()
    {
        //шанс на спавн обьекта 
        if (Random.Range(1, 100) <= chans)
        {
            //создание нового обькта 
            GameObject g = Instantiate(spawnObj, transform.position, Quaternion.identity);
            GetItemFromList(ref g);


            //назначение родительским элементом этот обьект
            g.transform.SetParent(this.transform);
            g.gameObject.SetActive(true);

            float pos = 0;

            if (kattle)
                pos = Vector2.Distance(this.transform.position, kattle.transform.position);
            // Debug.Log(pos);


            //придание импульса с поправками
            //  g.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForse + x, yForse + y), ForceMode2D.Impulse);
            g.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos * way, Screen.height / yForse), ForceMode2D.Impulse);
            g.GetComponent<Rigidbody2D>().AddTorque(100000f, ForceMode2D.Force);
            g.name = "-2";
        }

    }

    public void GetItemFromList(ref GameObject g)
    {

        int x = Random.Range(0, 100);

        if (x < 50)
        {
            g.GetComponent<SpawnObjInterf>().helth = ListInterfSprites.listInterfItem[0].helth;
            g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListInterfSprites.listInterfItem[0].spr);
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


    public static void DeleteFromList(GameObject g)
    {
        ListSpawnObj.Remove(g);
        Destroy(g);
    }
    public static void DeleteAllFromList()
    {
        if (ListSpawnObj != null)
        {
            foreach (GameObject item in ListSpawnObj)
            {
                // ListSpawnObj.Remove(item);
                Destroy(item);
            }
            ListSpawnObj = new List<GameObject>();
        }
    }
}
