using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;
using TellInput;

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
    public float duration;
    public bool isTankUsable;
    public bool isHealerUsable;
    public bool isUtilityUsable;
    public bool isDealerUsable;
    public bool isSelectionActive;
    public GameObject selector;
    public InputTester inputPad;

    private void Awake()
    {
        selector.SetActive(true);

    }

    void Start()
    {
        isTankUsable = true;
        isHealerUsable = true;
        isUtilityUsable = true;
        isDealerUsable = true;
        duration = 0.5f;
        dealerP1 = FindObjectOfType<PositionDealer>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        Text = FindObjectOfType<HudManagerTest>();
        turn = FindObjectOfType<TurnManager>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        contSelectionP1 = 0;
        transform.position = grid.GetWorldPosition(x,y);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        selector.SetActive(false);
        inputPad = FindObjectOfType<InputTester>();
    }


    void Update()
    {
        ConfirmUnit();
        if(turn.isTurn == false)
        {

            selector.SetActive(false);
        }
        if(turn.isTurn == true)
        {
            selector.SetActive(true); ;
        }

        if(turn.isTurn == true)
        {
            if(isActiveTank == true)
            {
                transform.position = grid.GetWorldPosition(tankP1.x, tankP1.y);
                ///ricontrollare
                ///transform.DOMoveX(tankP1.x, duration).SetAutoKill(false);
                ///transform.DOMoveZ(tankP1.y, duration).SetAutoKill(false);
            }

            else if (isActiveHealer == true)
            {
                transform.position = grid.GetWorldPosition(healerP1.x, healerP1.y);
                transform.DOMoveX(healerP1.x, duration).SetAutoKill(false);
                transform.DOMoveZ(healerP1.y, duration).SetAutoKill(false); 
            }

            else if (isActiveUtility == true)
            {
                transform.position = grid.GetWorldPosition(utilityP1.x, utilityP1.y);
                transform.DOMoveX(utilityP1.x, duration).SetAutoKill(false);
                transform.DOMoveZ(utilityP1.y, duration).SetAutoKill(false); 
            }

            else if (isActiveDealer == true)
            {
                transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
                transform.DOMoveX(dealerP1.x, duration).SetAutoKill(false);
                transform.DOMoveZ(dealerP1.y, duration).SetAutoKill(false); 
            }
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
        if (GameManager.singleton.stateMachine.SMController.GetCurrentAnimatorStateInfo(0).IsName("selection state"))
        {
            contSelectionP1 += 1;

            if (tankP1.isDead == true && contSelectionP1 == 1)
            {
                contSelectionP1 += 1;
            }
            if (healerP1.isDead == true && contSelectionP1 == 2)
            {
                contSelectionP1 += 1;
            }
            else if (utilityP1.isDead == true && contSelectionP1 == 3)
            {
                contSelectionP1 += 1;
            }
            else if (dealerP1.isDead == true && contSelectionP1 == 4)
            {
                contSelectionP1 += 1;
            }


            if (contSelectionP1 > 4)
            {
                contSelectionP1 = 1;
            } 
        }
    }

    public void SubTract()
    {
        contSelectionP1 -= 1;

        if (tankP1.isDead == true && contSelectionP1 == 1) {
            contSelectionP1 -= 1;
        }
        else if (healerP1.isDead == true && contSelectionP1 == 2) {
            contSelectionP1 -= 1;
        }
        else if (utilityP1.isDead == true && contSelectionP1 == 3) {
            contSelectionP1 -= 1;
        }
        else if (dealerP1.isDead == true && contSelectionP1 == 4) {
            contSelectionP1 -= 1;
        }

        if (contSelectionP1 <  1)
        {
            contSelectionP1 = 4;
        }
    }

    public void ConfirmUnit()
    {
        if(Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 1 && tankP1.isStun == false && turn.isTurn == true && isTankUsable == true && (GameManager.singleton.stateMachine.SMController.GetCurrentAnimatorStateInfo(0).IsName("selection state")))
        {
            SoundManager.PlaySound(SoundManager.Sound.tankVoice);
            isActiveTank = true;
            isTankUsable = false;
          //  GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMovement");
            //transform.position = grid.GetWorldPosition(tankP1.x, tankP1.y);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 2 && healerP1.isStun == false && turn.isTurn == true && isHealerUsable == true && (GameManager.singleton.stateMachine.SMController.GetCurrentAnimatorStateInfo(0).IsName("selection state")))
        {
            SoundManager.PlaySound(SoundManager.Sound.healerVoice);
            isActiveHealer = true;
           isHealerUsable = false;
           // GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMovement");
            //transform.position = grid.GetWorldPosition(healerP1.x, healerP1.y);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 3 && utilityP1.isStun == false && turn.isTurn == true && isUtilityUsable == true && (GameManager.singleton.stateMachine.SMController.GetCurrentAnimatorStateInfo(0).IsName("selection state")))
        {
            //inserire audio utility
            isActiveUtility = true;
            isUtilityUsable = false;
            //GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMovement");
            //transform.position = grid.GetWorldPosition(utilityP1.x, utilityP1.y);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
        if (Input.GetKeyDown(confirmUnitButton) && contSelectionP1 == 4 && dealerP1.isStun == false && turn.isTurn == true && isDealerUsable == true && (GameManager.singleton.stateMachine.SMController.GetCurrentAnimatorStateInfo(0).IsName("selection state")))
        {
            SoundManager.PlaySound(SoundManager.Sound.dealerVoice);
            isActiveDealer = true;
            isDealerUsable = false;
           // GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMovement");
            //transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }



}
