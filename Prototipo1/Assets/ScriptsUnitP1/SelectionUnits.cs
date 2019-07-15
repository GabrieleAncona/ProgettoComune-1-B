using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectionUnits : MonoBehaviour
{
    public SelectionController selection;
    public TurnManager turn;
    public KeyCode ChangeSelectionButtonAdd;
    public KeyCode ChangeSelectionButtonRemove;
    public PositionTester tankP1;
    public PositionDealer dealerP1;
    public PositionHealer healerP1;
    public PositionUtility utilityP1;
    public HudUnitsManager HUM;

    // Use this for initialization
    void Start ()
    {
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        turn.isTurn = true;
        tankP1 = FindObjectOfType<PositionTester>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        healerP1 = FindObjectOfType<PositionHealer>();
    }
	
	void Update()
    {
        if (turn.isTurn == true && selection.isActiveTank == false && selection.isActiveHealer == false && selection.isActiveDealer == false
            && selection.isActiveUtility == false && HUM.OnMove == false && GameManager.singleton.acm.isSelection == true)
        {
            if (Input.GetKeyDown(ChangeSelectionButtonAdd))
            {
               /// gameObject.GetComponent<MeshRenderer>().enabled = true;
                SendMessage("AddCont");
                if (tankP1.isDead == true && selection.contSelectionP1 == 1) {
                   
                    SendMessage("AddCont");
                }
                if (healerP1.isDead == true && selection.contSelectionP1 == 2)
                {

                    SendMessage("AddCont");
                }
                if (utilityP1.isDead == true && selection.contSelectionP1 == 3)
                {

                    SendMessage("AddCont");
                }
                if (dealerP1.isDead == true && selection.contSelectionP1 == 4)
                {

                    SendMessage("AddCont");
                }

                Debug.Log("non si è rotto");
                if(selection.contSelectionP1 == 1)
                {
                    SendMessage("ContTankP1");
                }
                else if (selection.contSelectionP1 == 2)
                {
                    SendMessage("ContHealerP1");
                }
                else if (selection.contSelectionP1 == 3)
                {
                    SendMessage("ContUtilityP1");
                }
                else if (selection.contSelectionP1 == 4)
                {
                    SendMessage("ContDealerP1");
                }
                else if(selection.contSelectionP1 > 4)
                {
                    selection.contSelectionP1 = 1;
                    if (tankP1.isDead == true && selection.contSelectionP1 == 1) {

                        SendMessage("AddCont");
                    }
                }

            }
            else if (Input.GetKeyDown(ChangeSelectionButtonRemove))
            {
                SendMessage("SubTract");
                Debug.Log("non si è rotto");
               /// gameObject.GetComponent<MeshRenderer>().enabled = true;

                if (dealerP1.isDead == true && selection.contSelectionP1 == 4) {

                    SendMessage("SubTract");
                }

                if (utilityP1.isDead == true && selection.contSelectionP1 == 3)
                {

                    SendMessage("SubTract");
                }

                if (healerP1.isDead == true && selection.contSelectionP1 == 2)
                {

                    SendMessage("SubTract");
                }

                if (tankP1.isDead == true && selection.contSelectionP1 == 1)
                {

                    SendMessage("SubTract");
                }

                if (selection.contSelectionP1 == 1)
                {
                    SendMessage("ContTankP1");
                }
                else if (selection.contSelectionP1 == 2)
                {
                    SendMessage("ContHealerP1");
                }
                else if (selection.contSelectionP1 == 3)
                {
                    SendMessage("ContUtilityP1");
                }
                else if (selection.contSelectionP1 == 4)
                {
                    SendMessage("ContDealerP1");
                }
                 if (selection.contSelectionP1 <= 0)
                {
                    selection.contSelectionP1 = 4;
                    if (dealerP1.isDead == true && selection.contSelectionP1 == 4) {

                        SendMessage("SubTract");
                    }
                }
            }
        }

    }

}
