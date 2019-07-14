using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenùState : StateBehaviourBase
{
   

    public override void OnEnter()
    {
        ///Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        //attivare canvas
        //GameManager.singleton.mc.Play();
        GameManager.singleton.MainMenu();
        GameManager.singleton.musicGame.Stop();
        GameManager.singleton.musicMenu.Play();
    }

    public override void OnUpdate()
    {
        //GameManager.singleton.stateMachine.SMController.SetTrigger("GoToInit");

    }

    public override void OnExit()
    {
        GameManager.singleton.musicMenu.Stop();
        GameManager.singleton.musicGame.Play();
    }



}
