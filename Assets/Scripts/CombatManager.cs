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

    //StartCombat when all cards slots ar filled
  
    private void Start()
    {
        slotCount = 0;
        actionCount = 0;
    }

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
        Debug.Log("callcombatsequence");
        StartCoroutine(CombatSequence());
    }

    IEnumerator CombatSequence()
    {
        Debug.Log("combat sequence start");
        //combatSlot1.GetComponentInChildren<CardEffects>().ActivateCard();
        combatSlot1.GetComponent<CardSlot>().ActivateCard();
        yield return new WaitForSeconds(1.2f);
      
        ActionCounter();
        //combatSlot2.GetComponentInChildren<CardEffects>().ActivateCard();
        combatSlot2.GetComponent<CardSlot>().ActivateCard();
        yield return new WaitForSeconds(2.4f);
        
        ActionCounter();
        Debug.Log("combat sequence end");
    }











    //testatk
    public void InitiatePlayerCard()
    {
        if (canAtk)
        StartCoroutine(AtkSequence());

    }

    IEnumerator AtkSequence()
    {     
        canAtk = false;
        yield return new WaitForSeconds(0.5f);
        _PLAYER.Atk(10);
        yield return new WaitForSeconds(1.2f);
        if (!_ENEMY.IsDead())
        {
            //_ENEMY.Atk();   
        }
        canAtk = true;

    }

   


}
