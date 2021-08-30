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
    public Animator animSlot1;
    public Animator animSlot2;

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
    //Start new turn when all actions are resolved.
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
        yield return new WaitForSeconds(0.5f);
        animSlot1.SetTrigger("EnableSlot1");
        yield return new WaitForSeconds(0.5f);
        combatSlot1.GetComponent<CardSlot>().ActivateCard();
        yield return new WaitForSeconds(1.2f);       
        ActionCounter();
        if (!_ENEMY.IsDead())
        {
            animSlot2.SetTrigger("EnableSlot2");
            yield return new WaitForSeconds(0.5f);
            combatSlot2.GetComponent<CardSlot>().ActivateCard();
            yield return new WaitForSeconds(2f); 
        }              
        ActionCounter();
    }

    public void RestoreAlpha1()
    {
        animSlot1.SetTrigger("RestoreAlpha");
    }

    public void RestoreAlpha2()
    {
        animSlot2.SetTrigger("RestoreAlpha2");
    }

}
