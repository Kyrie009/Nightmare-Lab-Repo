using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : Singleton<CardList>
{
    public GameObject cardSlot1;
    public GameObject cardSlot2;

    public CombatManager combatManager;

    public GameObject atk1;

    public GameObject claw;

    //PlayerCards
    public void Atk1()
    {
        GameObject newPlayerCard = Instantiate(atk1, new Vector3(0, 0), Quaternion.identity);
        newPlayerCard.transform.SetParent(cardSlot1.transform, false);
        newPlayerCard.GetComponent<CardEffects>().combatManager = combatManager;
        _CM.SlotCounter();

    }



    //EnemyCards
    public void Claw()
    {
        GameObject newPlayerCard = Instantiate(claw, new Vector3(0, 0), Quaternion.identity);
        newPlayerCard.transform.SetParent(cardSlot2.transform, false);
        newPlayerCard.GetComponent<CardEffects>().combatManager = combatManager;
        _CM.SlotCounter();

    }
}
