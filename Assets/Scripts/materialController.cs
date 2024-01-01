using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class materialController : MonoBehaviour, interactable
{
    public GameObject prefab;
    public Transform playerTransform;
    public playerController player;

    public void interact(){
       GameObject water =Instantiate(prefab,playerTransform.position, Quaternion.identity);
       water.transform.parent = playerTransform;
       if(gameObject.name != null){
            player.GetComponent<playerController>().hand = gameObject.name;
       }
    }
    public void destroy(){
        Destroy(prefab);
    }
}
