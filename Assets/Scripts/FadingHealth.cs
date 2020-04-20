using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingHealth : MonoBehaviour
{
    public Image overlayImage;
    private float r;
    private float g;
    private float b;
    private float a;


    public float health = 100.0f;
    float maxHealth = 100.0f;
    bool beinghit = false;

    public GameObject DeadPanel;

    public void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Zombie")
        {
            beinghit = true;
        }


        if (col.gameObject.tag == "Supplies")
        {

        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            beinghit = false;
        }
    }

    private void Start()
    {
        r = overlayImage.color.r;
        g = overlayImage.color.g;
        b = overlayImage.color.b;
        a = overlayImage.color.a;
    }

    private void AdjustColor()
    {
        Color c = new Color(r, g, b, a);
        overlayImage.color = c;
    }

    void Update()
    {

        if (health > 0 && beinghit == true)
        {
            health -= Time.deltaTime;
            a += 0.003f;
        }

        if (health >= 0 && beinghit == false)
        {
            health += Time.deltaTime;
            a -= 0.001f;
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }


        if (a >= 1)
        {
            //Time.timeScale = 0;
            DeadPanel.SetActive(true);
        }


        a = Mathf.Clamp(a, 0, 1f);
        AdjustColor();
    }
}

