using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "_SpellList", menuName = "Spells/New Spell List", order = 0)]
    public class SpellList : ScriptableObject
    {
        [SerializeField] private List<SpellData> listOfSpells;

        public List<SpellData> ListOfSpells
        {
            get => listOfSpells;
            private set => listOfSpells = value;
        }
    }
}