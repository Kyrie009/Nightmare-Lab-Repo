using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : Singleton<Enemy>
{
    public EnemyStats[] enemyStats;

    public Text healthDisplay;
    public int health;
    //int baseAtk;
    public Image enemyImage;

    public TMP_Text dmgText;
    public Animator dmgAnim;


    //Updates the new Enemy
    public void SpawnNewEnemy()
    {
        int index;
        index = Random.Range(0, enemyStats.Length);
        SetupEnemy(enemyStats[index]);

    }

    public void SetupEnemy(EnemyStats _stats)
    {
        health = _stats.initialHealth;
        //baseAtk = _stats.baseDmg;
        enemyImage.sprite = _stats.enemyImage;
        healthDisplay.text = health.ToString();
        ChooseCard();
        
    }

    public void ChooseCard()
    {
        _CL.Claw();
    }



    //Enemy Attack
    public void Atk(int _dmg)
    {
        _PLAYER.Hit(_dmg);
        //_PLAYER.Hit(baseAtk);
        
        

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
