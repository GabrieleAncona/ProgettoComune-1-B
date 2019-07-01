using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionState : StateBehaviourBase
{
    public override void OnEnter()
    {
        GameManager.singleton.mc.panelPause.SetActive(true);

        
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(GameManager.singleton.mc.pauseButton) && GameManager.singleton.mc.isActivePause == true)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger(StateBehaviourBase.previousStateTrigger);

        }
    }

    public override void OnExit()
    {
        GameManager.singleton.mc.panelPause.SetActive(false);
        GameManager.singleton.mc.isActivePause = false;
    }



}

