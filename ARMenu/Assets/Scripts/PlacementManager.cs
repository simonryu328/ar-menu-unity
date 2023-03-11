using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;

public class PlacementManager : MonoBehaviour
{
    // public GameObject objectToPlace;
    private PlaceIndicator placeIndicator;

    //public List<GameObject> Prefabs;
    //Shop_02 object to buy
    public ShopManager leftBtnPrefab;
    public ShopManager middleBtnPrefab;
    public ShopManager rightBtnPrefab;
    private ShopManager objectToBuy;

    private GameObject newARObject;
    private GameObject boughtARObject;
    public GameObject boughtEffect;
    public GameObject placeEffect;

    private string objectName;

    void Start()
    {        
        placeIndicator = FindObjectOfType<PlaceIndicator>();    
        // DefaultPool pool = PhotonNetwork.PrefabPool as DefaultPool;
        // if (pool != null && this.Prefabs != null)
        // {
        //     foreach (GameObject prefab in this.Prefabs)
        //     {
        //         pool.ResourceCache.Add(prefab.name, prefab);
        //     }
        // }
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
        // newARObject = PhotonNetwork.Instantiate("PhotonPrefabs/" + objectName, placeIndicator.transform.position, placeIndicator.transform.rotation);
        // if (objectName == "Burger")
        // {
        //     newARObject = PhotonNetwork.Instantiate("PhotonPrefabs/" + objectName, placeIndicator.transform.position, placeIndicator.transform.rotation);
        // } else if (objectName == "Fries") {
        //     newARObject = PhotonNetwork.Instantiate(objectName, placeIndicator.transform.position, placeIndicator.transform.rotation);
        // } else {
        //     newARObject = Instantiate(selectedObject.purchasedItem, placeIndicator.transform.position, placeIndicator.transform.rotation);
        // }
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

        // boughtARObject = Instantiate(newARObject, newARObject.transform.position, newARObject.transform.rotation);
        boughtARObject = PhotonNetwork.Instantiate("PhotonPrefabs/" + objectName, newARObject.transform.position, newARObject.transform.rotation);
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
        objectName = "Burger";
    }

    public void SelectMiddleBtnOnClick()
    {
        SetObjectToBuy(middleBtnPrefab); //Shop 04 Set prefab
        objectName = "Fries";
    }
    public void SelectRightBtnOnClick()
    {
        SetObjectToBuy(rightBtnPrefab); //Shop 04 Set prefab
        objectName = "HotDog";
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
