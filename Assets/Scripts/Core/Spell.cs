using System.Collections;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using TMPro;

namespace Core
{
    public class Spell : Destroyable
    {
        [ReadOnly][SerializeField] private SpellData spellType;
        private Rigidbody2D _rb;
        public TMP_Text titleText;

        SpriteRenderer _sr;
        Vector3 _originalScale;

        public SpellData SpellType
        {
            get => spellType;
            set
            {
                spellType = value; 
                titleText.text = spellType.name;
            }
        }

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _originalScale = transform.localScale;
        }
        private void OnEnable()
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.DOScale(_originalScale, .5f).SetEase(Ease.OutBounce);
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
            
        }

        public override IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(.5f);
            var particle = Instantiate(particleOnDestroy, this.transform.position, Quaternion.identity);
            Debug.Log("Particle is instantiated");
            this.transform.DOScale(Vector3.zero, animationFadeOutTime);
            _sr.DOFade(0, animationFadeOutTime);
            Destroy(particle, 2f);
            Destroy(this.gameObject, 2.1f);
        }

        public override void DoDestroy()
        {
            StartCoroutine(DelayedDestroy());
        }



    }
}