using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatManager : Singleton<CombatManager>
{
    public bool canAtk = true;

    public GameObject combatSlot1;
    public GameObject combatSlot2;

    public GameObject combatScreen;

    public int slotCount;
    public int actionCount;

    
    private void Start()
    {
        slotCount = 0;
        actionCount = 0;
    }
    //StartCombat when all cards slots ar filled
    public void SlotCounter()
    {
        slotCount += 1;

        if (slotCount == 2)
        {
            combatScreen.SetActive(true);
            CombatStart();
        }
    }

    public void ActionCounter()
    {
        actionCount += 1;

        if (actionCount == 2)
        {
            actionCount = 0;
            slotCount = 0;
            if (!_ENEMY.IsDead())
            {
                _ENEMY.ChooseCard();
            }
            combatScreen.SetActive(false);
        }
    }

    //CombatSequence
    public void CombatStart()
    {
        StartCoroutine(CombatSequence());
    }

    IEnumerator CombatSequence()
    {
        combatSlot1.GetComponent<CardSlot>().ActivateCard();
        yield return new WaitForSeconds(1.2f);       
        ActionCounter();
        combatSlot2.GetComponent<CardSlot>().ActivateCard();
        yield return new WaitForSeconds(2.4f);
        combatSlot1.GetComponent<CardSlot>().ClearSlot();
        ActionCounter();
    }
}
