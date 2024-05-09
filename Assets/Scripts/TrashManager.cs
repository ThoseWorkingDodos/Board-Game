using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Designed to delete trashable items on contact with trash circle. */
public class TrashManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
            Destroy(collision.gameObject);
    }
}
