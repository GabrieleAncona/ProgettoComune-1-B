using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuController : MonoBehaviour {
    public bool isMovement;
    public bool isAttack;
    public bool isAbility;
    public bool isSelection;
    public bool isActionMenu;

    // Use this for initialization
    void Start ()
    {
        ///starta con il movimento attivo
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Movement()
    {
        if (isActionMenu == true)
        {
            
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMovement");
        }
    }

    public void Attack()
    {
        if (isActionMenu == true)
        {
           
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToAttack");
        }
    }

    public void Ability()
    {
            if (isActionMenu == true)
            {
               
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToAbility");
            }
    }

    public void BackSelection()
    {
         if (isActionMenu == true)
         {
            if (GameManager.singleton.sc.isActiveTank == true)
            {
                GameManager.singleton.sc.isActiveTank = false;
            }
            else if (GameManager.singleton.sc.isActiveHealer == true)
            {
                GameManager.singleton.sc.isActiveHealer = false;
            }
            else if (GameManager.singleton.sc.isActiveUtility == true)
            {
                GameManager.singleton.sc.isActiveUtility = false;
            }
            else if (GameManager.singleton.sc.isActiveDealer == true)
            {
                GameManager.singleton.sc.isActiveDealer = false;
            }
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
         }
    }

    public void SetupActionMenu()
    {
        
    }
}
