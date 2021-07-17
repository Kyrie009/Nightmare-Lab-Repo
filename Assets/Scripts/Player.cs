using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Singleton<Player>
{
    public Text healthDisplay;
    public int health;

    public TMP_Text dmgText;
    public Animator dmgAnim;

    //player animation
    public Animator playerAnim;
    

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
        playerAnim.SetTrigger("PlayerShoot");
        
    }

    public void Hit(int _dmg)
    {
        health -= _dmg;
        healthDisplay.text = health.ToString();
       
        dmgText.text = _dmg.ToString();
        dmgAnim.SetTrigger("HitPlayer");
        
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
