using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform chanceSpawn;
    [SerializeField] private GameObject[] chanceCards;

    void Start()
    {
        SpawnCards();
    }

    // Update is called once per frame

    private void randomize()
    {
        for (int i = 0; i < chanceCards.Length - 1; i++)
        {
            int rnd = Random.Range(i, chanceCards.Length);
            Debug.Log(rnd);
        }
    }
    private void SpawnCards()
    {
        for (int i = 0; i < chanceCards.Length; i++)
        {
            GameObject card = Instantiate(chanceCards[i],chanceSpawn);
            card.transform.parent = transform;
            card.transform.position = chanceSpawn.transform.position + new Vector3(0,0.1f*i,0);
        }
    }
}
