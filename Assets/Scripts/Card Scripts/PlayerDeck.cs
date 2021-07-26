using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : Singleton<PlayerDeck>
{
    public List<Card> cardList;

    public List<PlayerCard> meleeList;

    public List<PlayerCard> rangedList;

    public List<PlayerCard> supportList;

    public void AddCard(Card card)
    {
        cardList.Add(card);



        switch (card.myType)
        {
            case CardType.Melee:
                meleeList[0].SetupCard(card);
                break;

            case CardType.Ranged:
                rangedList[0].SetupCard(card);
                break;

            case CardType.Support:
                supportList[0].SetupCard(card);
                break;

        }
    }

    public void DisplayCards()
    {

    }
}
