using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    public GameObject cardPrefab;
    public List<GameObject> cardsObject = new List<GameObject>();
    public GameObject currentCard;
    [ContextMenu(" inatiliaze card")]    
    
    public void InitializeDeck()
    {
        cards = new List<Card>();
        for (int suit = 0; suit < 4; suit++)
        {
            for (int rank = 1; rank <= 13; rank++)
            {
                currentCard = Instantiate(cardPrefab, transform);
                Card newCard = currentCard.GetComponent<Card>();
                newCard.suit = GetSuitName(suit);
                if (rank == 1)
                {
                    newCard.rank = 14;
                }
                else
                {
                    newCard.rank = rank;
                }
                newCard.isFaceUp = false;
                if (newCard.rank == 14)
                {
                    newCard.name = newCard.suit + "_A";
                }
                else if (newCard.rank == 13)
                {
                   newCard.name = newCard.suit + "_K";
                }
                else if (newCard.rank == 12)
                {
                   newCard.name = newCard.suit + "_Q";
                }
                else if (newCard.rank == 11)
                {
                    newCard.name = newCard.suit + "_J";
                }
                else
                {
                   newCard.name = newCard.suit + "_" + newCard.rank;
                }
                if (suit == 0)
                {
                  
                    newCard.rank = newCard.rank *10;
                }
                //newCard.Init();
                GameObject pickedCardObject = cardsObject.Find(cardObj => cardObj.name == newCard.name);
                if (pickedCardObject != null)
                {
                    GameObject model = Instantiate(pickedCardObject, currentCard.transform);
                    model.transform.position = Vector3.zero;
                }
               cards.Add(newCard);
            }
        }
        Shuffle();
    }
    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card DealCard()
    {
        if (cards.Count > 0)
        {
            Card dealtCard = cards[0];
            cards.RemoveAt(0);
            return dealtCard;
        }
        else
        {
            Debug.Log("No more cards in the deck!");
            return null;
        }
    }
    private string GetSuitName(int suit)
    {
        switch (suit)
        {
            case 0:
                return "S";
            case 1:
                return "H";
            case 2:
                return "D";
            case 3:
                return "C";
            default:
                return "";
        }
    }
}