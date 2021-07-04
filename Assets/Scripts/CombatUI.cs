using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUI : MonoBehaviour
{
    public GameObject navigation;
    public GameObject enemyAI;

    //public GameObject cardSlot1;
    //public GameObject cardSlot2;

    public GameObject playerHpDisplay;
    int playerHP;
    public GameObject enemyHpDisplay;
    int enemyHP;

    public int playerTurn;

    // Start is called before the first frame update
    void Start()
    {
        InitialHP();
        playerTurn = 0;

    }

    public void InitialHP()
    {
        playerHP = 100;
        playerHpDisplay.GetComponent<Text>().text = playerHP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player atk list
    public void InitiatePlayerCard()
    {
        GetCurrentEnemyHP();
        if (playerTurn == 0)
        {
            enemyHP -= 10;

            if (enemyHP > 0)
            {
                ResolvePlayerAtk();
            }

            if (enemyHP <= 0)
            {
                EnemyDefeat();
            }
        }
 
    }

    public void ResolvePlayerAtk()
    {
        enemyHpDisplay.GetComponent<Text>().text = enemyHP.ToString();
        playerTurn = 1;
        enemyAI.GetComponent<EnemyAI>().EnemyAttack();
    }

    public void EnemyDefeat()
    {
        enemyHpDisplay.GetComponent<Text>().text = 0.ToString();
        navigation.GetComponent<Navigation>().Victory();
    }

    public void GetCurrentEnemyHP()
    {
        enemyHP = int.Parse(enemyHpDisplay.GetComponent<Text>().text);
        playerTurn = enemyAI.GetComponent<EnemyAI>().enemyTurn;
    }
   

}
