using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenùController : MonoBehaviour {
    public GameObject menù;
    ///public GameObject pause;
   /// public GameObject help;
    public bool menuIsActive;
    public KeyCode pauseButton;
    public KeyCode helpButton;
    public GameObject panelPause;
    public GameObject panelGeneralTutorial;
    public GameObject panelTutorialButtons;
    public GameObject panelTutorialStat;
    public GameObject panelTutorialUnits;
    public GameObject panelFight;
    public bool isActiveTutorial;
    public bool isActivePause;


    private void Awake()
    {
        panelFight.SetActive(true);
    }

    public void Start()
    {
        SetupMainMenu();
        // panelGeneralTutorial.SetActive(false);
        panelFight.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton) && isActivePause == false)
        {
            MenuPause();
            isActivePause = true;
        }

        if (Input.GetKeyDown(helpButton) && isActiveTutorial == false)
        {
            Help();
            isActiveTutorial = true;
        }
    }

    public void SetupMainMenu()
    {
        menù.SetActive(true); 
        menuIsActive = true;
        GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMainMenu");

    }

    public void SetupInitCanvas()
    {
        //menù.SetActive(false);
        //pause.SetActive(false);
        //menuIsActive = false;
        GameManager.singleton.stateMachine.SMController.SetTrigger("GoToInit");
    }

    public void Play()
    {
       // GameManager.singleton.GoToInit();
        menù.SetActive(false);
        ///pause.SetActive(false);
        menuIsActive = false;
    }
    public void QuitGame() 
    {

        Application.Quit();

    }

    public void Restart() 
    {

        SceneManager.LoadScene("Si-Ling");
        GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMainMenu");
    }

    public void MainMenu()
    {
        ///pause.SetActive(false);
        menù.SetActive(false);
    }

    public void MenuPause()
    {
        GameManager.singleton.stateMachine.SMController.SetTrigger("GoToOption");
    }

    public void ResumePause()
    {
       panelPause.SetActive(false);
       GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
    }

    public void Help()
    {
        GameManager.singleton.stateMachine.SMController.SetTrigger("GoToTutorial");
    }
   
    public void HelpExit()
    {
       /// help.SetActive(false);
    }
}
