using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

namespace Hanzo
{
    public class PlayerManager : MonoBehaviour
    {
        PhotonView PV;

        GameObject controller;

        
        // Start is called before the first frame update
        void Start()
        {
            if (PV.IsMine)
                CreateController();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void CreateController()
        {
            //Instantiate player controller
            Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
            controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[]{PV.ViewID});
            Debug.Log("Instantiated Player Controller");

        }

        public void Die(){
            PhotonNetwork.Destroy(controller);
            CreateController();
        }






    }


}
