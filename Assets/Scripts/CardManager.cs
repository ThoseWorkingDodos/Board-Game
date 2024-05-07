
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/* 
     Script designed to manage decks of card.

     Available functions: 
         1) CardToBottom()  : Moves current card to the bottom of the deck.
         2) ShuffleCards()  : Shuffles spawn order of the cards in a deck.
         3) SpawnCards()    : Spawns the deck of cards based on a prefab.  
*/

public class CardManager : MonoBehaviour
{
    public GameObject cardprefab;
    public GameObject[] cardObjects;
    public Camera player;
    public GameObject bottomButton;
    private int cardNo;
    private ObjectPickup objectPicked;
    private HitBottom hitBottom;

    [SerializeField] private GameObject     currentCard;
    private void Start()
    {
        hitBottom = bottomButton.GetComponent<HitBottom>();
    }

    public void CardToBottom(GameObject[] cards,Transform bottomPos)
    {
        objectPicked = player.GetComponent<ObjectPickup>();

        if (objectPicked.selectedRigidbody)
        {
            if (objectPicked.selectedRigidbody.gameObject.layer == 7)
            {
                currentCard = objectPicked.selectedRigidbody.gameObject;
                if (hitBottom.cardHitBottom)
                {
                    objectPicked.selectedRigidbody = null;
                    for (int i = cardObjects.Length - 1; i > 0; i--)
                    {
                        cards[i] = cards[i - 1];
                        cards[i].transform.position += new Vector3(0, 1f, 0);
                        Rigidbody cardBody = cards[i].GetComponent<Rigidbody>();
                        cardBody.useGravity = false;
                    }
                    cards[0] = currentCard;
                    currentCard.transform.position = bottomPos.position;
                    for (int i = cardObjects.Length - 1; i > 0; i--)
                    {
                        Rigidbody cardBody = cards[i].GetComponent<Rigidbody>();
                        cardBody.useGravity = true;
                    }
                    
                }
                
            }
        }
    }

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
