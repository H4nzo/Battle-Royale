using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class UsernameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView PV;
    [SerializeField] TMP_Text usernameText;

    private void Start()
    {
        if (PV.IsMine)
        {
            gameObject.SetActive(false);
        }
        usernameText.text = PV.Owner.NickName;

    }
}
