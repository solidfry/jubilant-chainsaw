using System;
using System.Collections;
using DG.Tweening;
using Events;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : Destroyable
    {
        [SerializeField] private IngredientType ingredientType;

        [Header("Sprite Settings")]
        [ReadOnly]
        public SpriteRenderer spriteRenderer;
        public PolygonCollider2D polyCollider;

        public IngredientType IngredientType
        {
            get => ingredientType;
            set => ingredientType = value;
        }

        private void Awake()
        {
            UpdateValues();
        }

        private void OnValidate()
        {
            UpdateValues();
        }

        private void Update()
        {
            if (gameObject.transform.position.y < -5)
            {
                Destroy(gameObject);
            }
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
            else
            {
                spriteRenderer = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            }

            if (spriteRenderer != null)
                spriteRenderer.sprite = data.sprite;
        }

        public override IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(.5f);
            var particle = Instantiate(particleOnDestroy, this.transform.position, Quaternion.identity);
            Debug.Log("Particle is instantiated");
            this.transform.DOScale(Vector3.zero, animationFadeOutTime);
            spriteRenderer.DOFade(0, animationFadeOutTime);
            Destroy(particle, 2f);
        }

        public override void DoDestroy()
        {
            StartCoroutine(DelayedDestroy());
        }

        private void OnDestroy()
        {
            GameEvents.OnIngredientDestroyedEvent?.Invoke();
        }
    }
}