using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    public int cardNo;

    public CombatManager combatManager;

    void Start()
    {
        //combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();
    }

    public void DestroyObject()
    {
        Destroy(this);
    }

    //player
    public void ActivateCard()
    {

        //Player
        //ATK1
        if (cardNo == 1)
        {
            combatManager.PlayerAtk(10);

        }


        //Enemy
        //CLAW
        if (cardNo == 2)
        {
            combatManager.EnemyAtk(10);

        }
    }


  


}
