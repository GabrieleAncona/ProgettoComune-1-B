using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectUnitsP2 : MonoBehaviour {
    public SelectControllerP2 selectionP2;
    public TurnManager turn;
    public KeyCode ChangeSelectionButtonAdd;
    public KeyCode ChangeSelectionButtonRemove;

    // Use this for initialization
    void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        turn.isTurn = true;

    }

    void Update()
    {
        if (turn.isTurn == false && selectionP2.isActiveTankP2 == false && selectionP2.isActiveHealerP2 == false && selectionP2.isActiveUtilityP2 == false && selectionP2.isActiveDealerP2 == false)
        {
            if (Input.GetKeyDown(ChangeSelectionButtonAdd))
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                SendMessage("AddContP2");
                if (selectionP2.contSelectionP2 == 1)
                {
                    SendMessage("ContTankP2");
                }
                else if (selectionP2.contSelectionP2 == 2)
                {
                    SendMessage("ContHealerP2");
                }
                else if (selectionP2.contSelectionP2 == 3)
                {
                    SendMessage("ContUtilityP2");
                }
                else if (selectionP2.contSelectionP2 == 4)
                {
                    SendMessage("ContDealerP2");
                }
                else if (selectionP2.contSelectionP2 > 4)
                {
                    selectionP2.contSelectionP2 = 1;
                }

            }
            else if (Input.GetKeyDown(ChangeSelectionButtonRemove))
            {
                SendMessage("SubTractP2");
  
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                    
                    if (selectionP2.contSelectionP2 == 1)
                    {
                        SendMessage("ContTankP2");
                    
                    }
                    else if (selectionP2.contSelectionP2 == 2)
                    {
                        SendMessage("ContHealerP2");
                    
                    }
                    else if (selectionP2.contSelectionP2 == 3)
                    {
                        SendMessage("ContUtilityP2");
                    
                    }
                    else if (selectionP2.contSelectionP2 == 4)
                    {
                        SendMessage("ContDealerP2");
                   
                    }
                     if (selectionP2.contSelectionP2 <= 0)
                    {
                        selectionP2.contSelectionP2 = 4;
                    }
                
            }
        }

    }
}
