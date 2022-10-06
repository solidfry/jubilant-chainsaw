using System.Collections;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class Spell : Destroyable
    {
        [ReadOnly][SerializeField] private SpellData spellType;
        private Rigidbody2D _rb;

        SpriteRenderer sr;
        Vector3 originalScale;


        public SpellData SpellType
        {
            get => spellType;
            set => spellType = value;
        }

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            originalScale = transform.localScale;
        }
        private void OnEnable()
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.DOScale(originalScale, .5f);
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }

        public override IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(.5f);
            var particle = Instantiate(particleOnDestroy, this.transform.position, Quaternion.identity);
            Debug.Log("Particle is instantiated");
            this.transform.DOScale(Vector3.zero, animationFadeOutTime);
            sr.DOFade(0, animationFadeOutTime);
            Destroy(particle, 2f);
        }

        public override void DoDestroy()
        {
            StartCoroutine(DelayedDestroy());
        }



    }
}