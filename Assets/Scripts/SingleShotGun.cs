using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hanzo;

public class SingleShotGun : Gun
{
    [SerializeField]Camera cam;

    public override void Use()
    {
        // Debug.Log("Using Gun "+ itemInfo.itemName);
        Shoot();
    }

    void Shoot(){

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
        }
    }
}
