using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunitySpawn : MonoBehaviour
{
    [SerializeField] private Transform communitySpawn;
    [SerializeField] private GameObject[] communityCards;

    private bool isSpawned;
    private CardManager cardManager;

    void Start()
    {
        cardManager = GetComponent<CardManager>();
        isSpawned = false;
        SpawnCards();
    }
    private void SpawnCards()
    {
        cardManager.ShuffleCards();
        communityCards = new GameObject[cardManager.cardObjects.Length];
        for (int i = 0; i < cardManager.cardObjects.Length; i++)
        {
            GameObject card = Instantiate(cardManager.cardObjects[i], communitySpawn);
            card.transform.parent = transform;
            card.transform.position = communitySpawn.transform.position + new Vector3(0, 0.1f * i, 0);
            communityCards[i] = card;
        }
        isSpawned = true;
    }
    private void FixedUpdate()
    {
        if (isSpawned)
            cardManager.CardToBottom(communityCards, communitySpawn);
    }
}
