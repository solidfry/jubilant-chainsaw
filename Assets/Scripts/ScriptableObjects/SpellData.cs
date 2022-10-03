using System.Collections.Generic;
using Recipe;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "_Spell", menuName = "Spells/New Spell", order = 0)]
    public class SpellData : ScriptableObject
    {
        public new string name;
        [TextArea]
        public string description;
        public Sprite sprite;
        [SerializeField] private List<IngredientType> recipe;

        public List<IngredientType> Recipe => recipe;
    }
}