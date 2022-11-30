using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicator : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject visual;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        //Get the component
        raycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        //hide the placement visual
        visual.SetActive(false);
    }


    void Update()
    {
        //Shoot a racat from the center of the screen
        var ray = new Vector2(Screen.width / 2, Screen.height / 2);

        //if hit AR planes, update the position and roatation
        if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
        {
            //find first position of hit in AR raycast
            Pose pose = hits[0].pose;

            transform.position = pose.position;
            transform.rotation = pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }
}
