using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndturnState : StateBehaviourBase
{

    public override void OnEnter()
    {
      
    }

    public override void OnUpdate()
    {
        if(ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }
    }

    public override void OnExit()
    {
    }


}
