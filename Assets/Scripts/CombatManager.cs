using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : Singleton<CombatManager>
{
    

    public int turnOrder;
    public bool canAtk = true;

    //Player atk list
    public void InitiatePlayerCard()
    {
        if (canAtk)
        StartCoroutine(AtkSequence());

    }

    IEnumerator AtkSequence()
    {
        Debug.Log("Start atk seq");
        canAtk = false;
        yield return new WaitForSeconds(0.5f);
        _PLAYER.Atk(10);
        yield return new WaitForSeconds(1.2f);
        if (!_ENEMY.IsDead())
        {
            _ENEMY.Atk();   
        }
        canAtk = true;
        Debug.Log("finish atk seq");




    }

   
  





}
