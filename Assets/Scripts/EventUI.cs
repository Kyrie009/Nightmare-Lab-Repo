using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventUI : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject battleScreen;
    public GameObject playerIcon;

    int encounter;
    int range = 70;

    

    public void Explore()
    {
        

        //check adjacent positions for player
        if (Vector3.Distance(playerIcon.transform.position, this.transform.position) < range)
        {
            encounter = Random.Range(1, 5);

            //player position move to tile
            playerIcon.transform.position = this.transform.position;

            //disable color on click (have unityengine.UI to access components).     
            this.GetComponent<Image>().color = Color.clear;

            //Moves to battlescreen
            if (encounter == 2)
            {
                enemySpawner.GetComponent<SpawnEnemies>().SpawnNewEnemy();
                battleScreen.SetActive(true);

            }

            //Dialogue box, scriptable objects, tba


        }


    }

    

}
