using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleZombie : MonoBehaviour
{

    public GameObject destroyedVersion; // Reference to the shattered version of the object

    // If the player clicks on the object
    public void Destroy()
    {
        // Spawn a shattered object

        // Remove the current object
        Destroy(gameObject);

        //Instantiate(destroyedVersion, transform.position, transform.rotation);
    }


}
