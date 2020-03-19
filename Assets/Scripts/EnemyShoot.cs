using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public float range = 100f;
    public int damage = 25;
    public GameObject player;
    public float coolDown = 1.0f;
    public float lastShootTime = 0.0f;

    void Update() {
        transform.LookAt(player.transform.position);
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag != "Player")
            return;

        if (Time.time > (lastShootTime + coolDown)) {
            RaycastHit hit;
            LayerMask playerMask = LayerMask.GetMask("Player");
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, playerMask)) {
                //Debug.Log("I shot you!");
            }
        }
    }
}
