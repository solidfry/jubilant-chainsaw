using System.Collections.Generic;
using Events;
using Ingredients;
using UnityEngine;

namespace Core
{
    public class Cauldron : Receptacle
    {
        [SerializeField] private List<Ingredient> ingredients;

        private void OnEnable()
        {
            GameEvents.OnDestroyCauldronItemsEvent += DestroyItemsInCauldron;
        }
        
        private void OnDisable()
        {
            GameEvents.OnDestroyCauldronItemsEvent -= DestroyItemsInCauldron;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if(other.GetComponent<Ingredient>())
            {
                GameEvents.OnIngredientEnterCauldronEvent?.Invoke(other.GetComponent<Ingredient>());
                ingredients.Add(other.GetComponent<Ingredient>());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.GetComponent<Ingredient>())
            {
                GameEvents.OnIngredientExitCauldronEvent?.Invoke(other.GetComponent<Ingredient>());
                ingredients.Remove(other.GetComponent<Ingredient>());
            }
        }

        void DestroyItemsInCauldron()
        {
            var children = this.GetComponentsInChildren<Transform>();
            foreach (var i in children)
            {
                if (i != children[0])
                    Destroy(i.gameObject, .5f);
            }
        }
    }
}
