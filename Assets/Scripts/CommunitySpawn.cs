using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunitySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform communitySpawn;
    [SerializeField] private GameObject[] communityCards;

    void Start()
    {
        SpawnCards();
    }

    private void randomize()
    {
        for (int i = 0; i < communityCards.Length - 1; i++)
        {
            int rnd = Random.Range(i, communityCards.Length);
            Debug.Log(rnd);
        }
    }
    private void SpawnCards()
    {
        for (int i = 0; i < communityCards.Length; i++)
        {
            Transform chance_transform = cardPrefab.transform.Find(string.Concat("Community_", i + 1));
            communityCards[i] = chance_transform.gameObject;
        }

        for (int i = 0; i < communityCards.Length; i++)
        {
            GameObject card = Instantiate(communityCards[i], communitySpawn);
            card.transform.parent = transform;
            card.transform.position = communitySpawn.transform.position + new Vector3(0, 0.1f * i, 0);
        }
    }
}
