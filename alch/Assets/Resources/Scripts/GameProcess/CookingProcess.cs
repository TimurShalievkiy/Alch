using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProcess : MonoBehaviour
{
    public Camera camera;

    public GameObject gridSequence;
    public GameObject ConteinerIngr;
    public static Recipe recipe;
    public int currentIngr;


    bool readyToAddIngr;


    int R;
    int G;
    int B;
    // Use this for initialization
    void Start()
    {
        readyToAddIngr = true;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Cooking()
    {

    }
    //добавление ингредиента для обработки 
    public void AddIngredientToKattle()
    {
        if (readyToAddIngr)
        {
            ListIngredient.ingredients[currentIngr].GetRGBIngr(out R,out G,out B);
            Debug.Log("R = " + R);
            Debug.Log("G = " + G);
            Debug.Log("B = " + B);
            readyToAddIngr = false;
        }
    }


    //инициализация процесса готовки.
    public void LoadIngrInSequence()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //получение ID рецепта по которому нажал пользователь
        if (hit.collider != null)
        {
            int id = System.Convert.ToInt32(hit.collider.gameObject.transform.name);

            foreach (Recipe r in ListRecipes.recipes)
            {
                if (r.Id == id)
                {
                    recipe = new Recipe(r.Id, r.MassIngr);
                    break;
                };
            }
        }
        //удаление дочерних єлементов из очереди.
        for (int i = 0; i < gridSequence.transform.childCount; i++)
            Destroy(gridSequence.transform.GetChild(i).gameObject);

        currentIngr = recipe.MassIngr[0];

        //Создание дочерних єлементов в очереди ингредиентов
        for (int i = 0; i < recipe.MassSize; i++)
        {
            var a = Instantiate(ConteinerIngr, gridSequence.transform.position, Quaternion.identity);
            a.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredient.GetSpritePassById(recipe.MassIngr[i]));
            a.name = recipe.MassIngr[i].ToString();
            a.transform.SetParent(gridSequence.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
