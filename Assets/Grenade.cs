using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
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
        Collider [] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
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

        Destroy(gameObject);

        Debug.Log("BOOM!!");

    }
}
