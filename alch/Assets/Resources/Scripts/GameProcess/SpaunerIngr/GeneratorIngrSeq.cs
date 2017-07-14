using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorIngrSeq : MonoBehaviour
{

    public float ingrDelay;
    public GameObject conteiner;

    int preIng = -1;
    int prePreIngr = -1;
    int iter = 0;

    public bool falseIngr;
    public void ResetSequensParametrs()
    {
        iter = -1;
        preIng = -1;
        prePreIngr = -1;
    }
    public void Repeat()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(ingrDelay);


        GameObject g = Instantiate(conteiner, transform.position, Quaternion.identity);
        if(Random.Range(0, 100) < 10)
            falseIngr = true;

        //Destroy(g, 20);
        if (falseIngr)
        {
            g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(CookingProcess.recipe.MassIngr[Random.Range(0, CookingProcess.recipe.MassIngr.Length)]));
            g.GetComponent<Image>().color = Color.red;
                g.name = (-2).ToString();
            g.transform.SetParent(this.transform);

            g.GetComponent<Rigidbody2D>().mass = 0;
            g.GetComponent<Rigidbody2D>().gravityScale = 0;
            falseIngr = false;
        }
        else
        {

            if (preIng == -1 && prePreIngr == -1)
            {
                iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);
                preIng = CookingProcess.recipe.MassIngr[iter];
                Debug.Log("#1# " + CookingProcess.recipe.MassIngr[iter] + " " + preIng + " " + prePreIngr);
            }
            else if (preIng != -1 && prePreIngr == -1)
            {
                iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);

                prePreIngr = preIng;
                preIng = CookingProcess.recipe.MassIngr[iter];

                Debug.Log("#2# " + iter + " " + preIng + " " + prePreIngr);
            }
            else
            {

                while (true)
                {
                    iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);
                    if (CookingProcess.recipe.MassIngr[iter] != preIng && CookingProcess.recipe.MassIngr[iter] != prePreIngr)
                        break;
                }
                Debug.Log("#3# " + CookingProcess.recipe.MassIngr[iter] + " " + preIng + " " + prePreIngr);

                prePreIngr = preIng;
                preIng = CookingProcess.recipe.MassIngr[iter];


                g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(CookingProcess.recipe.MassIngr[iter]));
                g.name = CookingProcess.recipe.MassIngr[iter].ToString();
                g.transform.SetParent(this.transform);

                g.GetComponent<Rigidbody2D>().mass = 0;
                g.GetComponent<Rigidbody2D>().gravityScale = 0;


            }


        }

        Repeat();
    }
}
