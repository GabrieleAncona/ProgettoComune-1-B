using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        
        ///disattiva canvas
        GameManager.singleton.mc.Play();
        //GameManager.singleton.InitSM();
        //GameManager.singleton.SetupManager();
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {

    }


}

