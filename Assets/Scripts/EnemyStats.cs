using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public int initialHealth;
    public int baseDmg;
    public Sprite enemyImage;

    public Card[] moveSet;
    public Card[] cardDrop;
    public Sprite cardImage;
    public string cardName;
    public int coolDown;
    public int damage;
    public string cardDescription;

    public void GetCard()
    {
        int index;
        index = Random.Range(0, moveSet.Length);
        NewCardStats(moveSet[index]);

    }

    public void NewCardStats(Card _stats)
    {
        cardImage = _stats.cardImage;
        cardName = _stats.cardName;
        cardDescription = _stats.cardDescription;

        coolDown = _stats.coolDown;
        damage = _stats.damage;
    }

}
