using UnityEngine;
using UnityEngine.UI;



public class FirstPersonInput : MonoBehaviour {
    [SerializeField] private Transform camera = null;
    [SerializeField] private Animator gunAnimator = null;
    [SerializeField] private GameObject bulletHolePrefab = null;
    [SerializeField] private AudioSource audioSource = null;

    float range = 100f;

    public Text screen;

    public float throwForce = 30f;
    public GameObject grenadePrefab;


    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    private void Shoot() {
        RaycastHit hit;

        LayerMask enemyMask = LayerMask.GetMask("Enemies");
        LayerMask groundMask = LayerMask.GetMask("Ground");

        gunAnimator.SetTrigger("Fire");
        audioSource.PlayDelayed(0.1f);

        if (Physics.Raycast(camera.position, camera.forward, out hit, range, enemyMask)) {
            Debug.Log("Shot an enemy thing:" + hit.collider.name);

            Health enemyHealth = hit.collider.GetComponent<Health>();
            enemyHealth.TakeDamage(25);
            if (enemyHealth.isDead) {
                hit.collider.gameObject.SetActive(false);



                int test = int.Parse(screen.text) + 1;
                screen.text = test.ToString();
            }
        } else if (Physics.Raycast(camera.position, camera.forward, out hit, range, groundMask)) {
            Debug.Log("Shot a wall thing:" + hit.collider.name);

            Instantiate(bulletHolePrefab, 
                hit.point + (0.01f * hit.normal), 
                Quaternion.LookRotation(-1 * hit.normal, hit.transform.up));
        }
    }
}
