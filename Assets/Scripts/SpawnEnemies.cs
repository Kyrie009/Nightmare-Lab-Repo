using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyHpDisplay;
    public GameObject CombatUI;
    int enemyHP;

    Image emptySprite;
    public Sprite[] enemySprite;
    public EnemyStats[] enemyStats;


    // Start is called before the first frame update
    public void SpawnNewEnemy()
    {
        int index;
        index = Random.Range(0, 4);
        
        emptySprite = GetComponent<Image>();
        emptySprite.sprite = enemySprite[index];
        
        enemyHP = enemyStats[index].initialValue;
        enemyHpDisplay.GetComponent<Text>().text = enemyHP.ToString();
        
       




    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
