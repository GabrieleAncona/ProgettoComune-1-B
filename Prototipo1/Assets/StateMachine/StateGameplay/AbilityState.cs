﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        GameManager.singleton.acm.isAbilityTank = true;
        GameManager.singleton.acm.isAbilityTank2 = true;
        GameManager.singleton.acm.isAbilityHealer = true;
        GameManager.singleton.acm.isAbilityHealer2 = true;
        GameManager.singleton.acm.isAbilityUtility = true;
        GameManager.singleton.acm.isAbilityUtility2 = true;
        GameManager.singleton.acm.isAbilityDealer = true;
        GameManager.singleton.acm.isAbilityDealer2 = true;


    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.acm.isAbilityTank = false;
        GameManager.singleton.acm.isAbilityTank2 = false;
        GameManager.singleton.acm.isAbilityHealer = false;
        GameManager.singleton.acm.isAbilityHealer2 = false;
        GameManager.singleton.acm.isAbilityUtility = false;
        GameManager.singleton.acm.isAbilityUtility2 = false;
        GameManager.singleton.acm.isAbilityDealer = false;
        GameManager.singleton.acm.isAbilityDealer2 = false;
    }

}
