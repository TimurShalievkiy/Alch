﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesSelector : MonoBehaviour
{
    

    public void GetResipeId()
    {

        int id = System.Convert.ToInt32(this.gameObject.transform.name);

        foreach (Recipe r in ListRecipes.recipes)
        {
            if (r.Id == id)
            {             
                CookingProcess.recipe = new Recipe(r.Id,r.idPotion,r.price,r.spritePas,r.listReferences, r.MassIngr);
                CookingProcess.firstStady = true;
                break;
            };
        }

    }
}
