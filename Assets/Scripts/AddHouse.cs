using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHouse : MonoBehaviour
{
    [SerializeField] private GameObject house;
    [SerializeField] private Transform  spawnLocation;
    [SerializeField] private int        noOfHouses;

    private void Awake()
    {
        noOfHouses = 0;
    }
    public void addhouse()
    {
        GameObject houses = Instantiate(house, spawnLocation, false);
        houses.transform.position = spawnLocation.position + new Vector3(noOfHouses * 0.2f, 0,0);
        noOfHouses += 1;
    }
}
