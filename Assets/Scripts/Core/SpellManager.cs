using System.Collections.Generic;
using Events;
using Ingredients;
using Recipe;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] 
        private List<RecipeItem> ingredientsInCauldron;
        [SerializeField] private SpellList spells;

        private void OnEnable()
        {
            GameEvents.OnIngredientEnterCauldronEvent += Add;
            GameEvents.OnIngredientExitCauldronEvent += Remove;
        }

        private void OnDisable()
        {
            GameEvents.OnIngredientEnterCauldronEvent -= Add;
            GameEvents.OnIngredientExitCauldronEvent -= Remove;
        }

        public void Add(Ingredient ingredient)
        {
            ingredientsInCauldron.Add(new RecipeItem(ingredient.IngredientType, 1));
        }

        public void Remove(Ingredient ingredient)
        {
            RecipeItem i = ingredientsInCauldron.Find(i => i.ingredientType == ingredient.IngredientType);
            ingredientsInCauldron.Remove(i);
        }

        public void Conjure()
        {
            if (spells.ListOfSpells.Find(i => i.Recipe == ingredientsInCauldron))
            {
//                foreach ()
//                {
//                    
//                }
                //Instantiate the spell gameObject
            }
        }
    }
}