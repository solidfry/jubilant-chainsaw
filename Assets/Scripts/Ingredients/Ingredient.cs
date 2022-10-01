using System;
using ScriptableObjects.Ingredients;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [FormerlySerializedAs("_ingredientType")] [SerializeField] private IngredientType ingredientType;
        
        [Header("Sprite Settings")]
        [ReadOnly]
        public SpriteRenderer spriteRenderer;

        public PolygonCollider2D polyCollider;
        private void Awake()
        {
            UpdateValues();
        }

        private void OnValidate()
        {
            UpdateValues();
        }

        void UpdateValues()
        {
            UpdateColliders();
            UpdateSpriteRenderer(ingredientType);
        }

        private void UpdateColliders()
        {
            polyCollider = GetComponent<PolygonCollider2D>();
            
            if (polyCollider == null)
            {
                _ = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
                Debug.Log("added polygon col");
            }
        }

        private void UpdateSpriteRenderer(IngredientType data)
        {
            if (GetComponent<SpriteRenderer>())
                spriteRenderer = GetComponent<SpriteRenderer>();
            else {
                spriteRenderer = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            }

            if (spriteRenderer != null)
                spriteRenderer.sprite = data.sprite;
        }

        private void Update()
        {
            if (gameObject.transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        }

    }
}