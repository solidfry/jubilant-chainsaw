using System;
using Events;
using Ingredients;
//using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class Cauldron : Receptacle
    {
//        [SerializeField] private SpellList listOfSpells;
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if(other.GetComponent<Ingredient>())
                GameEvents.OnIngredientEnterCauldronEvent?.Invoke(other.GetComponent<Ingredient>());
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.GetComponent<Ingredient>())
                GameEvents.OnIngredientExitCauldronEvent?.Invoke(other.GetComponent<Ingredient>());
        }
    }
}
