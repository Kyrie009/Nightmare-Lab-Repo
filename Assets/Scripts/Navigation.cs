using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;






public class Navigation : Singleton<Navigation>
{
    public GameObject homeScreen;
    public GameObject itemScreen;
    public GameObject cardScreen;
    public GameObject battleScreen;
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    public GameObject shopScreen;
    public GameObject combatScreen;

    public GameObject playerMapIcon;
    public GameObject startPos;

    void Start()
    {
        //Set draw order from the start
        itemScreen.SetActive(false); 
        cardScreen.SetActive(false);
        battleScreen.SetActive(false);
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
        shopScreen.SetActive(false);
        combatScreen.SetActive(false);
    }

    //HomeScreen
    public void StartGame()
    {
        homeScreen.SetActive(false);
    }
    //Back to homescreen
    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
        homeScreen.SetActive(true);
    }

    //Shop/Recall
    public void Recall()
    {
        shopScreen.SetActive(true);
        playerMapIcon.transform.position = startPos.transform.position;
        _PLAYER.InitialHP();
        
    }
    public void DoneShopping()
    {
        shopScreen.SetActive(false);
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
        _BM.DefaultBackground();
    }

    //DefeatScreen
    public void Defeat()
    {
        defeatScreen.SetActive(true);
    }

    public void ReturnFromDeath()
    {
        SceneManager.LoadScene(0);
    }

    //Exit
    public void QuitGame()
    {
        Application.Quit();
    }
}
