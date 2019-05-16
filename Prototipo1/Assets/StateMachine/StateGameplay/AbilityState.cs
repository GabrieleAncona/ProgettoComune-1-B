using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        GameManager.singleton.acm.isAbility = true;


    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.acm.isAbility = true;
    }

}
