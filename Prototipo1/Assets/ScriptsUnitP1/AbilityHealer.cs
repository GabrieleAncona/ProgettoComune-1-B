using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityHealer : AbilityBase
{

    public int heal = 4;
    public PositionHealer healerP1;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester tank;
    public PositionUtility utility;
    public PositionDealer dealer;
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    //ALTRE UNITA ALLEATE
    public bool isAbility;
    public SelectionController selection;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float timerAutoHeal;
    public int Counter;
    public int CounterTurnA;
    public bool isCharging;

    // Use this for initialization
    void Start()
    {
        selection = FindObjectOfType<SelectionController>();
        healerP1 = FindObjectOfType<PositionHealer>();
        tank = FindObjectOfType<PositionTester>();
        dealer = FindObjectOfType<PositionDealer>();
        utility = FindObjectOfType<PositionUtility>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        Counter = 2;
        CounterTurnA = 0;
        timerAutoHeal = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChargeAbility();
        StartCoroutine(SetDirectionAbility());
        SetAbility();
        DisactivePrewiewHealer();
        RotationAbility();
    }

   public void ChargeAbility()
    {
        if (Counter == 0 && CounterTurnA == 0 && turn.isTurn == false)
        {
            Counter = 1;
            CounterTurnA = 1;
        }
        if (Counter == 1 && CounterTurnA == 1 && turn.isTurn == true)
        {
            CounterTurnA = 2;
        }
        if (Counter == 1 && CounterTurnA == 2 && turn.isTurn == false)
        {
            Counter = 2;
            CounterTurnA = 0;
        }
    }

    public void RotationAbility()
    {
        if (isAbility == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                isAttUp = true;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                isAttUp = false;
                isAttDown = true;
                isAttLeft = false;
                isAttRight = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = true;
                isAttRight = false;
            }
        }
    }

    public void SetAbility()
    {

        //abilito abilita
        if (turn.isTurn == true && GameManager.singleton.acm.isAbilityHealer == true && selection.isActiveHealer == true && Counter ==2)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (turn.isTurn == true && GameManager.singleton.acm.isAbilityHealer == false && selection.isActiveHealer == true)
        {
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }

    }
    //scelgo direzione dove lanciare l'abilita
    IEnumerator SetDirectionAbility()
    {
        //SetRange();
        //destra
        if (Input.GetKeyDown(KeyCode.Space) && isAbility == true && lm.lifeTank < lm.lifeMaxTank && healerP1.isUnitAlly == true)
        {
            if ((healerP1.hit.transform.gameObject.GetComponent<PositionTester>()))
            {
                if (lm.lifeTank < lm.lifeMaxTank)
                {
                    HealTank();
                    GameManager.singleton.acm.isActionHealer = false;
                    GameManager.singleton.sc.isHealerUsable = false;
                    yield return new WaitForSeconds(2f);
                    GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                    
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionDealer>()))
            {
                if (lm.lifeDealer < lm.lifeMaxDealer)
                {
                    HealDealer();
                    GameManager.singleton.acm.isActionHealer = false;
                    GameManager.singleton.sc.isHealerUsable = false;
                    yield return new WaitForSeconds(2f);

                    GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");

                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionUtility>()))
            {
                if (lm.lifeUtility < lm.lifeMaxUtility)
                {
                    HealUtility();
                    GameManager.singleton.acm.isActionHealer = false;
                    GameManager.singleton.sc.isHealerUsable = false;
                    yield return new WaitForSeconds(2f);
                    GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                    Counter = 0;
                }
            }
        }
       /* //sinistra
        if (Input.GetKeyDown(KeyCode.S)  && isAbility == true && lm.lifeTank < lm.lifeMaxTank && isAttDown == true && healerP1.isUnitAlly == true)
        {
            if ((healerP1.hit.transform.gameObject.GetComponent<PositionTester>()))
            {
                if (lm.lifeTank < lm.lifeMaxTank)
                {
                    HealTank();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionDealer>()))
            {
                if (lm.lifeDealer < lm.lifeMaxDealer)
                {
                    HealDealer();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionUtility>()))
            {
                if (lm.lifeUtility < lm.lifeMaxUtility)
                {
                    HealUtility();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }

        }
        //sopra
        if (Input.GetKeyDown(KeyCode.A)  && isAbility == true && lm.lifeTank < lm.lifeMaxTank && isAttLeft == true && healerP1.isUnitAlly == true)
        {
            if ((healerP1.hit.transform.gameObject.GetComponent<PositionTester>()))
            {
                if (lm.lifeTank < lm.lifeMaxTank)
                {
                    HealTank();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionDealer>()))
            {
                if (lm.lifeDealer < lm.lifeMaxDealer)
                {
                    HealDealer();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionUtility>()))
            {
                if (lm.lifeUtility < lm.lifeMaxUtility)
                {
                    HealUtility();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }

        }
        //sotto
        if (Input.GetKeyDown(KeyCode.D) && isAbility == true && lm.lifeTank < lm.lifeMaxTank && isAttRight == true && healerP1.isUnitAlly == true)
        {
            if ((healerP1.hit.transform.gameObject.GetComponent<PositionTester>()))
            {
                if (lm.lifeTank < lm.lifeMaxTank)
                {
                    HealTank();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionDealer>()))
            {
                if (lm.lifeDealer < lm.lifeMaxDealer)
                {
                    HealDealer();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }
            else if ((healerP1.hit.transform.gameObject.GetComponent<PositionUtility>()))
            {
                if (lm.lifeUtility < lm.lifeMaxUtility)
                {
                    HealUtility();
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = false;
                    Counter = 0;
                }
            }

        }*/

        //autoheal 
        if(Input.GetKey(KeyCode.Space) && isAbility == true && lm.lifeHealer < lm.lifeMaxHealer)
        {

            timerAutoHeal += Time.deltaTime;

            if (timerAutoHeal >= 2)
            {

                lm.lifeHealer += heal;
                if (lm.lifeHealer < lm.lifeMaxHealer)
                {
                    lm.lifeHealer += heal;
                    isAbility = false;
                    //  selection.isActiveHealer = false;
                    //riabilito input controller per i movimenti(wasd)
                    gameObject.GetComponent<InputController>().enabled = true;
                    selection.contSelectionP1 = 0;
                    GameManager.singleton.acm.isActionHealer = false;
                    GameManager.singleton.sc.isHealerUsable = false;
                    yield return new WaitForSeconds(2f);
                    GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                    Counter = 0;
                    timerAutoHeal = 0;
                }
                else
                {
                    lm.lifeHealer = lm.lifeMaxHealer;
                    timerAutoHeal = 0;
                }
            }
        }


    }


    //set up range verticale e orrizontale per portata ability
    /*public void SetRange()
    {
        rangeHzTank = healer.maxRangeHzHealerPlayer1 - tank.maxRangeHzTankPlayer1;
        rangeVtTank = healer.maxRangeVtHealerPlayer1 - tank.maxRangeVtTankPlayer1;
    }*/

    public void HealTank()
    {
        lm.lifeTank += heal;
        if (lm.lifeTank > lm.lifeMaxTank)
        {
            lm.lifeTank = 20;
        }
       
        isAbility = false;
        //  selection.isActiveHealer = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;

        selection.contSelectionP1 = 0;
    }

    public void HealDealer()
    {
        lm.lifeDealer += heal;
        if (lm.lifeDealer > lm.lifeMaxDealer)
        {
            lm.lifeDealer = 20;
        }
        
        isAbility = false;
        // selection.isActiveHealer = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;

        selection.contSelectionP1 = 0;
    }

    public void HealUtility()
    {
        lm.lifeHealer += heal;
        if (lm.lifeHealer > lm.lifeMaxHealer)
        {
            lm.lifeHealer = 20;
        }
       
        isAbility = false;
        // selection.isActiveHealer = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;

        selection.contSelectionP1 = 0;
    }

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewHealer()
    {
        if(turn.isTurn == false)
        {
            isAbility = false;
            healerP1.contMp = 4;
        }
    }

}
