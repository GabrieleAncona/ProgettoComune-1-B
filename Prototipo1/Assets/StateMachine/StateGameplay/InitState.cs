using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateBehaviourBase
{
    public float timer;
    public bool isDragonActive;
    public override void OnEnter()
    {
        isDragonActive = true;
        GameManager.singleton.tm.isFightActive = true;
        GameManager.singleton.mc.Play();
       /// GameManager.singleton.mc.panelFight.SetActive(true);
        if (isDragonActive == true)
        {
            GameManager.singleton.animDragon.SetTrigger("GoToInitDrag");
            
        }

        /*if(isDragonActive == false)
        {
            GameManager.singleton.mc.panelFight.SetActive(true);
        }*/
       // timer = 0;

    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= 4)
        {
            GameManager.singleton.mc.panelFight.SetActive(true);
        }

        if (GameManager.singleton.mc.menuIsActive == false && timer >= 6)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }

        Cursor.visible = false;
    }

    public override void OnExit()
    {
        GameManager.singleton.mc.panelFight.SetActive(false);
        timer = 0;
        //GameManager.singleton.tm.blueTurn.SetActive(true);
        GameManager.singleton.tm.isFightActive = false;
        isDragonActive = true;
        GameManager.singleton.animDragon.SetTrigger("GoToIdle");
    }


}

