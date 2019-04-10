using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectionUnits : MonoBehaviour {
    public SelectionController selection;
    public TurnManager turn;
    public KeyCode ChangeSelectionButtonAdd;
    public KeyCode ChangeSelectionButtonRemove;


    // Use this for initialization
    void Start ()
    {
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        turn.isTurn = true;
    }
	
	void Update()
    {
        if (turn.isTurn == true && selection.isActiveTank == false && selection.isActiveHealer == false && selection.isActiveDealer == false && selection.isActiveUtility == false)
        {
            if (Input.GetKeyDown(ChangeSelectionButtonAdd))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                SendMessage("AddCont");
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
                }

            }
            else if (Input.GetKeyDown(ChangeSelectionButtonRemove))
            {
                SendMessage("SubTract");
                gameObject.GetComponent<MeshRenderer>().enabled = true;

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
                }
            }
        }

    }

}
