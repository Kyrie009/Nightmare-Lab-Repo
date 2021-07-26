using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerCard : GameBehaviour
{
    public GameObject combatSlot1;
    public Player player;

    public Card card;

    public TMP_Text nameText;
    public TMP_Text cdText;
    public TMP_Text dmgText;
    public TMP_Text infoText;

    public int coolDown;
    public int damage;

    public bool usable;

    void Start()
     {
         
         //SetupCard(card);
     }

    public void NewCard()
    {

    }

    public void SetupCard(Card _stats)
    {
        card = _stats;
        this.GetComponent<Image>().sprite = _stats.cardImage;
        nameText.text = _stats.cardName;
        cdText.text = _stats.coolDown.ToString();
        dmgText.text = _stats.damage.ToString();
        infoText.text = _stats.cardDescription;

        coolDown = _stats.coolDown;
        damage = _stats.damage;

    }

    public void Click()
    {

        combatSlot1.GetComponent<CardSlot>().card = this.gameObject;
        combatSlot1.GetComponent<CardSlot>().SetCard();

    }

    public void CardEffect()
    {

        _PLAYER.PlayerAtk(damage);

    }

}
