﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : Singleton<Enemy>
{
    //List of Enemies
    public EnemyStats[] enemyStats;
    //UI related
    public GameObject combatSlot2;
    public Image enemyImage;
    public TMP_Text enemyName;
    public TMP_Text cardRewardText;
    //Health
    public Slider healthSlider;
    public Text healthDisplay;
    public int health;
    //Animation
    public TMP_Text dmgText;
    public Animator dmgAnim;
    public Animator enemyAnim;
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
        healthSlider.maxValue = health;
        healthSlider.value = health;
        healthDisplay.text = health.ToString();
        enemyImage.sprite = _stats.enemyImage;  
        enemyName.text = _stats.EnemyName;
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
        if (!IsDead())
        {   
            enemyAnim.SetTrigger("EnemyAtk");
            yield return new WaitForSeconds(0.5f);
            Atk(_dmg);
        }      
    }

    //Enemy Attack
    public void Atk(int _dmg)
    {           
            _PLAYER.Hit(_dmg);
    }

    public void Hit(int _dmg)
    {
        health -= _dmg;
        healthDisplay.text = health.ToString();
        healthSlider.value = health;

        dmgText.text = _dmg.ToString();
        dmgAnim.SetTrigger("Hit");
        enemyAnim.SetTrigger("EnemyRecoil");
        
        if (IsDead())
        {
            EnemyDied();
        }
    }

    public void EnemyDied()
    {
        healthDisplay.text = 0.ToString();
        Card cardDrop = enemyStats[index].moveSet[Random.Range(0, enemyStats[index].moveSet.Length)];
        _PD.AddCard(cardDrop);
        cardRewardText.text = cardDrop.cardName + " +1";
        _NAV.Victory();
    }

    public bool IsDead()
    {
        return health <= 0;
    }


}
