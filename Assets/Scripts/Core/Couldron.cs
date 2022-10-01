using ScriptableObjects;
using UnityEngine;

public class Couldron : Receptacle
{
    [SerializeField] private SpellData spellToBeCreated;
    
    public SpellData SpellToBeCreated
    {
        get => spellToBeCreated;
        set => spellToBeCreated = value;
    }
    
}
