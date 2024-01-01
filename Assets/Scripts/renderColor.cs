using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderColor : MonoBehaviour, interactable
{
    public playerController player;
    private List<string> stringList = new List<string> { "ring","earPiecering","tiera","neck" };
    private GameObject prefab;
    public GameObject ring;
    public GameObject earPiercing;
    public GameObject tiera;
    public GameObject neck;

    public Transform playerTransform;
    public String color;


    public void interact(){     
        
        if(stringList.Contains(player.GetComponent<playerController>().hand)){
        
            switch (player.GetComponent<playerController>().hand){
                case "ring":
                    prefab = ring; 
                    break;
                case "earPiecering":
                    prefab = earPiercing;
                    break;
                case "tiera":
                    prefab = tiera;
                    break;
                case "neck":
                    prefab = neck;
                    break;
                default:
                    Debug.LogWarning("error ");
                    break;
            }

        player.DeleteChildren();
        GameObject instantiatedPrefab =Instantiate(prefab,playerTransform.position, Quaternion.identity);
        instantiatedPrefab.transform.parent = playerTransform;

        Renderer[] renderers = instantiatedPrefab.GetComponentsInChildren<Renderer>(true);

  
        ChangeColor(renderers,color);

        }
        else{
            Debug.Log("hand empty");
        }
    }
    void ChangeColor(Renderer[] renderers,string color)
    {
        foreach (Renderer renderer in renderers)
        {
            foreach (Material material in renderer.materials)
            {
            switch (color){
                case "red":
                    material.color = Color.red;
                    break;
                case "green":
                    material.color = Color.green;
                    break;
                case "blue":
                    material.color = Color.blue;
                    break;
                case "pink":
                    material.color = new Color(1f, 0.75f, 0.79f); // RGB values for pink
                    Debug.Log("pink");
                    break;
                default:
                    Debug.LogWarning("Unsupported color name: " + color);
                    break;
            }
            }
        }
    }
}
