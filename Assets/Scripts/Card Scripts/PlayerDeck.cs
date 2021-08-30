using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Active card list > Card in play > cards in inventory | deck editor > display cards in inventory & active cards > move cards between lists
// card enhancement system tba
public class PlayerDeck : Singleton<PlayerDeck>
{
    //All Cards in Inventory
    public List<Card> cardList;
    //Cards in play
    public List<PlayerCard> meleeList;
    public List<PlayerCard> rangedList;
    public List<PlayerCard> supportList;

    //Starting Cards
    public Card starterCard1;
    public Card starterCard2;
    private void Start()
    {
        //Adds starting cards
        AddCard(starterCard1);
        AddCard(starterCard2);
    }

    void Update()
    {
        //Cheats
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddCard(starterCard1);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddCard(starterCard2);
        }
    }
    //Adds and sorts newly obtained cards
    public void AddCard(Card card)
    {
        cardList.Add(card);
        int pos;
        //Card sorting and link to player card
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
    //Checks for an empty card slot to put new card in
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
}
