
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardManager : MonoBehaviour
{
    public GameObject cardprefab;
    public GameObject[] cardObjects;

    [SerializeField] private int cardNo;

    public void ShuffleCards()
    {
        cardNo = cardprefab.transform.childCount;
        cardObjects = new GameObject[cardNo];
        int Rand;
        int[] shuffledIndex = new int[cardNo];

        for (int i = 0; i < cardNo; i++)
        {
            shuffledIndex[i] = 999;
        }

        /* Generate Random Value*/
        for (int i = 0; i < cardNo; i++)
        {
            Rand = Random.Range(0, cardNo);               
            for (int j = 0; j < cardNo; j++)
            {
                if (Rand == shuffledIndex[j])
                {
                    do
                    {
                        Rand = Random.Range(0, cardNo);
                    } while (Rand == shuffledIndex[j]);
                    j = -1;
                }
            }
            shuffledIndex[i] = Rand; 
        }

        /* Assign indices to the Card Object*/
        Transform[] cards = cardprefab.GetComponentsInChildren<Transform>(true);
        int cardIndex = 0;

        for (int i=0; i < cards.Length; i++)
        {
            if (i >= 1)
            {
                cardObjects[shuffledIndex[cardIndex]] = cards[i].gameObject;
                cardIndex++;
            }
        }
            

    }
}
