using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenùState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);


        GameManager.singleton.acm.isActionMenu = true;

    }

    public override void OnUpdate()
    {
        if (ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.acm.menuActionPlayer1.SetActive(true);
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.acm.menuActionPlayer2.SetActive(true);
        }
    }

    public override void OnExit()
    {
        GameManager.singleton.acm.isActionMenu = false;
        if (ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.acm.menuActionPlayer1.SetActive(false);
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.acm.menuActionPlayer2.SetActive(false);
        }
    }

}
