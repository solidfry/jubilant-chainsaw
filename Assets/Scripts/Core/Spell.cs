using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class Spell : MonoBehaviour
    {
        [ReadOnly][SerializeField] private SpellData spellType;
        private Rigidbody2D _rb;
        
        public SpellData SpellType
        {
            get => spellType;
            set => spellType = value;
        }

        private void OnEnable()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }
        
    }
}