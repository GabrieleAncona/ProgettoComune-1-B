using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitState : StateBehaviourBase
{

    public override void OnEnter()
    {


        //GameManager.singleton.mc.ActiveMainMenu();
        GameManager.singleton.Setup();
        OnExit();
    }

    public override void OnUpdate()
    {
     
    }

    public override void OnExit()
    {
      
        GameManager.singleton.SetupMainMenu();
    }


}

