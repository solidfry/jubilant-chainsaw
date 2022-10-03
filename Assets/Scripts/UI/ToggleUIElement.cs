using UnityEngine;
using UnityEngine.UI;

public class ToggleUIElement : MonoBehaviour
{
    [SerializeField] GameObject uiPrefab;
    [SerializeField] Button button;

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
            uiPrefab.SetActive(false);
        }
        else
        {
            uiPrefab.SetActive(true);
        }
    }
}
