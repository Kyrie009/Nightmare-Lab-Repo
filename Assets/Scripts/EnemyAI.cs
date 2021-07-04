using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public GameObject navigation;
    public GameObject enemySpawner;
    public GameObject combatUI;
    
    //public GameObject cardSlot1;
    //public GameObject cardSlot2;
    
    public GameObject playerHpDisplay;
    int playerHP;
    int index;

    public int enemyTurn;

    //Updates the new Enemy 
    public void GetNewEnemy()
    {
        index = enemySpawner.GetComponent<SpawnEnemies>().enemyID;
    }

    void Update()
    {
  
    }

    //Enemy Attack
    public void EnemyAttack()
    {
        enemyTurn = combatUI.GetComponent<CombatUI>().playerTurn;
        GetNewEnemy();

        //Enemy Atk
        if (enemyTurn == 1)
        {
            //Crow
            if (index == 0)
            {
                BasicAtk1();
            }
            //Cat
            if (index == 1)
            {
                BasicAtk2();
            }
            //Paralysis Demon
            if (index == 2)
            {
                BasicAtk3();
            }
            //Starved One
            if (index == 3)
            {
                BasicAtk4();
            }
        }
    }

    //Attack List
    public void BasicAtk1()
    {
        GetCurrentPlayerHP();

        playerHP -= 5;

        if (playerHP > 0)
        {
            ResolveEnemyAtk();
        }

        if (playerHP <= 0)
        {
            PlayerDefeat();
        }
    }

    public void BasicAtk2()
    {
        GetCurrentPlayerHP();

        playerHP -= 10;

        if (playerHP > 0)
        {
            ResolveEnemyAtk();          
        }

        if (playerHP <= 0)
        {
            PlayerDefeat();
        }
    }

    public void BasicAtk3()
    {
        GetCurrentPlayerHP();

        playerHP -= 7;

        if (playerHP > 0)
        {
            ResolveEnemyAtk();            
        }

        if (playerHP <= 0)
        {
            PlayerDefeat();
        }
    }

    public void BasicAtk4()
    {
        GetCurrentPlayerHP();

        playerHP -= 15;

        if (playerHP > 0)
        {
            ResolveEnemyAtk();          
        }

        if (playerHP <= 0)
        {
            PlayerDefeat();
        }
    }

    //Functions
    public void ResolveEnemyAtk()
    {
        playerHpDisplay.GetComponent<Text>().text = playerHP.ToString();
        enemyTurn = 0;
    }

    public void PlayerDefeat()
    {
        playerHpDisplay.GetComponent<Text>().text = 0.ToString();
        navigation.GetComponent<Navigation>().Defeat();
    }

    public void GetCurrentPlayerHP()
    {
        playerHP = int.Parse(playerHpDisplay.GetComponent<Text>().text);
    }
   
}
