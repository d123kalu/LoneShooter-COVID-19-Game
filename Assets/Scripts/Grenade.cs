using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 2f;
    public float radius = 50f;
    public float force = 1000f;

    public GameObject explosioneffect;

    float countdown;
    bool hasExploaded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploaded)
        {
            Explode();
            hasExploaded = true; 
        }
    }

    void Explode()
    {
        Instantiate(explosioneffect, transform.position, transform.rotation);
        Collider [] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if(dest != null)
            {
               dest.Destroy(); 
            }
        }


        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }



        Destroy(gameObject);

        Debug.Log("BOOM!!");

    }
}
