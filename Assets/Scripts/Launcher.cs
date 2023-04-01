using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace Hanzo
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        [SerializeField] TMP_InputField roomNameInputfield;
        [SerializeField] TMP_Text errorText;
        [SerializeField] TMP_Text roomNameText;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Connected to Photon Network");
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Joined Master");
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            MenuManager.Instance.OpenMenu("title");

            Debug.Log("Joined Lobby");
        }

        public void CreateRoom()
        {
            if (string.IsNullOrEmpty(roomNameInputfield.text)) return;
            PhotonNetwork.CreateRoom(roomNameInputfield.text);
            MenuManager.Instance.OpenMenu("loading");
        }
        public override void OnJoinedRoom()
        {
            MenuManager.Instance.OpenMenu("room");
            roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            errorText.text = "Room Creation Failed: " + message;
            MenuManager.Instance.OpenMenu("error");
        }

        public void LeaveRoom()
        {
                PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
           MenuManager.Instance.OpenMenu("title");
        }









    }
}

