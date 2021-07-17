using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : Singleton<Enemy>
{
    public GameObject enemySpawner;   
    
    int index;

    public Text healthDisplay;
    public int health;
    int baseAtk;
    public Image enemyImage;

    public TMP_Text dmgText;
    public Animator dmgAnim;


    //Updates the new Enemy 

    public void SetupEnemy(EnemyStats _stats)
    {
        health = _stats.initialHealth;
        baseAtk = _stats.baseDmg;
        enemyImage.sprite = _stats.enemyImage;
        healthDisplay.text = health.ToString();
    }



    //Enemy Attack
    public void Atk()
    {
        
        _PLAYER.Hit(baseAtk);
        //_CM.EnemyDmgAnim(baseAtk);
        

    }

    public void Hit(int _dmg)
    {
        health -= _dmg;
        healthDisplay.text = health.ToString();

        dmgText.text = _dmg.ToString();
        dmgAnim.SetTrigger("Hit");
        
        if (IsDead())
        {
            EnemyDied();
        }
    }

    

    public void EnemyDied()
    {
        healthDisplay.text = 0.ToString();
        _NAV.Victory();
    }

    public bool IsDead()
    {
        return health <= 0;
    }


}
