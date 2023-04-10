using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Lean.Touch;

public class DeleteObject : MonoBehaviourPun
{
    void OnEnable() {
        LeanTouch.OnFingerTap += DeleteGameObject;
    }

    void OnDisable() {
        LeanTouch.OnFingerTap -= DeleteGameObject;
    }

    void DeleteGameObject(LeanFinger finger) {
        PhotonView photonView = PhotonView.Get(this);
        PhotonNetwork.Destroy(photonView);
    }
}
