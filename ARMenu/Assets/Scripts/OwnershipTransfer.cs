using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Lean.Touch;

public class OwnershipTransfer : MonoBehaviourPun
{
    void OnEnable() {
        LeanTouch.OnFingerDown += TransferOwnership; 
    }

    void OnDisable() {
        LeanTouch.OnFingerDown -= TransferOwnership;
    }

    void TransferOwnership(LeanFinger finger) {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RequestOwnership();
    }
}
