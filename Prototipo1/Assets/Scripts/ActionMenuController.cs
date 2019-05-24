using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuController : MonoBehaviour
{
    public bool isMovement;
    public bool isAttackTank;
    public bool isAttackTank2;
    public bool isAttackHealer;
    public bool isAttackHealer2;
    public bool isAttackUtility;
    public bool isAttackUtility2;
    public bool isAttackDealer;
    public bool isAttackDealer2;
    public bool isAbilityTank;
    public bool isAbilityTank2;
    public bool isAbilityHealer;
    public bool isAbilityHealer2;
    public bool isAbilityUtility;
    public bool isAbilityUtility2;
    public bool isAbilityDealer;
    public bool isAbilityDealer2;
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

    /// <summary>
    /// funzione backselection player1
    /// </summary>
    public void BackSelectionPlayer1()
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

    /// <summary>
    /// funzione backselection Player2
    /// </summary>
    public void BackSelectionPlayer2()
    {
        if (isActionMenu == true)
        {
            if (GameManager.singleton.sc2.isActiveTankP2 == true)
            {
                GameManager.singleton.sc2.isActiveTankP2 = false;
            }
            else if (GameManager.singleton.sc2.isActiveHealerP2 == true)
            {
                GameManager.singleton.sc2.isActiveHealerP2 = false;
            }
            else if (GameManager.singleton.sc2.isActiveUtilityP2 == true)
            {
                GameManager.singleton.sc2.isActiveUtilityP2 = false;
            }
            else if (GameManager.singleton.sc2.isActiveDealerP2 == true)
            {
                GameManager.singleton.sc2.isActiveDealerP2 = false;
            }
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }
    }


    public void SetupActionMenu()
    {
        
    }
}
