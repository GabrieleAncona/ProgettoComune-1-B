using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : StateBehaviourBase
{
    private string m_MyTrigger = "GoToMovement";
    

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);       
        //ctx.previousState.SetMyTriggerString(m_MyTrigger);
        previousStateTrigger = m_MyTrigger;


        //Debug.Log(ctx.previousState.MyTrigger);
        ///disattivare canvas

        GameManager.singleton.acm.isMovement = true;
        //GameManager.singleton.InitSM();
        if (ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.acm.menuActionPlayer1.SetActive(true);
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.acm.menuActionPlayer2.SetActive(true);
        }
    }

    public override void OnUpdate()
    {
        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 0;
            buttonNavigation.SwitchSprite();
            buttonNavigation.text[3].SetActive(false);
            buttonNavigation.text[2].SetActive(false);
            buttonNavigation.text[1].SetActive(false);
            buttonNavigation.text[0].SetActive(true); 
        }
        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 0;
            buttonNavigation.SwitchSprite();
            buttonNavigation.text[3].SetActive(false);
            buttonNavigation.text[2].SetActive(false);
            buttonNavigation.text[1].SetActive(false);
            buttonNavigation.text[0].SetActive(true); 
        }
    }

    public override void OnExit()
    {
        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            GameManager.singleton.acm.isMovement = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 0;
            buttonNavigation.ChangeImageButton(); 
        }
        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            GameManager.singleton.acm.isMovement = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 0;
            buttonNavigation.ChangeImageButton(); 
        }
    }
}
