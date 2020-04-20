using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC2 : MonoBehaviour
{
    static Animator anim;


    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem2 dialogueSystem2;

    public string Name; 

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        anim = GetComponent<Animator>();
        dialogueSystem2 = FindObjectOfType<DialogueSystem2>();

        //this.gameObject.GetComponent<NPC2>().enabled = true;
        FindObjectOfType<DialogueSystem2>().EnterRangeOfNPC();

            //this.gameObject.GetComponent<NPC2>().enabled = true;
            dialogueSystem2.Names = Name;
            dialogueSystem2.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem2>().NPCName();

            
    }

    void Update()
    {
        //Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        //Pos.y += 175;
        //ChatBackGround.position = Pos;
    }
    /*
    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC2>().enabled = true;
        FindObjectOfType<DialogueSystem2>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC2>().enabled = true;
            dialogueSystem2.Names = Name;
            dialogueSystem2.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem2>().NPCName();

            anim.SetBool("isTalking", true);
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem2>().OutOfRange();
        this.gameObject.GetComponent<NPC2>().enabled = false;

        anim.SetBool("isTalking", false);
    }
    */
}

