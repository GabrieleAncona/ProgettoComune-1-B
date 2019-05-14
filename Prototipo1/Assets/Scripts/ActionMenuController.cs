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
        Movement();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Movement()
    {
        if (isActionMenu == true)
        {
            isMovement = true;
            isAttack = false;
            isAbility = false;
            isSelection = false;
            GameManager.singleton.SMController.SetTrigger("GoToMovement");
        }
    }

    public void Attack()
    {
        if (isActionMenu == true)
        {
            isAttack = true;
            isMovement = false;
            isAbility = false;
            isSelection = false;
            GameManager.singleton.SMController.SetTrigger("GoToAttack");
        }
    }

    public void Ability()
    {
            if (isActionMenu == true)
            {
                isAbility = true;
                isMovement = false;
                isAttack = false;
                isSelection = false;
                GameManager.singleton.SMController.SetTrigger("GoToAbility");
            }
    }

    public void BackSelection()
    {
                if (isActionMenu == true)
                {
                    isSelection = true;
                    isMovement = false;
                    isAttack = false;
                    isAbility = false;
                    GameManager.singleton.SMController.SetTrigger("GoToSelection");
                }
    }

    public void SetupActionMenu()
    {

    }
}
