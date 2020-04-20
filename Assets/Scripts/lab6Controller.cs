using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab6Controller : MonoBehaviour
{
    static Animator anim;

    public float speed = 20.0F;
    public float rotationSpeed = 100.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        if (translation != 0)
        {
            anim.SetFloat("speed", 2);
        }
        else 
        {
            //anim.SetBool("isRunning", false);
            anim.SetFloat("speed", 0);
        }
        
    }
}
