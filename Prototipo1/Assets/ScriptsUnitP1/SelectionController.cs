using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class SelectionController : MonoBehaviour {
    public int contSelectionP1;
    public PositionTester tankP1;
    public PositionHealer healerP1;
    public PositionDealer dealerP1;
    public PositionUtility utilityP1;
    public BaseGrid grid;
    public int x, y;
    public KeyCode confirmUnitButton;
    public bool isActiveTank;
    public bool isActiveHealer;
    public bool isActiveUtility;
    public bool isActiveDealer;
    public TurnManager turn;
    public HudManagerTest Text;

    void Start()
    {
        dealerP1 = FindObjectOfType<PositionDealer>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        Text = FindObjectOfType<HudManagerTest>();
        turn = FindObjectOfType<TurnManager>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        contSelectionP1 = 0;
        transform.position = grid.GetWorldPosition(x,y);
        gameObject.GetComponent<MeshRenderer>().enabled = false;


    }


    void Update()
    {
        ConfirmUnit();
        if(turn.isTurn == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }

    public void ContTankP1()
    {
       
        transform.position = grid.GetWorldPosition(tankP1.x , tankP1.y);
        x = tankP1.x;
        y = tankP1.y;
       
    }

    public void ContHealerP1()
    {
        transform.position = grid.GetWorldPosition(healerP1.x, healerP1.y);
        x = healerP1.x;
        y = healerP1.y;
      
    }

    public void ContUtilityP1()
    {

        transform.position = grid.GetWorldPosition(utilityP1.x, utilityP1.y);
        x = utilityP1.x;
        y = utilityP1.y;

    }

    public void ContDealerP1()
    {
        transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
        x = dealerP1.x;
        y = dealerP1.y;

    }

    public void AddCont()
    {
        contSelectionP1 += 1;
        if(contSelectionP1 > 4 /* 4*/)
        {
            contSelectionP1 = 1;
        }
    }

    public void ConfirmUnit()
    {
        if(Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 1 && tankP1.isStun == false)
        {
            Debug.Log("attiva tank");
            isActiveTank = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 2 && healerP1.isStun == false)
        {
            Debug.Log("attiva healer");
            isActiveHealer = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 3 && utilityP1.isStun == false)
        {
            Debug.Log("attiva utility");
            isActiveUtility = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 4 && dealerP1.isStun == false)
        {
            Debug.Log("attiva dealer");
            isActiveDealer = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }



}
