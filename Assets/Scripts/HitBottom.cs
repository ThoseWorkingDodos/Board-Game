using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBottom : MonoBehaviour
{
    public bool cardHitBottom;

    private void Awake()
    {
        cardHitBottom = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent == transform.parent)
        {
            cardHitBottom = true;
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        cardHitBottom = false;
    }

}

