using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{
    static Animator anim;


    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public Text instructors;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        anim = GetComponent<Animator>();
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    void Update()
    {
        //Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        //Pos.y += 175;
        //ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Nurse"))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();

            if (Input.GetKeyDown(KeyCode.F))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().NPCName();

                anim.SetBool("isTalking", true);
                instructors.text = "Press 'F' to continue conversation";
            }
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;

        anim.SetBool("isTalking", false);
        instructors.text = "Follow The Mission Checkpoint to reach the Camp Entrance";
    }
}

