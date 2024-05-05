
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardManager : MonoBehaviour
{
    public GameObject cardprefab;

    [SerializeField] private GameObject[] cardObjects;
    [SerializeField] private int cardNo;
    void Start()
    {
        cardNo = cardprefab.transform.childCount;
        cardObjects = new GameObject[cardNo];
        Debug.Log(cardNo);
        ShuffleCards();
    }


    private void ShuffleCards()
    {
        int Rand;
        int[] temp = new int[cardNo];

        for (int i = 0; i < cardNo; i++)
        {
            temp[i] = 999;
        }

        /* Generate Random Value*/
        for (int i = 0; i < cardNo; i++)
        {
            Rand = Random.Range(0, cardNo);               
            for (int j = 0; j < cardNo; j++)
            {
                if (Rand == temp[j])
                {
                    do
                    {
                        Rand = Random.Range(0, cardNo);
                    } while (Rand == temp[j]);
                    j = 0;
                }
            }
            temp[i] = Rand; 
        }

        /* Assign indices to the Card Object*/
        Transform[] cards = cardprefab.GetComponentsInChildren<Transform>(true);
        int cardIndex = 0;
        Debug.Log(cards.Length);
        for (int i=0; i < cards.Length; i++)
        {
            if (i >= 1)
            {
                cardObjects[cardIndex] = cards[i].gameObject;
                cardIndex++;
                Debug.Log($"Card Name: {cards[i].gameObject.name}");
            }
        }
            

    }
}
