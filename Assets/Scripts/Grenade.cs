using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float force = 700f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private GameObject explosionEffect;

    private float countdown;
    private bool hasExploded = false;
    
    void Start()
    {
        countdown = delay;
    }
    
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in colliders)
        {
           DestructibleObject destructible = collider.GetComponent<DestructibleObject>();
           
           print(destructible);
            if (destructible != null)
            {
                destructible.ReceiveDamage(damage); 
            }
        
        Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
            
        Destroy(gameObject);
    }
}

