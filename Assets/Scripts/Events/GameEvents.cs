using Ingredients;
using ScriptableObjects;
using UnityEngine;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public delegate void PlayClip(AudioClip clip);
        public static PlayClip OnAudioCollisionEvent;
        
        //Cauldron mechanics
        public delegate void AddIngredient(Ingredient ingredient);
        public delegate void RemoveIngredient(Ingredient ingredient);
        public delegate void DestroyCauldronItems();
        
        public static AddIngredient OnIngredientEnterCauldronEvent;
        public static RemoveIngredient OnIngredientExitCauldronEvent;
        public static DestroyCauldronItems OnDestroyCauldronItemsEvent;
        
        //Quest Events
        public delegate void GetNewQuest(SpellData spellData, string dialogue);
        public delegate void QuestCompleted();
        public delegate void Celebration();
        public delegate void IngredientDestroyed();
        
        public static GetNewQuest OnGetNewQuestEvent;
        public static QuestCompleted OnQuestCompletedEvent;
        public static Celebration OnCelebrationEvent;
        public static IngredientDestroyed OnIngredientDestroyedEvent;
    }
}
