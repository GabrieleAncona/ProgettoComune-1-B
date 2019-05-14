using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateBehaviourBase
{
    

    public override void OnEnter()
    {
        ///setup context

        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        
        ///disattiva canvas
        GameManager.singleton.mc.Play();
        //GameManager.singleton.InitSM();
        //GameManager.singleton.SetupManager();
    }

    public override void OnUpdate()
    {
        if (GameManager.singleton.mc.menuIsActive == false)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }
    }

    public override void OnExit()
    {
        
    }


}

