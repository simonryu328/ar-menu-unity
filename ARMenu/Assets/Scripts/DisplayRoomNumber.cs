using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRoomNumber : MonoBehaviour
{
    [SerializeField]
    private Text roomNumber;

    public void DisplayRoomName(string text)
    {
        roomNumber.text = PhotonNetwork.CurrentRoom.Name;
    }
}
