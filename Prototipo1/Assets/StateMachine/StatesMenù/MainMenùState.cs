using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenùState : StateBehaviourBase
{
   

    public override void OnEnter()
    {

        ///Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        //attivare canvas
        //GameManager.singleton.mc.Play();
        GameManager.singleton.SetupManager();
        GameManager.singleton.MainMenu();
        //if (GameManager.singleton.musicGame != null && GameManager.singleton.musicMenu != null)
        //{
            GameManager.singleton.musicGame.GetComponent<AudioSource>().Stop();
            GameManager.singleton.musicMenu.GetComponent<AudioSource>().Play();
        //}
    }

    public override void OnUpdate()
    {
        //GameManager.singleton.stateMachine.SMController.SetTrigger("GoToInit");
        //if (GameManager.singleton.lm.victoryP1 != null && GameManager.singleton.lm.victoryP2 != null)
        //{
            GameManager.singleton.lm.victoryP1.SetActive(false);
            GameManager.singleton.lm.victoryP2.SetActive(false);
        //}
    }

    public override void OnExit()
    {
        GameManager.singleton.musicMenu.GetComponent<AudioSource>().Stop();
        GameManager.singleton.musicGame.GetComponent<AudioSource>().Play();
    }



}
