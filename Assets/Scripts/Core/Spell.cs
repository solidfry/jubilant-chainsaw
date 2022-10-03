using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class Spell : MonoBehaviour
    {
        [ReadOnly][SerializeField] private SpellData spellType;

        public SpellData SpellType
        {
            get => spellType;
            set => spellType = value;
        }
    }
}