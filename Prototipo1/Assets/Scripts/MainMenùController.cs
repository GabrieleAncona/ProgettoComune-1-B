using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenùController : MonoBehaviour {
    public GameObject menù;
    public GameObject pause;
    public GameObject help;
    public bool menuIsActive;

    public void Awake()
    {
        SetupMainMenu();
    }


    public void SetupMainMenu()
    {
        menù.SetActive(true); 
        menuIsActive = true;
        GameManager.singleton.SMController.SetTrigger("GoToMainMenu");

    }

    public void SetupInitCanvas()
    {
        ///menù.SetActive(false);
        //pause.SetActive(false);
        //menuIsActive = false;
        GameManager.singleton.SMController.SetTrigger("GoToInit");
    }

    public void Play()
    {
       // GameManager.singleton.GoToInit();
        menù.SetActive(false);
        pause.SetActive(false);
        menuIsActive = false;
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
