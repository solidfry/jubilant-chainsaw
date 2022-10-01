using UnityEngine;

namespace ScriptableObjects.Ingredients
{
    [CreateAssetMenu(fileName = "_IngredientType", menuName = "Spells/New IngredientType", order = 0)]

    public class IngredientType : ScriptableObject
    {
        public new string name;
        public GameObject prefab;
        public Sprite sprite;
    }
}