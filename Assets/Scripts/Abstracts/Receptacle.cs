using Ingredients;
using ScriptableObjects;
using UnityEngine;

namespace Abstracts
{
    public abstract class Receptacle : MonoBehaviour
    {
        [SerializeField] private ConstructionMaterialType constructionMaterial;
        public ConstructionMaterialType ConstructionMaterial => constructionMaterial;
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Ingredient>())
            {
                other.transform.parent = transform;
            }
        }

    }
}