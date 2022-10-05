using Ingredients;
using ScriptableObjects;
using UnityEngine;

namespace Events
{
    public class GameEvents : MonoBehaviour
    {
        public delegate void Collect();
        public delegate void PlayClip(AudioClip clip);
        public delegate void StartTimer();
        public delegate void TimerZero();
        public delegate void ResetTimer();

        

        public static Collect OnCollectablePickedUp;
        public static PlayClip OnAudioCollisionEvent;
        public static StartTimer OnStartTimerEvent;
        public static TimerZero OnTimerZeroEvent;
        public static ResetTimer OnResetTimerEvent;
        
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
        
        public static GetNewQuest OnGetNewQuestEvent;
        public static QuestCompleted OnQuestCompletedEvent;
        public static Celebration OnCelebrationEvent;
    }
}
