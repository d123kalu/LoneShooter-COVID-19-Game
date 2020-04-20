using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int maxHP = 100;
    public int hp = 100;
    public bool isDead = false;

    public GameObject deadVersion;

    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damage) {
        this.hp -= damage;

        if (this.hp <= 0) {
            this.hp = 0;
            this.isDead = true;

            //anim.SetBool("isDead", true);

            Destroy(gameObject);
            //Instantiate(deadVersion);
            Instantiate(deadVersion, transform.position, transform.rotation);

        } 
        else {
            this.isDead = false;
        }
    }
}
