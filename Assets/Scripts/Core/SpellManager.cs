using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Events;
using Ingredients;
using ScriptableObjects;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace Core
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField] 
        private List<IngredientType> ingredientsInCauldron;
        [SerializeField] private SpellList spells;
        [SerializeField] private GameObject spellItemPrefab;

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
            ingredientsInCauldron.Add(ingredient.IngredientType);
            Conjure();
//            GameEvents.OnDestroyCauldronItemsEvent?.Invoke();
        }

        public void Remove(Ingredient ingredient)
        {
            IngredientType i = ingredientsInCauldron.Find(i => i == ingredient.IngredientType);
            ingredientsInCauldron.Remove(i);
        }

        IEnumerator DelayConjure(SpellData spellData)
        {
            yield return new WaitForSeconds(1f);
            var spellObject = Instantiate(spellItemPrefab, new Vector3(0,1f), Quaternion.identity);
            spellObject.GetComponent<Spell>().SpellType = spellData;
        }

        public void Conjure()
        {
            var cauldronIngredientNames = ingredientsInCauldron.Select(x => x.name).ToList();
            var filterSpells = spells.ListOfSpells.Where(x => x.Recipe.All(y => cauldronIngredientNames.Contains(y.name))).ToList();
            var spellToConjure = filterSpells.Count > 0 ? filterSpells[0] : null;

            if(spellToConjure != null)
            {
                StartCoroutine(DelayConjure(spellToConjure));
//                var spellObject = Instantiate(spellItemPrefab, new Vector3(0,1f), Quaternion.identity);
//                spellObject.GetComponent<Spell>().SpellType = spellToConjure;
                
                cauldronIngredientNames.Clear();
                filterSpells.Clear();
                GameEvents.OnDestroyCauldronItemsEvent?.Invoke();
                ingredientsInCauldron.Clear();
            }
            
        }
    }
}