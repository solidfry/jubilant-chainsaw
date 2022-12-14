using System;
using System.Collections;
using Events;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    public class QuestHandIn : MonoBehaviour
    {
        [ReadOnly]
        [SerializeField]
        private SpellData expectedSpell;
        [SerializeField] GameObject particle;

        private void OnEnable()
        {
            GameEvents.OnGetNewQuestEvent += SetExpectedSpell;
        }

        private void OnDisable()
        {
            GameEvents.OnGetNewQuestEvent -= SetExpectedSpell;
        }

        private void SetExpectedSpell(SpellData spellData, string dialogue)
        {
            expectedSpell = spellData;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //questSpell != null && questSpell.SpellType.name == expectedSpell.name
            if (other.GetComponent<Spell>() != null)
            {
                var spell = other.GetComponent<Spell>();
                string spellName = spell.SpellType.name;
                if (spellName == expectedSpell.name) StartCoroutine(QuestSuccessful(spell));
            }
        }

        IEnumerator QuestSuccessful(Spell go)
        {
            GameEvents.OnCelebrationEvent?.Invoke();
            yield return new WaitForSeconds(.5f);
            go.DoDestroy();
            yield return new WaitForSeconds(2f);
            // Destroy(go.gameObject);
            GameEvents.OnQuestCompletedEvent?.Invoke();
        }
    }
}