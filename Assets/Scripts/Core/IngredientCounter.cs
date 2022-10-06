using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class IngredientCounter : MonoBehaviour
    {
        [SerializeField] private int ingredientCount = 4;
        
        private void OnEnable()
        {
            GameEvents.OnIngredientDestroyedEvent += DecrementIngredientCount;
        }

        private void OnDisable()
        {
            GameEvents.OnIngredientDestroyedEvent -= DecrementIngredientCount;
        }

        // Update is called once per frame
        void Update()
        {
            if (ingredientCount == 0)
                SceneManager.LoadScene("GameFail", LoadSceneMode.Additive);
        }

        void DecrementIngredientCount() => ingredientCount--;
        
    }
}
