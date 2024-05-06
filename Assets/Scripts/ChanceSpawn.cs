using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceSpawn : MonoBehaviour
{
    
    [SerializeField] private Transform chanceSpawn;
    [SerializeField] private GameObject[]   chanceCards;

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
        chanceCards = new GameObject[cardManager.cardObjects.Length];
        for (int i = 0; i < cardManager.cardObjects.Length; i++)
        {
            GameObject card = Instantiate(cardManager.cardObjects[i], chanceSpawn);
            card.transform.parent = transform;
            card.transform.position = chanceSpawn.transform.position + new Vector3(0,0.1f*i,0);
            chanceCards[i] = card;
        }
        isSpawned = true;
    }

    private void FixedUpdate()
    {
        if(isSpawned)
            cardManager.CardToBottom(chanceCards,chanceSpawn);
    }
}
