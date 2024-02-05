using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     void Update()
    {
       if(Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void PlayApp()
    {
        SceneManager.LoadScene("Level01");
    }
    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("Çýkýþ Yapýldý");
    }
    public void AppMenu()
    {
        SceneManager.LoadScene(0);
    }
}
