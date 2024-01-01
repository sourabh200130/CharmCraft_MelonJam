using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couldren : MonoBehaviour, interactable
{
    public playerController player;
    public Animator animator;

    public changeColor color;
    public materialController material;
    public void interact(){
        if(player.GetComponent<playerController>().hand != null & player.GetComponent<playerController>().hand.ToString() !="ring" & player.GetComponent<playerController>().hand.ToString() !="neck"  & player.GetComponent<playerController>().hand.ToString() !="tiera" & player.GetComponent<playerController>().hand.ToString() !="earPiecering")
        {
            color.HandleUpdate(player.hand.ToString());
            player.DeleteChildren();
        }
        else{
            animator.SetBool("expl",true);
            
        }
    }
}
