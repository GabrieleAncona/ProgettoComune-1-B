using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : StateBehaviourBase
{

    public override void OnEnter()
    {

        ///controllo informazioni context

        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        if(GameManager.singleton.stateMachine.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.acm.isSelection = true;
        }

        else if(GameManager.singleton.stateMachine.currentPlayer.IdPlayer == 2)
        {
            Debug.Log("funziona correttamente");
        }
        
       // GameManager.singleton.acm.isSelection = true;
     


    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.acm.isSelection = false;
    }

}
