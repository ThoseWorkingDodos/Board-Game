using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* Creates a building object on interaction with the UI button. */
public class AddBuilding : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private Transform  spawnLocation;
    [SerializeField] private int        noOfBuildings;
    public void AddBuildings()
    {
        GameObject hotels = Instantiate(building, spawnLocation, false);
        hotels.transform.position = spawnLocation.position + new Vector3(noOfBuildings * 0.2f, 0, 0);
        noOfBuildings += 1;

        if (noOfBuildings > 100)
        {
            Destroy(hotels);
        }
    }
}
