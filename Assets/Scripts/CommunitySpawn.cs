using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunitySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform      communitySpawn;
    [SerializeField] private CardManager    cardManager;

    void Start()
    {
        cardManager = GetComponent<CardManager>();
        SpawnCards();
    }
    private void SpawnCards()
    {
        for (int i = 0; i < cardManager.cardObjects.Length; i++)
        {
            GameObject card = Instantiate(cardManager.cardObjects[i], communitySpawn);
            card.transform.parent = transform;
            card.transform.position = communitySpawn.transform.position + new Vector3(0, 0.1f * i, 0);
        }
    }
}
