using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateBehaviourBase
{
    public float timer;

    public override void OnEnter()
    {
        GameManager.singleton.tm.isFightActive = true;
        GameManager.singleton.mc.Play();
        GameManager.singleton.mc.panelFight.SetActive(true);
        timer = 0;
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (GameManager.singleton.mc.menuIsActive == false && timer >= 3)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }
    }

    public override void OnExit()
    {
        GameManager.singleton.mc.panelFight.SetActive(false);
        timer = 0;
        //GameManager.singleton.tm.blueTurn.SetActive(true);
        GameManager.singleton.tm.isFightActive = false;
    }


}

