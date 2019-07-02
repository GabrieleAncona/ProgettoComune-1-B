using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityState : StateBehaviourBase
{
    private string m_MyTrigger = "GoToAbility";

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        //ctx.previousState = "AbilityState";
        previousStateTrigger = m_MyTrigger;

        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            GameManager.singleton.acm.isAbilityTank = true;
            GameManager.singleton.acm.isAbilityHealer = true;
            GameManager.singleton.acm.isAbilityUtility = true;
            GameManager.singleton.acm.isAbilityDealer = true; 
        }

        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            GameManager.singleton.acm.isAbilityTank2 = true;
            GameManager.singleton.acm.isAbilityHealer2 = true;
            GameManager.singleton.acm.isAbilityUtility2 = true;
            GameManager.singleton.acm.isAbilityDealer2 = true; 
        }
        
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            GameManager.singleton.acm.isAbilityTank = false;
            GameManager.singleton.acm.isAbilityHealer = false;
            GameManager.singleton.acm.isAbilityUtility = false;
            GameManager.singleton.acm.isAbilityDealer = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 2;
            buttonNavigation.ChangeImageButton();
        }

        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            GameManager.singleton.acm.isAbilityTank2 = false;
            GameManager.singleton.acm.isAbilityHealer2 = false;
            GameManager.singleton.acm.isAbilityUtility2 = false;
            GameManager.singleton.acm.isAbilityDealer2 = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 2;
            buttonNavigation.ChangeImageButton();
        }
    }
}
