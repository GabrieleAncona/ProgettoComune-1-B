using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityTank : MonoBehaviour
{
    public int att = 3;
    public PositionTester tank;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tankP2;
    private PositionHealer2 healerP2;
    public PositionUtility2 utilityP2;
    public PositionDealer2 dealerP2;
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    public int rangeHzHealer;
    public int rangeVtHealer;
    public bool isAbility;
    public SelectionController selection;
    public float duration = 0.2f;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float strength;
    public int vibrato;

    public int Counter;
    public int MaxCounter = 2;
    public bool isCharging;

    // Use this for initialization
    void Start () {

        selection = FindObjectOfType<SelectionController>();
        tank = FindObjectOfType<PositionTester>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        
    }
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(SetDirectionAbility());
        SetAbility();
        DisactivePrewiewTank();
        RotationAbility();

    }

    public void ChargeAbility()
    {
        if (Counter == 0 && turn.isTurn == false)
        {
            Counter++;
        }
        else if (Counter == 2)
        {
            Counter = MaxCounter;
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
        if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == false && selection.isActiveTank == true && Counter == 2)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if(Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == true && selection.isActiveTank == true && Counter == 2)
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
        //destra TankP2
        if (Input.GetKeyDown(KeyCode.W)  && isAbility == true && tank.isUnitEnemie == true && isAttUp == true)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }


        }
        
        //sinistra tank
        if (Input.GetKeyDown(KeyCode.S)   && isAbility == true && tank.isUnitEnemie == true && isAttDown == true)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
        }
        
        //sopra tank
        if (Input.GetKeyDown(KeyCode.A)  && isAbility == true && tank.isUnitEnemie == true && isAttLeft == true)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
        }


         // sotto tank
        if (Input.GetKeyDown(KeyCode.D)  && isAbility == true && tank.isUnitEnemie == true && isAttRight == true)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                Counter = 0;
            }
        }

  


    }
    

    //set up range verticale e orrizontale per portata ability
    /*public void SetRange()
    {
        //range tank
        rangeHzTank = tank.maxRangeHzTankPlayer1 - tankP2.maxRangeHzTankPlayer2;
        rangeVtTank = tank.maxRangeVtTankPlayer1 - tankP2.maxRangeVtTankPlayer2;
        //range healer
        rangeHzHealer = tank.maxRangeHzTankPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        rangeVtHealer = tank.maxRangeVtTankPlayer1 - healerP2.maxRangeVtHealerPlayer2;
        // altre unità
    }*/

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewTank()
    {
        if (turn.isTurn == false)
        {
            isAbility = false;
        }
    }

    public void DamageTankP2()
    {
        //transform.position = grid.GetWorldPosition(tank.x++, y);
        //transform.DOMoveX(x, duration).SetAutoKill(false);
       
        //SetRange();
        lm.lifeTankPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveTank = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
    }

    public void DamageHealerP2()
    {
        //transform.position = grid.GetWorldPosition(tank.x++, y);
        //transform.DOMoveX(x, duration).SetAutoKill(false);
        
        //SetRange();
        lm.lifeHealerPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveTank = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 0;
    }
    public void DamageUtilityP2()
    {
        //transform.position = grid.GetWorldPosition(tank.x++, y);
        //transform.DOMoveX(x, duration).SetAutoKill(false);
       
        //SetRange();
        lm.lifeUtilityPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveTank = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
    }

    public void DamageDealerP2()
    {
        //transform.position = grid.GetWorldPosition(tank.x++, y);
        //transform.DOMoveX(x, duration).SetAutoKill(false);
       
        //SetRange();
        lm.lifeDealerPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveTank = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 0;
    }
}



