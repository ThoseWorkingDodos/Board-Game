using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private int moneyAmount;

    public void spawnMoney()
    {
        GameObject money = Instantiate(moneyPrefab, spawnLocation, false);
        money.transform.position = spawnLocation.position + new Vector3(0, moneyAmount * 0.2f, 0);
        moneyAmount += 1;
    }
}
