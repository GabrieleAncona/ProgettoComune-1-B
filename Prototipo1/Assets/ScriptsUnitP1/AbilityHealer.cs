using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityHealer : MonoBehaviour {

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

    public int Counter;
    public int MaxCounter = 2;
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
    }

    // Update is called once per frame
    void Update()
    {
        //ChargeAbility();
        StartCoroutine(SetDirectionAbility());
        SetAbility();
        DisactivePrewiewHealer();
        RotationAbility();
    }

   /* public void ChargeAbility()
    {
        if (Counter == 0 && turn.isTurn == false)
        {
            Counter++;
        }
        else if (Counter == 2)
        {
            Counter = MaxCounter;
        }
    }*/

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
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == false && selection.isActiveHealer == true)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == true && selection.isActiveHealer == true)
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
        if (Input.GetKeyDown(KeyCode.W) && isAbility == true && lm.lifeTank < lm.lifeMaxTank && isAttUp == true && healerP1.isUnitAlly == true)
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
        //sinistra
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

        }

        //autoheal 
        if(Input.GetKeyDown(KeyCode.Z) && isAbility == true && lm.lifeHealer < lm.lifeMaxHealer)
        {
            lm.lifeHealer += heal;
            if (lm.lifeHealer < lm.lifeMaxHealer)
            {
                lm.lifeHealer += heal;
                isAbility = false;
                selection.isActiveHealer = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
                selection.contSelectionP1 = 0;
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else
            {
                lm.lifeHealer = lm.lifeMaxHealer;
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
        turn.isTurn = false;
        isAbility = false;
        selection.isActiveHealer = false;
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
        turn.isTurn = false;
        isAbility = false;
        selection.isActiveHealer = false;
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
        turn.isTurn = false;
        isAbility = false;
        selection.isActiveHealer = false;
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
        }
    }

}
