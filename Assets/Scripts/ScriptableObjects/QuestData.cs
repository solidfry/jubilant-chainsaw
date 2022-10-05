using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Quest_", menuName = "Quests/New Quest", order = 0)]
    public class QuestData : ScriptableObject
    {
        [SerializeField] private Dialogues questTextList;
        [SerializeField] private SpellData questSolution;
        
        public SpellData QuestSolution => questSolution;
        public string GetRandomDialogue() => questTextList.list[Random.Range(0, questTextList.list.Count)];
    }
}