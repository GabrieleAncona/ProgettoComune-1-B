using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectionUnits : MonoBehaviour {
    public SelectionController selection;
    public TurnManager turn;
    public KeyCode ChangeSelectionButton;
   

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
            if (Input.GetKeyDown(ChangeSelectionButton))
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
        }

    }

}
