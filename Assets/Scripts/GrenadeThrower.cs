using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] float throwForce = 40f;
    [SerializeField] GameObject grenadePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (WeaponSwitcher.activeWeapon.name == "Grenade")
            {
                ThrowGrenade();
            }
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rd = grenade.GetComponent<Rigidbody>();
        if (rd != null)
        {
            rd.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}

