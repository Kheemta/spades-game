using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Deck deck;
    [SerializeField] List<Player> players;
    [SerializeField] Transform[] seats; 
    [SerializeField] GameObject cubeCharacterPrefab;

    private void Start()
    {
        StartSpadesGame();
    }

    private void StartSpadesGame()
    {
        deck.InitializeDeck();
        InitializePlayers();
        DealCardsToPlayers();
        SetPlayersOnSeats();
    }

    private void InitializePlayers()
    {
        for (int i = 0; i < 4; i++)
        {
            Player player = new Player();
            player.hand = new List<Card>();
            player.cubeCharacter = Instantiate(cubeCharacterPrefab);
            players.Add(player);
        }
    }

    private void DealCardsToPlayers()
    {
        for (int i = 0; i < 13; i++)
        {
            foreach (Player player in players)
            {
                Card dealtCard = deck.DealCard();
                player.hand.Add(dealtCard);
                Transform parentTransform = player.cubeCharacter.gameObject.transform.GetChild(0);
                dealtCard.transform.SetParent(parentTransform, false);
                float radius = 1f;
                float angle = i * (Mathf.PI/ 12f);
                float x = radius * Mathf.Cos(angle);
                float y = radius * Mathf.Sin(angle);
                x += (player == players[0] || player == players[3]) ? +1.5f : -1.5f;
                dealtCard.transform.localPosition = new Vector3(x, y, 0f);

            }
        }
    }

    private void SetPlayersOnSeats()
    {
        if (players.Count != seats.Length)
        {
            Debug.LogError("Number of players doesn't match the number of seats!");
            return;
        }

        for (int i = 0; i < players.Count; i++)
        {
            Transform playerTransform = players[i].cubeCharacter.transform;
            playerTransform.SetParent(seats[i]);
            playerTransform.localPosition = Vector3.zero;
            playerTransform.localRotation = Quaternion.identity;
        }
    }
}
[Serializable]
public class Player
{
    public List<Card> hand;
    public GameObject cubeCharacter;

}