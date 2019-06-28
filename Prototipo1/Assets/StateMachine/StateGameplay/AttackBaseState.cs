using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBaseState : StateBehaviourBase
{
    

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        GameManager.singleton.acm.isAttackTank = true;
        GameManager.singleton.acm.isAttackTank2 = true;
        GameManager.singleton.acm.isAttackHealer = true;
        GameManager.singleton.acm.isAttackHealer2 = true;
        GameManager.singleton.acm.isAttackUtility = true;
        GameManager.singleton.acm.isAttackUtility2 = true;
        GameManager.singleton.acm.isAttackDealer = true;
        GameManager.singleton.acm.isAttackDealer2 = true;
        

    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            GameManager.singleton.acm.isAttackTank = false;
            GameManager.singleton.acm.isAttackHealer = false;
            GameManager.singleton.acm.isAttackUtility = false;
            GameManager.singleton.acm.isAttackDealer = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 1;
            buttonNavigation.ChangeImageButton();
        }

        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            GameManager.singleton.acm.isAttackTank2 = false;
            GameManager.singleton.acm.isAttackHealer2 = false;
            GameManager.singleton.acm.isAttackUtility2 = false;
            GameManager.singleton.acm.isAttackDealer2 = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 1;
            buttonNavigation.ChangeImageButton();
        }
    }

}
