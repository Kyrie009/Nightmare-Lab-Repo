using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;






public class Navigation : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject itemScreen;
    public GameObject cardScreen;
    public GameObject battleScreen;
    public GameObject victoryScreen;

    void Awake()
    {
        //Set draw order from the start
        itemScreen.SetActive(false); 
        cardScreen.SetActive(false);
        battleScreen.SetActive(false);
        victoryScreen.SetActive(false);





    }



    //HomeScreen
    public void StartGame()
    {

        homeScreen.SetActive(false);

    }

    public void ReturnHome()
    {

        homeScreen.SetActive(true);

    }

    //Item Menu
    public void OpenItems()
    {

        itemScreen.SetActive(true);

    }
    public void CloseItems()
    {

        itemScreen.SetActive(false);

    }

    //Card Menu
    public void OpenCards()
    {

        cardScreen.SetActive(true);

    }
    public void CloseCards()
    {

        cardScreen.SetActive(false);

    }

    //VictoryScreen
    public void Victory()
    {
        victoryScreen.SetActive(true);
    }

    public void ReturnFromBattle()
    {
        battleScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }




    public void QuitGame()
    {
        Application.Quit();
    }
}
