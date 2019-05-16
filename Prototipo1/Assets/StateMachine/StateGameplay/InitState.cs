using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        ///disattivare canvas

        GameManager.singleton.mc.Play();
        //GameManager.singleton.InitSM();
        
        
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

