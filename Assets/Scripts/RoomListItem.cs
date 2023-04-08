using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

namespace Hanzo
{
    public class RoomListItem : MonoBehaviour
    {
        [SerializeField] TMP_Text text;

        private RoomInfo info;

        public RoomInfo Info
        {
            get { return info; }
            set { info = value; }
        }
        

        public void Setup(RoomInfo _info)
        {
            Info = _info;
            text.text = _info.Name;

        }

        public void OnClick()
        {
            Launcher.Instance.JoinRoom(info);
        }








    }


}
