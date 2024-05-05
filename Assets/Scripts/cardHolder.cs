using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public Transform [] cardSpots;
    private GameObject[] cardMesh;

    void Start()
    {
        cardMesh = new GameObject[26];

        for (int i=0;i < 26;i++)
        {
            cardMesh[i] = GameObject.Find(string.Concat(cardSpots[i].name, "_card"));
            cardMesh[i].transform.position = new Vector3(cardSpots[i].position.x, cardSpots[i].position.y + 0.3f, cardSpots[i].position.z);
            cardMesh[i].transform.rotation = cardSpots[i].rotation;
        }
        
    }

}
