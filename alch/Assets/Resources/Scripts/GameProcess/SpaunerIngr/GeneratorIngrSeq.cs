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

    //public bool falseIngr;

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

        //Вставка обьекта ингредиента
        GameObject g = Instantiate(conteiner, transform.position, Quaternion.identity);
        g.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height / 6, Screen.height / 6);

        //шанс создания ложного ингредиента
        // if (Random.Range(0, 100) < 10)
        //      falseIngr = true;

        ////если ложный ингредиент
        //if (falseIngr)
        //{
        //    g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(CookingProcess.recipe.MassIngr[Random.Range(0, CookingProcess.recipe.MassIngr.Length)]));
        //    g.GetComponent<Image>().color = Color.red;

        //    g.name = (-2).ToString();

        //    g.transform.SetParent(this.transform);

        //    g.GetComponent<Rigidbody2D>().mass = 0;
        //    g.GetComponent<Rigidbody2D>().gravityScale = 0;
        //    falseIngr = false;
        //}
        //если обычный ингредиент
        //else
        //{


        //первый появившейся
        if (preIng == -1 && prePreIngr == -1)
        {
            iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);

            while (true)
            {
                iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);
                if (CookingProcess.recipe.MassIngr[iter] != 0 && CookingProcess.recipe.MassIngr[iter] != 1)
                        break;
            }

            preIng = CookingProcess.recipe.MassIngr[iter];
        }
        //Второй ингредиент
        else if (preIng != -1 && prePreIngr == -1)
        {
            while (true)
            {
                iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);
                if (CookingProcess.recipe.MassIngr[iter] != 0 && CookingProcess.recipe.MassIngr[iter] != 1)
                    break;
            }

            prePreIngr = preIng;
            preIng = CookingProcess.recipe.MassIngr[iter];
        }
        //после второго
        else
        {
            //Генерация индентификатора пока не будет не таким же как 2 предыдущих
            while (true)
            {
                iter = Random.Range(0, CookingProcess.recipe.MassIngr.Length);

                if (CookingProcess.recipe.MassIngr[iter] != 0 && CookingProcess.recipe.MassIngr[iter] != 1)
                    if (CookingProcess.recipe.MassIngr[iter] != preIng && CookingProcess.recipe.MassIngr[iter] != prePreIngr)
                        break;
            }

            prePreIngr = preIng;
            preIng = CookingProcess.recipe.MassIngr[iter];
        }


        g.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(CookingProcess.recipe.MassIngr[iter]));
        g.name = CookingProcess.recipe.MassIngr[iter].ToString();
        g.transform.SetParent(this.transform);

        g.GetComponent<Rigidbody2D>().mass = 0;
        g.GetComponent<Rigidbody2D>().gravityScale = 0;


        // }

        Repeat();
    }
}
