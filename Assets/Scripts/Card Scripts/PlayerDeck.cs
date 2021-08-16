using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : Singleton<PlayerDeck>
{
    public List<Card> cardList;

    public List<PlayerCard> meleeList;

    public List<PlayerCard> rangedList;

    public List<PlayerCard> supportList;

    public Card starterCard1;
    public Card starterCard2;
    private void Start()
    {
        //starter cards
        AddCard(starterCard1);
        AddCard(starterCard2);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddCard(starterCard1);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddCard(starterCard2);
        }
    }

    public void AddCard(Card card)
    {
        cardList.Add(card);


        int pos;

        switch (card.myType)
        {
            case CardType.Melee:
                int meleeCount = cardList.FindAll(x => x.myType == CardType.Melee).Count;
                if (meleeCount <= meleeList.Count)
                {
                    pos = GetCardSlot(meleeList);
                    meleeList[pos].SetupCard(card);
                }              
                break;

            case CardType.Ranged:
                int rangedCount = cardList.FindAll(x => x.myType == CardType.Ranged).Count;
                Debug.Log("rangedcount" + rangedCount);
                if (rangedCount <= rangedList.Count)
                {
                    pos = GetCardSlot(rangedList);
                    rangedList[pos].SetupCard(card);
                }               
                break;

            case CardType.Support:
                int supportCount = cardList.FindAll(x => x.myType == CardType.Support).Count;
                if (supportCount <= supportList.Count)
                {
                    pos = GetCardSlot(supportList);
                    supportList[pos].SetupCard(card);
                }               
                break;
        }
    }

    public int GetCardSlot(List<PlayerCard> _pc)
    {
        int pos = 0;
        for (int i=0; i<_pc.Count; i++)
        {
            if (_pc[i].card == null)
            {
                pos = i;
                return pos;

            }
        }
        return pos;
    }

    public void DisplayCards()
    {

    }
}
