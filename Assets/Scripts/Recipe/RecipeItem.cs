using System;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace Recipe
{
    [Serializable]
    public struct RecipeItem : IEquatable<RecipeItem>
    {
        
        [SerializeField] public IngredientType ingredientType;
        [SerializeField] public int requirement;
        
        public RecipeItem(IngredientType ingredientType, int requirement)
        {
            this.ingredientType = ingredientType;
            this.requirement = requirement;
        }
        
        public bool Equals(RecipeItem other)
        {
            return this.ingredientType.name == other.ingredientType.name && this.requirement == other.requirement;
        }
    }
}