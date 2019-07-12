using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : StateBehaviourBase
{
    public IntellGamePad intellgamepad;
    private string m_MyTrigger = "GoToSelection";

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);

        ///disattivare canvas
        //ctx.previousState = "SelectionState";
        previousStateTrigger = m_MyTrigger;

        /// GameManager.singleton.hudUnit.isActive = true;
        //GameManager.singleton.InitSM();
        GameManager.singleton.acm.isSelection = true;
        if (ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.acm.menuActionPlayer1.SetActive(false);
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.acm.menuActionPlayer2.SetActive(false);
        }
    }

    public override void OnUpdate()
    {
        ///GameManager.singleton.sc.gameObject.GetComponent<MeshRenderer>().enabled = true;

        if (/*ctx.currentPlayer.IdPlayer == 1*/ GameManager.singleton.tm.isTurn == true)
        {
            GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().TurnSlider.gameObject.SetActive(true);
            if (intellgamepad == null || (intellgamepad.ID != 0 || intellgamepad.CurrentGamePadState.IsConnected == false))
            {
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().isActive = true;
                GameManager.singleton.sc.isSelectionActive = true;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().KeyboardKey1.enabled = true;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().KeyboardKey2.enabled = true; 
            }
            else if (intellgamepad.ID == 0 && intellgamepad.CurrentGamePadState.IsConnected == true)
            {
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().isActive = true;
                GameManager.singleton.sc.isSelectionActive = true;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().GamepadButton1.enabled = true;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().GamepadButton2.enabled = true;
            }
        }

        if (/*ctx.currentPlayer.IdPlayer == 2*/ GameManager.singleton.tm.isTurn == false)
        {
            GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().TurnSlider.gameObject.SetActive(true);
            if (intellgamepad == null || (intellgamepad.ID != 1 || intellgamepad.CurrentGamePadState.IsConnected == false))
            {
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().isActive = true;
                GameManager.singleton.sc2.isSelectionActive = true;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().KeyboardKey1.enabled = true;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().KeyboardKey2.enabled = true; 
            }
            if (intellgamepad.ID == 1 && intellgamepad.CurrentGamePadState.IsConnected == false)
            {
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().isActive = true;
                GameManager.singleton.sc2.isSelectionActive = true;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().GamepadButton1.enabled = true;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().GamepadButton2.enabled = true;
            }
        }
    }

    public override void OnExit()
    {
        ///GameManager.singleton.sc.gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (/*ctx.currentPlayer.IdPlayer == 1*/ GameManager.singleton.tm.isTurn == false)
        {
            GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().TurnSlider.gameObject.SetActive(false);
            if (intellgamepad == null || (intellgamepad.ID != 0 || intellgamepad.CurrentGamePadState.IsConnected == false))
            {
                GameManager.singleton.sc.isSelectionActive = false;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().KeyboardKey1.enabled = false;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().KeyboardKey2.enabled = false;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().isActive = false; 
            }
            if (intellgamepad.ID == 0 && intellgamepad.CurrentGamePadState.IsConnected == true)
            {
                GameManager.singleton.sc.isSelectionActive = false;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().GamepadButton1.enabled = false;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().GamepadButton2.enabled = false;
                GameManager.singleton.hudUnit.GetComponent<HudUnitsManager>().isActive = false;
            }
        }

        if (/*ctx.currentPlayer.IdPlayer == 2*/ GameManager.singleton.tm.isTurn == true)
        {
            GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().TurnSlider.gameObject.SetActive(false);
            if (intellgamepad == null || (intellgamepad.ID != 1 || intellgamepad.CurrentGamePadState.IsConnected == false))
            {
                GameManager.singleton.sc2.isSelectionActive = false;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().KeyboardKey1.enabled = false;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().KeyboardKey2.enabled = false;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().isActive = false; 
            }
            if (intellgamepad.ID == 1 && intellgamepad.CurrentGamePadState.IsConnected == true)
            {
                GameManager.singleton.sc2.isSelectionActive = false;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().GamepadButton1.enabled = false;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().GamepadButton2.enabled = false;
                GameManager.singleton.hudUnit2.GetComponent<HudUnitsManager>().isActive = false;
            }
        }
        GameManager.singleton.acm.isSelection = false;
    }
}
