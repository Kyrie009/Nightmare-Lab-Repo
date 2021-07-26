using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CardType { Melee, Ranged, Support}
//[System.Serializable]
[CreateAssetMenu]

public class Card : ScriptableObject
{
    public CardType myType;
    public Sprite cardImage;

    public string cardName;
    public int coolDown;
    public int damage;
    [TextArea (8,10)] public string cardDescription;


    //public int shield;
    //public int heal;


}
