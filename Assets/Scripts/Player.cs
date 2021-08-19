using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Singleton<Player>
{
    public Slider healthSlider;
    public Text healthDisplay;
    public int health;

    public TMP_Text dmgText;
    public Animator dmgAnim;

    //player animation
    public Animator playerAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialHP();
    }

    public void InitialHP()
    {
        health = 100;
        healthSlider.maxValue = 100;
        UpdateHealth();
    }

    //Player Attacks
    public void PlayerAtk(int _dmg)
    {
        StartCoroutine(AtkRoutine(_dmg));
    }

    IEnumerator AtkRoutine(int _dmg)
    {
        playerAnim.SetTrigger("PlayerShoot");
        yield return new WaitForSeconds(1f);
        Atk(_dmg);
    }

    public void Atk(int _dmg)
    {
        _ENEMY.Hit(_dmg);
    }

    //Player is hit
    public void Hit(int _dmg)
    {
        health -= _dmg;
        UpdateHealth();

        dmgText.text = _dmg.ToString();
        dmgAnim.SetTrigger("HitPlayer");
        
        if (health <= 0)
        {
            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        healthDisplay.text = 0.ToString();
        _NAV.Defeat();
    }

    public void UpdateHealth()
    {
        healthSlider.value = health;
        healthDisplay.text = health.ToString();
    }



}
