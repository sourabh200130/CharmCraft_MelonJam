using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    public GameObject hint;

public void Start(){
    hint.SetActive(false);
}
public void playgame(){
    SceneManager.LoadScene(1);
}
public void help(){
    hint.SetActive(true);
}
public void close(){
   hint.SetActive(false); 
}

}
