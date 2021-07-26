using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : GameBehaviour
{
    public GameObject card;
    public GameObject enemy;
    public GameObject combatManager;

    public bool slotEmpty = true;
    public bool enemyTargeting = false;


    public void SetCard()
    {
        this.GetComponent<Image>().sprite = card.GetComponent<Image>().sprite;
        combatManager.GetComponent<CombatManager>().SlotCounter();
         
    }

    public void SetEnemyCard()
    {
        this.GetComponent<Image>().sprite = card.GetComponent<Enemy>().cardImage;
        combatManager.GetComponent<CombatManager>().SlotCounter();
    }


    public void Targeting()
    {
        enemyTargeting = true;
    }


    public void ActivateCard()
    {
        if (enemyTargeting == false)
        {
            card.GetComponent<PlayerCard>().CardEffect();

        }

        if (enemyTargeting == true)
        {
            enemy.GetComponent<Enemy>().CardEffect();
            enemyTargeting = false;
        }
        
    }



 
}
