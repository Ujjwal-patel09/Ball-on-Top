using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_manager : MonoBehaviour
{
    [SerializeField] GameObject pause_panal;

    public void pause(){
        pause_panal.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        pause_panal.SetActive(false);
        Time.timeScale = 1f;
    }

    public void menu(){
        Time.timeScale =1f;
        SceneManager.LoadScene(1);
    }

    public void start1(){
       SceneManager.LoadScene(1);
    }

    public void play(){
        SceneManager.LoadScene(2);
    }

    public void controls(){
        SceneManager.LoadScene(4);
    }

    public void exit(){
        Application.Quit();
    }


}
