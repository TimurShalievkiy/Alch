using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProcess : MonoBehaviour {
    public Camera camera;

    public GameObject gridSequence;
    public GameObject ConteinerIngr;
    public static Recipe recipe;
    // Use this for initialization
    void Start () {
       // LoadIngrInSequence();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void LoadIngrInSequence()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
           int id = System.Convert.ToInt32( hit.collider.gameObject.transform.name);

            foreach (Recipe r in ListRecipes.recipes)
            {
                if (r.Id == id)
                {
                    recipe = new Recipe(r.Id,r.MassIngr);
                };
            }
        }
        for (int i = 0; i < gridSequence.transform.childCount; i++)
            Destroy(gridSequence.transform.GetChild(i).gameObject);

            for (int i = 0; i < recipe.MassSize; i++)
            {
                var a = Instantiate(ConteinerIngr, gridSequence.transform.position, Quaternion.identity);
                a.transform.SetParent(gridSequence.transform);
                a.transform.localScale = new Vector3(1, 1, 1);
            }
            Debug.Log("id recipe = " + recipe.Id);
        
    }

}
