using System;
using System.Collections.Generic;
using Events;
using Ingredients;
//using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class Cauldron : Receptacle
    {
        public List<Ingredient> _ingredients;
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if(other.GetComponent<Ingredient>())
            {
                GameEvents.OnIngredientEnterCauldronEvent?.Invoke(other.GetComponent<Ingredient>());
                _ingredients.Add(other.GetComponent<Ingredient>());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.GetComponent<Ingredient>())
            {
                GameEvents.OnIngredientExitCauldronEvent?.Invoke(other.GetComponent<Ingredient>());
                _ingredients.Remove(other.GetComponent<Ingredient>());
            }
        }

        void DestroyItemsInCauldron()
        {
            foreach (var i in _ingredients)
            {
                Destroy(i.gameObject);
            }
            _ingredients.Clear();
        }
    }
}
