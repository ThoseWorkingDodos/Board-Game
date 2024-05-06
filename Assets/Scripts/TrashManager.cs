using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
            Destroy(collision.gameObject);
    }
}
