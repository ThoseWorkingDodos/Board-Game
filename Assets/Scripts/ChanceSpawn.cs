using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject     cardPrefab;
    [SerializeField] private Transform      chanceSpawn;
    [SerializeField] private GameObject[]   chanceCards;

    void Start()
    {
        SpawnCards();
    }

    // Update is called once per frame

    private void SpawnCards()
    {
        for (int i = 0; i < chanceCards.Length; i++)
        {
            Transform chance_transform = cardPrefab.transform.Find(string.Concat("Chance_",i+1));
            chanceCards[i] = chance_transform.gameObject;
        }

        for (int i = 0; i < chanceCards.Length; i++)
        {
            GameObject card = Instantiate(chanceCards[i],chanceSpawn);
            card.transform.parent = transform;
            card.transform.position = chanceSpawn.transform.position + new Vector3(0,0.1f*i,0);
        }
    }
}
