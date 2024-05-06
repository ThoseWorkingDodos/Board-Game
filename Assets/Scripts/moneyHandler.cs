using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MoneyHandler : MonoBehaviour
{
    public GameObject[] moneyTypes;
    void Start()
    {
        StartAmounts();
    }

    void StartAmounts()
    {
        Vector3 position = transform.position;
        int[] amounts = {5,5,5,6,2,2,2};

        for (int i = 0; i < moneyTypes.Length; i++) 
        {
            for (int j = 0; j < amounts[i]; j++)
            {
                GameObject temp = Instantiate(moneyTypes[i], position + new Vector3(0, 0.01f * j, -0.2f*j), transform.rotation);
                temp.transform.parent = transform;
            }
            position += new Vector3(0.75f, 0, 0);
        }
        
    }
















}
