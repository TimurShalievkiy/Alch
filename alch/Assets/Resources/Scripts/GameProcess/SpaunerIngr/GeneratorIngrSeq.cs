using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorIngrSeq : MonoBehaviour
{

    public float ingrDelay;
    public GameObject conteiner;
    int iter = 0;
    // Update is called once per frame

    //void Start()
    //{
    //    StartCoroutine(Spawn());
    //    Debug.Log(123123);
    //}
   public  void Repeat()
    {
        StartCoroutine(Spawn());
    }
     IEnumerator Spawn()
    {
        yield return new WaitForSeconds(ingrDelay);


        GameObject g = Instantiate(conteiner, transform.position, Quaternion.identity);

        //Destroy(g, 20);

        iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);

        g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(CookingProcess.recipe.MassIngr[iter]));
        g.name = CookingProcess.recipe.MassIngr[iter].ToString();
        g.transform.SetParent(this.transform);

        g.GetComponent<Rigidbody2D>().mass = 0;
        g.GetComponent<Rigidbody2D>().gravityScale = 0;



        Repeat();
    }
}
