using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustbin : MonoBehaviour, interactable
{
    public playerController player;
    public Animator cauldrin;
public void interact(){
    Debug.Log("in");
    player.answer.Clear();
    player.hand=null;
    cauldrin.SetBool("water",false);
    cauldrin.SetBool("lava",false);
    cauldrin.SetBool("flower",false);
    cauldrin.SetBool("mana",false);
    player.DeleteChildren();
}
}
