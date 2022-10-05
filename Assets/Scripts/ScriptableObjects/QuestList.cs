using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "_QuestList", menuName = "Quests/New Quest List", order = 0)]
    public class QuestList : ScriptableObject
    {
        [SerializeField] private List<QuestData> listOfQuests;

        public List<QuestData> ListOfQuests => listOfQuests;

        public QuestData GetRandomQuest() => listOfQuests[Random.Range(0, listOfQuests.Count)];
    }
}