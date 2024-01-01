using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class npcController : MonoBehaviour, interactable
{
    public playerController player;
    public GameObject dialogueBox;
    public Text dialogueText; 
    public List<string> npcDialogueList = new List<string>();
    public Animator animator;
    private int currentDialogueIndex = 0;
    public GameObject next; 
    public Animator signal;


    public List<string> answer = new List<string>();
    void Start()
    {
        dialogueBox.SetActive(false);
        dialogueText = dialogueBox.GetComponentInChildren<Text>();
        SetDialogueText();
    }

    public void interact()
    {
        if(player.answer.Count>0){
            player.DeleteChildren();
            animator.SetBool("expl", false);
            animator.SetBool("lava", false);
            animator.SetBool("mana", false);
            animator.SetBool("flower", false);
            animator.SetBool("water", false);
            if(player.answer.SequenceEqual(answer) ){
                Debug.Log("Correct");
                signal.SetBool("green",true);
                signal.SetBool("red",false);
                player.answer.Clear();
                player.hand=null;
                next.transform.position = transform.position;
                transform.position = new Vector3(-4,25,0);
                
            }
            else{
                signal.SetBool("green",false);
                signal.SetBool("red",true);
                player.answer.Clear();
            }
        }
        
        else{
        dialogueBox.SetActive(true);
        currentDialogueIndex++;

        if (currentDialogueIndex < npcDialogueList.Count)
        {
            SetDialogueText();
        }
        else
        {
            dialogueBox.SetActive(false);
            currentDialogueIndex = -1;
        }
        }
    }

    void SetDialogueText()
    {
        if (dialogueText != null && npcDialogueList != null && currentDialogueIndex < npcDialogueList.Count)
        {
            dialogueText.text = npcDialogueList[currentDialogueIndex];
        }
    }

}
