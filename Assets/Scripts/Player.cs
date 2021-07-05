using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Singleton<Player>
{
 //public GameObject cardSlot1;
    //public GameObject cardSlot2;

    public Text healthDisplay;
    public int health;
   

  

    // Start is called before the first frame update
    void Start()
    {
        InitialHP();
       

    }

    public void InitialHP()
    {
        health = 100;
        healthDisplay.text = health.ToString();

    }

    public void Atk(int _dmg)
    {
        _ENEMY.Hit(_dmg);
    }

    public void Hit(int _dmg)
    {
        health -= _dmg;
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            PlayerDied();
        }
    }


    public void PlayerDied()
    {
        healthDisplay.text = 0.ToString();
        _NAV.Defeat();
    }



}
