using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leveltiles : GameBehaviour
{
    public Tiletype myType;

    public GameObject battleScreen;
    public GameObject playerIcon;
    Color defaultColor;

    int encounter;
    int range = 70;

    private void Start()
    {
        defaultColor = GetComponent<Image>().color;
    }

    public void SetupTile()
    {
        encounter = Random.Range(1, 5);
        if (encounter == 1)
        {
            myType = Tiletype.Enemy;
        }


    }

    public void ResetColor()
    {
        this.GetComponent<Image>().color = defaultColor;
    }

    public void Explore()
    {
        

        //check adjacent positions for player
        if (Vector3.Distance(playerIcon.transform.position, this.transform.position) < range)
        {
            

            //player position move to tile
            playerIcon.transform.position = this.transform.position;

            //disable color on click (have unityengine.UI to access components).     
            this.GetComponent<Image>().color = Color.clear;

            //Moves to battlescreen
            if (myType == Tiletype.Enemy)
            {
                
                _ENEMY.SpawnNewEnemy();
                _BM.CombatBackground();
                battleScreen.SetActive(true);
            

            }

            //Dialogue box, scriptable objects, tba
            if (encounter == 2)
            {
                _EVENT.GetNewEvent();
            }

            if (myType == Tiletype.Stairs)
            {
                _LM.ChangeFloor(FloorDirection.Down);
            }

            if (myType == Tiletype.Entrance)
            {
                _LM.ChangeFloor(FloorDirection.Up);
            }


        }

    }

    

}
