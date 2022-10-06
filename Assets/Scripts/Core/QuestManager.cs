using System;
using Events;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private QuestList allQuests;
        [SerializeField] private QuestData questData;
        [SerializeField] private SpellData expectedSpell;
        [SerializeField] private int toCompleteLevel;
        [ReadOnly][SerializeField] private int customersServed;

        private void Start()
        {
            if (allQuests == null)
                return;

            GetNewQuest();
        }

        private void OnEnable()
        {
            GameEvents.OnCelebrationEvent += IncrementCustomers;
            GameEvents.OnQuestCompletedEvent += SetQuest;
        }

        private void OnDisable()
        {
            GameEvents.OnCelebrationEvent -= IncrementCustomers;
            GameEvents.OnQuestCompletedEvent -= SetQuest;
        }

        private void SetQuest() => GetNewQuest();

        private void GetNewQuest()
        {
            if (customersServed == toCompleteLevel)
            {
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
            }
            else
            {
                var newQuest = allQuests.GetRandomQuest();
                questData = newQuest;

                if (newQuest is not null)
                {
                    expectedSpell = newQuest.QuestSolution;
                    var dialogue = newQuest.GetRandomDialogue();
                    GameEvents.OnGetNewQuestEvent?.Invoke(expectedSpell, dialogue);
                }
            }
        }

        private void IncrementCustomers()
        {
            customersServed++;
        }
    }
}