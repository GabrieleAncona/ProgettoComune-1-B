using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenùController : MonoBehaviour {
    public GameObject menù;
    public GameObject pause;
    public GameObject help;

    public void Play()
    {

        menù.SetActive(false);
        pause.SetActive(false);
    }

    public void QuitGame() 
    {

        Application.Quit();

    }

    public void Restart() 
    {

        SceneManager.LoadScene("BLOCKOUT");

    }

    public void MainMenu()
    {
        pause.SetActive(false);
        menù.SetActive(false);
    }

    public void MenùPause()
    {
        pause.SetActive(true);
    }

    public void ResumePause()
    {
        pause.SetActive(false);
    }

    public void Help()
    {
        help.SetActive(true);
    }
   
    public void HelpExit()
    {
        help.SetActive(false);
    }
}
