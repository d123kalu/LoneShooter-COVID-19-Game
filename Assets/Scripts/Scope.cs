using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    private bool isScoped = false;

    public GameObject scopedOverlay;
    public GameObject weaponCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            scopedOverlay.SetActive(isScoped);

            if (isScoped)
                OnScoped();
            else
                OnUnScoped();
        }
    }

    void OnUnScoped()
    {
        scopedOverlay.SetActive(false);
        weaponCamera.SetActive(true);
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopedOverlay.SetActive(true);
        weaponCamera.SetActive(false);
    }
}
