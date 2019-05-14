﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenùState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        GameManager.singleton.SetupActionMenu();


    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }

}
