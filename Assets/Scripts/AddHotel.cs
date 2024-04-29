using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddHotel : MonoBehaviour
{
    [SerializeField] private GameObject hotel;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private int noOfHotels;
    public void addHotel()
    {
        GameObject hotels = Instantiate(hotel, spawnLocation, false);
        hotels.transform.position = spawnLocation.position + new Vector3(noOfHotels * 0.2f, 0, 0);
        noOfHotels += 1;
    }
}
