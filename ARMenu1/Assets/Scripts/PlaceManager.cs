using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlaceIndicator placeIndicator;
    public GameObject objectToPlace;
    private GameObject newPlacedObject;
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    public void ClickToPlace()
    {
        newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
    }
}
