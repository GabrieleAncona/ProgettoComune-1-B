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
    public HudUnitsManager HUM;

    // Use this for initialization
    void Start ()
    {
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        turn.isTurn = true;
        tankP1 = FindObjectOfType<PositionTester>();
        dealerP1 = FindObjectOfType<PositionDealer>();
    }
	
	void Update()
    {
        if (turn.isTurn == true && selection.isActiveTank == false && selection.isActiveHealer == false && selection.isActiveDealer == false 
            && selection.isActiveUtility == false && HUM.OnMove == false)
        {
            if (Input.GetKeyDown(ChangeSelectionButtonAdd))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                SendMessage("AddCont");
                if (tankP1.isDead == true && selection.contSelectionP1 == 1) {
                   
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
                gameObject.GetComponent<MeshRenderer>().enabled = true;

                if (dealerP1.isDead == true && selection.contSelectionP1 == 4) {

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
