using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ToggleUIElement : MonoBehaviour
    {
        [SerializeField] GameObject uiPrefab;
        [SerializeField] Button button;
        [SerializeField] private float animationDuration = .2f;
        [SerializeField] private float scaleFactor = 1.1f;
        private void OnEnable()
        {
            button.onClick.AddListener(Toggle);
        }
    
        private void OnDisable()
        {
            button.onClick.RemoveListener(Toggle);
        }
    
        void Toggle()
        {
            if (uiPrefab.activeInHierarchy)
            {
                Tween fade = uiPrefab.GetComponent<CanvasGroup>().DOFade(0, animationDuration);
                Tween scale = uiPrefab.transform.DOScale(Vector3.one / scaleFactor, animationDuration);
                scale.OnComplete(() => { uiPrefab.SetActive(false); });
            }
            else
            {
                uiPrefab.transform.localScale = Vector3.one / scaleFactor;
                uiPrefab.GetComponent<CanvasGroup>().DOFade(1, animationDuration);
                uiPrefab.transform.DOScale(Vector3.one, animationDuration);
                uiPrefab.SetActive(true);
            }
        }
        
    }
}
