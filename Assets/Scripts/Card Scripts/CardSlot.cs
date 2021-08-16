using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : GameBehaviour
{
    public GameObject card;

    public bool slotEmpty = true;
    public bool enemyTargeting = false;


    public void SetCard()
    {
        this.GetComponent<Image>().sprite = card.GetComponent<Image>().sprite;
        _CM.SlotCounter();
         
    }

    public void SetEnemyCard()
    {
        this.GetComponent<Image>().sprite = _ENEMY.cardImage;
        _CM.SlotCounter();
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
            _ENEMY.CardEffect();
            enemyTargeting = false;
        }
        
    }



 
}
