using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMultipleObjects : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject objectFirst;
    public GameObject objectSecond;
    public GameObject objectThird;

    private GameObject objectToPlace;
    private GameObject checkBeforePlace;
    private GameObject newPlacedObject;
    // Start is called before the first frame update
    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }
    /*
    public void InstantiateObject()
    {
        Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
    }
    */

    public void SetObjectToPlace(GameObject objPrefab)
    {
        objectToPlace = objPrefab;
    }
    public void ClickToPlaceFirst()
    {
        SetObjectToPlace(objectFirst);
    }
    public void ClickToPlaceSecond()
    {
        SetObjectToPlace(objectSecond);
    }    
    public void ClickToPlaceThird()
    {
        SetObjectToPlace(objectThird);
    }

    public void ClickToCheck()
    {
        if (objectToPlace == null)
        {
            return;
        }

        if (checkBeforePlace != null)
        {
            Destroy(checkBeforePlace);
        }
        checkBeforePlace = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
    }
    public void ClickToPlace()
    {
        if (objectToPlace == null)
        {
            return;
        }
        if (checkBeforePlace != null)
        {
            newPlacedObject = checkBeforePlace;
            checkBeforePlace = Instantiate(newPlacedObject, checkBeforePlace.transform.position, checkBeforePlace.transform.rotation);
            Destroy(checkBeforePlace);
        }
        else
        {
            Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
        }
    }
}
