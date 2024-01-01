using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    public LayerMask solidObjectsLayer;
    private Animator animator;

    public LayerMask material;
    public LayerMask npc;
    public String hand;
    public List<string> answer = new List<string>();

    private void Awake(){
        
        

        animator = GetComponent<Animator>();
    }
    private void Update(){
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

        if(input.x!=0) input.y=0;

        if(input != Vector2.zero){
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            var targetpos = transform.position;
            targetpos.x += input.x;
            targetpos.y += input.y;

            if(iswalkable(targetpos))
            StartCoroutine(move(targetpos));
        }
        }
        if(Input.GetKeyDown(KeyCode.Z))
            interact();
    }
    void interact(){
        
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos , Color.red, 1f);
        var collider = Physics2D.OverlapCircle(interactPos, 0.4f, material);
        if(collider!=null){
            if(collider.ToString()!="couldren (UnityEngine.BoxCollider2D)" & collider.ToString()!="npc1 (UnityEngine.CapsuleCollider2D)")
            answer.Add(collider.ToString());
            collider.GetComponent<interactable>()?.interact();
        }
        var npccollider = Physics2D.OverlapCircle(interactPos, 0.4f, npc);
        if(npccollider!=null){
            npccollider.GetComponent<interactable>()?.interact();
        }
    }

    IEnumerator move(Vector3 targetpos){
        isMoving = true;
        animator.SetBool("isMoving", true);
        while((targetpos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetpos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetpos;
        isMoving = false;
        animator.SetBool("isMoving", false);
    }

    private bool iswalkable(Vector3 targetpos){
        if(Physics2D.OverlapCircle(targetpos, 0.1f, solidObjectsLayer | material | npc)!= null){
            return false;
        }
        return true;
    }
    public void DeleteChildren(){
        
        
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            if (transform.GetChild(i).gameObject != Camera.main.gameObject)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

    
    }


}
