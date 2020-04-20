using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieControl : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis ("Vertical") * moveSpeed;

        move *= Time.deltaTime;
        transform.Translate (0, 0, move);

        if(move != 0)
        {
            anim.SetBool ("isMove", true);
        }
        else 
        {
            anim.SetBool ("isMove", false);
        }
    }
}
