using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlacementManager : MonoBehaviour
{
    // public GameObject objectToPlace;
    private PlaceIndicator placeIndicator;

    //Shop_02 object to buy
    public ShopManager leftBtnPrefab;
    public ShopManager middleBtnPrefab;
    public ShopManager rightBtnPrefab;
    private ShopManager objectToBuy;

    private GameObject newARObject;
    private GameObject boughtARObject;
    public GameObject boughtEffect;
    public GameObject placeEffect;

    void Start()
    {        
        placeIndicator = FindObjectOfType<PlaceIndicator>();    
    }

    
    void Update()
    {
       
    }

    //---------------Place and Buy----------------//

    public void PlaceObjectOnClick()
    {
        if (GetObjectToBuy() == null)
            return;

        ShopManager selectedObject = GetObjectToBuy();

        //Destroy old object
        if (newARObject != null)
        {
            Destroy(newARObject);
        }

        //Instantiate object  
        newARObject = Instantiate(selectedObject.purchasedItem, placeIndicator.transform.position, placeIndicator.transform.rotation);
        GameObject newEffect = Instantiate(placeEffect, placeIndicator.transform.position, placeIndicator.transform.rotation);
        Destroy(newEffect, 2f);
    }

    public void BuyObjectOnClick()
    {
        if (newARObject == null)
        {
            return;
        }

        ShopManager selectedObject = GetObjectToBuy();
        CostManager.Cost += selectedObject.cost;

        boughtARObject = Instantiate(newARObject, newARObject.transform.position, newARObject.transform.rotation);
        Destroy(newARObject);
        GameObject newEffect = Instantiate(boughtEffect, boughtARObject.transform.position, boughtARObject.transform.rotation);
        Destroy(newEffect, 2f);
    }

    //---------------SHOP----------------//

    //Shop 03_Setup
    public ShopManager GetObjectToBuy()
    {
        return objectToBuy;
    }

    public void SetObjectToBuy(ShopManager objPrefab)
    {
        objectToBuy = objPrefab;
    }

    //Shop 01_ To setup Button
    public void SelectLeftBtnOnClick()
    {
        SetObjectToBuy(leftBtnPrefab); //Shop 04 Set prefab
    }

    public void SelectMiddleBtnOnClick()
    {
        SetObjectToBuy(middleBtnPrefab); //Shop 04 Set prefab
    }
    public void SelectRightBtnOnClick()
    {
        SetObjectToBuy(rightBtnPrefab); //Shop 04 Set prefab
    }


    //---------------Rotate And Scale----------------//

    //Creat Button
    public void RotateClockOnClick()
    {
        newARObject.transform.Rotate(Vector3.up, 10f);
    }

    public void RotateAntiClockOnClick()
    {
        newARObject.transform.Rotate(Vector3.up, -10f);
    }

    public void ScaleUpOnClick()
    {
        newARObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void ScaleDownOnClick()
    {
        newARObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }


}
