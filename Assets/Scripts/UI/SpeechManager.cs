using System.Collections;
using DG.Tweening;
using Events;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SpeechManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text textField;
        [Header("Animation Settings")]
        [SerializeField] private float initialDelay;
        [Header("Replacement Variables")]
        private CanvasGroup _canvasGroup;
        private RectTransform _speechBubbleRect;
        private Vector3 _rectPos;
        private Vector3 _originalPos;

        private void Awake()
        {
            _speechBubbleRect = this.gameObject.GetComponent<RectTransform>();
            _rectPos = _speechBubbleRect.localPosition;
            _originalPos = _rectPos;
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }

        private void OnEnable()
        {
            GameEvents.OnGetNewQuestEvent += NewQuestDialogue;
            GameEvents.OnCelebrationEvent += AnimateOut;
        }

        private void OnDisable()
        {
            DOTween.RewindAll();
            GameEvents.OnGetNewQuestEvent -= NewQuestDialogue;
            GameEvents.OnCelebrationEvent -= AnimateOut;
        }

        private void NewQuestDialogue(SpellData spelldata, string dialogue)
        {
            textField.text = dialogue;
            StartCoroutine(AnimateIn());
        }

        IEnumerator AnimateIn()
        {
            yield return new WaitForSeconds(initialDelay);
            _canvasGroup.alpha = 0;
            _speechBubbleRect.localScale = new Vector3(.5f, .5f, .5f);
            _speechBubbleRect.DOLocalMoveY(_rectPos.y + 20, 2f).SetEase(Ease.OutElastic);
            _speechBubbleRect.DOScale(1, 2f).SetEase(Ease.OutElastic);
            _canvasGroup.DOFade(1, .2f);
        }

        void AnimateOut()
        {
            _speechBubbleRect.transform.DOLocalMoveY(_originalPos.y, .2f);
            _canvasGroup.DOFade(0, .2f);
        }
    }


}
