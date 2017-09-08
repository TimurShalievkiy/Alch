using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesSelector : MonoBehaviour
{
    

    public void GetResipeId()
    {

        int id = System.Convert.ToInt32(this.transform.parent.gameObject.transform.name);
       // Debug.Log(id);
        foreach (Recipe r in ListRecipes.recipes)
        {
            if (r.Id == id)
            {             
                CookingProcess.recipe = new Recipe(r.Id,r.idPotion,r.price,r.spritePas,r.listInterferences, r.MassIngr);
                CookingProcess.recipe.IsOpen = true;
                CookingProcess.firstStady = true;
                break;
            };
        }

    }
}
