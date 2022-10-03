using ScriptableObjects;
using TMPro;
using UnityEngine;

public class SpellCard : MonoBehaviour
{
    [SerializeField] private SpellData spell;
    [SerializeField] private TMP_Text title, description, sideBarTitle, sideBarDescription;

    public SpellData Spell
    {
        get => spell;
        set => spell = value;
    }
    
    private void Awake()
    {
        ApplyData();
    }
    private void OnValidate()
    {
        ApplyData();
    }

    void ApplyData()
    {
        if (spell != null) {
            title.text = spell.name;
            description.text = spell.description;
            sideBarDescription.text = null;
            foreach (var ingredient in spell.Recipe)
            {
                sideBarDescription.text += $"{ingredient.name}\n";
            }
        }
    }

}
