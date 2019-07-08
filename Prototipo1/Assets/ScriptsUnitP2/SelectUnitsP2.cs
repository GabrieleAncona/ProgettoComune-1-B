using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectUnitsP2 : MonoBehaviour
{
    public SelectControllerP2 selectionP2;
    public TurnManager turn;
    public KeyCode ChangeSelectionButtonAdd;
    public KeyCode ChangeSelectionButtonRemove;
    public PositionTester2 tankP2;
    public PositionDealer2 dealerP2;
    public HudUnitsManager HUM;

    // Use this for initialization
    void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        turn.isTurn = true;
        tankP2 = FindObjectOfType<PositionTester2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
    }

    void Update()
    {
        if (turn.isTurn == false && selectionP2.isActiveTankP2 == false && selectionP2.isActiveHealerP2 == false &&
            selectionP2.isActiveUtilityP2 == false && selectionP2.isActiveDealerP2 == false && HUM.OnMove == false && GameManager.singleton.acm.isSelection == true)
        {
            if (Input.GetKeyDown(ChangeSelectionButtonAdd))
            {
                //gameObject.GetComponent<MeshRenderer>().enabled = true;
                SendMessage("AddContP2");

                if (tankP2.isDead == true && selectionP2.contSelectionP2 == 1) {

                    SendMessage("AddCont");
                }

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
                    if (tankP2.isDead == true && selectionP2.contSelectionP2 == 1) {

                        SendMessage("AddCont");
                    }
                }

            }
            else if (Input.GetKeyDown(ChangeSelectionButtonRemove))
            {
                SendMessage("SubTractP2");
  
               // gameObject.GetComponent<MeshRenderer>().enabled = true;

                if (dealerP2.isDead == true && selectionP2.contSelectionP2 == 4) {

                    SendMessage("SubTract");
                }

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
                    if (dealerP2.isDead == true && selectionP2.contSelectionP2 == 4) {

                        SendMessage("SubTract");
                    }
                }
                
            }
        }

    }
}
