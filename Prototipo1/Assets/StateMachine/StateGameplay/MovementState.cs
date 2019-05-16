﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : StateBehaviourBase
{
    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        ///disattivare canvas

        GameManager.singleton.acm.isMovement = true;
        //GameManager.singleton.InitSM();


    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.acm.isMovement = false;
    }

}
