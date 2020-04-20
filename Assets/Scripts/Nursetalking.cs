using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nursetalking : MonoBehaviour
{
    static Animator anim;
    public bool istalking = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("isTalking",true);

        }
    }

    public void OnTriggerExit()
    {
        anim.SetBool("isTalking", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
