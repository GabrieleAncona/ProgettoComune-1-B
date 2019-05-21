using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        ///disattivare canvas

       /// GameManager.singleton.hudUnit.isActive = true;
        //GameManager.singleton.InitSM();


    }

    public override void OnUpdate()
    {
        GameManager.singleton.sc.gameObject.GetComponent<MeshRenderer>().enabled = true;
        GameManager.singleton.hudUnit.isActive = true;

        if(ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.sc.isSelectionActive = true;
        }

        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.sc2.isSelectionActive = true;
        }

    }

    public override void OnExit()
    {
        GameManager.singleton.sc.gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameManager.singleton.hudUnit.isActive = false;

        if (ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.sc.isSelectionActive = false;
        }

        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.sc2.isSelectionActive = false;
        }
    }

}
