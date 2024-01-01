using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public Animator animator;
    public playerController player;
    public void HandleUpdate(String color){
        Debug.Log(color);
        if(color == "water")
            animator.SetBool("water",true);
        if(color == "lava")
            animator.SetBool("lava",true);
        if(color == "flower")
            animator.SetBool("flower",true);
        if(color == "liquidMana")
            animator.SetBool("mana",true);

            
    }
}
