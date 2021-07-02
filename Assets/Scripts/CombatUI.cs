using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUI : MonoBehaviour
{
    public GameObject navigation;

    public GameObject playerHpDisplay;
    public GameObject cardSlot1;
    public GameObject cardSlot2;
    public int playerHP;
    int playerMaxHP = 100;

    public GameObject enemyHpDisplay;
    int enemyHP;

    // Start is called before the first frame update
    private void Start()
    {

        playerHP = playerMaxHP;

       



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Attack function
    public void InitiatePlayerCard()
    {

        enemyHP = int.Parse(enemyHpDisplay.GetComponent<Text>().text);


        enemyHP -= 10;

        if (enemyHP > 0)
        {
            DisplayEnemyHP();
            Debug.Log("enemy take 10 dmg oof");

        }
        

        if (enemyHP <= 0)
        {
            enemyHpDisplay.GetComponent<Text>().text = 0.ToString();
            navigation.GetComponent<Navigation>().Victory();
            Debug.Log("enemy has been defeated");
        }

        
    }

    public void DisplayEnemyHP()
    {
        enemyHpDisplay.GetComponent<Text>().text = enemyHP.ToString();
    }
   

}
