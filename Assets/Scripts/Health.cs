using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int maxHP = 100;
    public int hp = 100;
    public bool isDead = false;




    public void TakeDamage(int damage) {
        this.hp -= damage;

        if (this.hp <= 0) {
            this.hp = 0;
            this.isDead = true;


        } 
        else {
            this.isDead = false;
        }
    }
}
