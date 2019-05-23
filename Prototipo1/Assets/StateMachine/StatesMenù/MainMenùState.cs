using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenùState : StateBehaviourBase
{
    public override void OnEnter()
    {

        //attivare canvas
        GameManager.singleton.GetUiManager().OpenMenu(MenuType.MainMenu);
     
        
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
    }



}
