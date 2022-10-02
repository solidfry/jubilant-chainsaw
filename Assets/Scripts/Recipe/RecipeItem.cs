using System;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace Recipe
{
    [Serializable]
    public struct RecipeItem
    {
        
        [SerializeField] public IngredientType ingredientType;
        [SerializeField] public int requirement;
        
        public RecipeItem(IngredientType ingredientType, int requirement)
        {
            this.ingredientType = ingredientType;
            this.requirement = requirement;
        }
    }
}