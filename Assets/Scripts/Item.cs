using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanzo
{
    public abstract class Item : MonoBehaviour
    {
        public ItemInfo itemInfo;
        public GameObject itemGameObject;

        public abstract void Use();
        
    }

}
