using System;
using Events;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private QuestList allQuests;
        [SerializeField] private QuestData questData;
        [SerializeField] private SpellData expectedSpell;
        
        private void Start()
        {
            if(allQuests == null)
                return;
            
            GetNewQuest();
        }
        
        private void OnEnable()
        {
            GameEvents.OnQuestCompletedEvent += SetQuest;
        }

        private void OnDisable()
        {
            GameEvents.OnQuestCompletedEvent -= SetQuest;
        }
        
        private void SetQuest() => GetNewQuest();
        
        private void GetNewQuest()
        {
            var newQuest = allQuests.GetRandomQuest();
            questData = newQuest;
            
            if(newQuest is not null)
            {
                expectedSpell = newQuest.QuestSolution;
                var dialogue = newQuest.GetRandomDialogue();
                GameEvents.OnGetNewQuestEvent?.Invoke(expectedSpell, dialogue);
            }
        }
    }
}