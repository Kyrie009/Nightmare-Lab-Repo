using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : Singleton<Enemy>
{
    public EnemyStats[] enemyStats;
    
    public GameObject combatSlot2;

    
    public Text healthDisplay;
    public int health;
    //int baseAtk;
    public Image enemyImage;

    public TMP_Text dmgText;
    public Animator dmgAnim;
    //current card
    public Sprite cardImage;
    public string cardName;
    public int coolDown;
    public int damage;
    public string cardDescription;
    int index;

    //Updates the new Enemy
    public void SpawnNewEnemy()
    {
        
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
        enemyStats[index].GetCard();
        cardImage = enemyStats[index].cardImage;
        cardName = enemyStats[index].cardName;
        cardDescription = enemyStats[index].cardDescription;
        coolDown = enemyStats[index].coolDown;
        damage = enemyStats[index].damage;

        PlaceCard();
        

    }

    public void PlaceCard()
    {
        combatSlot2.GetComponent<CardSlot>().card = this.gameObject;
        combatSlot2.GetComponent<CardSlot>().Targeting();
        combatSlot2.GetComponent<CardSlot>().SetEnemyCard();
    }

    public void CardEffect()
    {
        EnemyAtk(damage);
    }

    public void EnemyAtk(int _dmg)
    {
        StartCoroutine(AtkRoutine2(_dmg));
    }

    IEnumerator AtkRoutine2(int _dmg)
    {
        yield return new WaitForSeconds(1f);
        _ENEMY.Atk(_dmg);

    }

    //Enemy Attack
    public void Atk(int _dmg)
    {
        if (!IsDead())
        { 
            _PLAYER.Hit(_dmg);
            //_PLAYER.Hit(baseAtk);

        }
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
        _PD.AddCard(enemyStats[index].moveSet[Random.Range(0,enemyStats[index].moveSet.Length)]);
        _NAV.Victory();
    }

    public bool IsDead()
    {
        return health <= 0;
    }


}
