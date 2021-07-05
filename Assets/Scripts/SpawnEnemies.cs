using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : GameBehaviour
{

    public EnemyStats[] enemyStats;
 
    // Start is called before the first frame update
    public void SpawnNewEnemy()
    {
        int index;
        index = Random.Range(0, enemyStats.Length);
        _ENEMY.SetupEnemy(enemyStats[index]);

    }


}
