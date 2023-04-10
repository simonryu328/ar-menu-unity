using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlacementManager : MonoBehaviourPun
{
    // public GameObject objectToPlace;
    private PlaceIndicator placeIndicator;

    //public List<GameObject> Prefabs;
    //Shop_02 object to buy
    public ShopManager leftBtnPrefab;
    public ShopManager middleBtnPrefab;
    public ShopManager rightBtnPrefab;

    public ShopManager leftBtnPrefab1;
    public ShopManager middleBtnPrefab1;
    public ShopManager rightBtnPrefab1;

    public ShopManager leftBtnPrefab2;
    public ShopManager middleBtnPrefab2;
    public ShopManager rightBtnPrefab2;


    private ShopManager objectToBuy;

    private GameObject newARObject;
    private GameObject boughtARObject;
    public GameObject boughtEffect;
    public GameObject placeEffect;

    private string objectName;

    [SerializeField] private TMP_Text selectText;

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
        //if (newARObject == null)
        //{
        //    return;
        //}

        ShopManager selectedObject = GetObjectToBuy();
        // CostManager.Cost += selectedObject.cost;
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("UpdateCost", RpcTarget.AllBuffered, selectedObject.cost);
        // Debug.Log("rpc sent");

        // boughtARObject = Instantiate(newARObject, newARObject.transform.position, newARObject.transform.rotation);
        boughtARObject = PhotonNetwork.Instantiate("PhotonPrefabs/" + objectName, placeIndicator.transform.position, placeIndicator.transform.rotation);
        Destroy(newARObject);
        GameObject newEffect = Instantiate(placeEffect, boughtARObject.transform.position, boughtARObject.transform.rotation);
        Destroy(newEffect, 2f);
    }

    public void PlaceAndConfirm()
    {
        if (newARObject == null)
        {
            PlaceObjectOnClick();
            GameObject.Find("BuyBtn").GetComponentInChildren<Text>().text = "CONFIRM";
        }
        else
        {
            BuyObjectOnClick();
            GameObject.Find("BuyBtn").GetComponentInChildren<Text>().text = "PLACE";
        }
    }

    // public void DeleteObject()
    // {
    //     // PhotonView photonViewScene = PhotonView.Get(this);
    //     // PhotonView photonViewObject = PhotonView.Get(photonViewScene);
    //     PhotonView photonView = PhotonView.Get(this);
    //     PhotonNetwork.Destroy(photonView);
    // }

    [PunRPC]
    public void UpdateCost(int cost)
    {
        CostManager.Cost += cost;
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
        selectText.text = "Selected: Burger";
    }

    public void SelectMiddleBtnOnClick()
    {
        SetObjectToBuy(middleBtnPrefab); //Shop 04 Set prefab
        objectName = "Fries";
        selectText.text = "Selected: Fries";
    }
    public void SelectRightBtnOnClick()
    {
        SetObjectToBuy(rightBtnPrefab); //Shop 04 Set prefab
        objectName = "HotDog";
        selectText.text = "Selected: Hot dog";
    }

    // middle row
    public void SelectLeftBtnOnClick1()
    {
        SetObjectToBuy(leftBtnPrefab1); //Shop 04 Set prefab
        objectName = "Tacos";
        selectText.text = "Selected: Tacos";
    }

    public void SelectMiddleBtnOnClick1()
    {
        SetObjectToBuy(middleBtnPrefab1); //Shop 04 Set prefab
        objectName = "Steak_Cooked";
        selectText.text = "Selected: Steak";
    }
    public void SelectRightBtnOnClick1()
    {
        SetObjectToBuy(rightBtnPrefab1); //Shop 04 Set prefab
        objectName = "Croissant";
        selectText.text = "Selected: Croissant";
    }

    // top row
    public void SelectLeftBtnOnClick2()
    {
        SetObjectToBuy(leftBtnPrefab2); //Shop 04 Set prefab
        objectName = "Wine_Bottle";
        selectText.text = "Selected: Burger";
    }

    public void SelectMiddleBtnOnClick2()
    {
        SetObjectToBuy(middleBtnPrefab2); //Shop 04 Set prefab
        objectName = "Drink_01";
        selectText.text = "Selected: Mojito";
    }
    public void SelectRightBtnOnClick2()
    {
        SetObjectToBuy(rightBtnPrefab2); //Shop 04 Set prefab
        objectName = "Drink_02";
        selectText.text = "Selected: Negroni";
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
