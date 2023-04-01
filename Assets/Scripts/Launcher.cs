using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

namespace Hanzo
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        public static Launcher Instance;

        [SerializeField] TMP_InputField roomNameInputfield;
        [SerializeField] TMP_Text errorText;
        [SerializeField] TMP_Text roomNameText;

        public Transform roomListBG;
        public GameObject roomListPrefab;

        private void Awake()
        {
            Instance = this;
        }

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

        public void JoinRoom(RoomInfo info)
        {
            PhotonNetwork.JoinRoom(info.Name);
            MenuManager.Instance.OpenMenu("loading");
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                Instantiate(roomListPrefab, roomListBG).GetComponent<RoomListItem>().Setup(roomList[i]);
            }
        }









    }
}

