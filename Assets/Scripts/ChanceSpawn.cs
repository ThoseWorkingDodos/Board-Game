using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform      chanceSpawn;
    [SerializeField] private CardManager    cardManager;

    void Start()
    {
        cardManager = GetComponent<CardManager>();
        SpawnCards();
    }
    private void SpawnCards()
    {
        cardManager.ShuffleCards();
        for (int i = 0; i < cardManager.cardObjects.Length; i++)
        {
            GameObject card = Instantiate(cardManager.cardObjects[i], chanceSpawn);
            card.transform.parent = transform;
            card.transform.position = chanceSpawn.transform.position + new Vector3(0,0.1f*i,0);
        }
    }
}
