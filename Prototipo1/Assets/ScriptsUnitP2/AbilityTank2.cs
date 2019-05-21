using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityTank2 : MonoBehaviour {

    public LifeManager lm;
    public TurnManager turn;
    public int att = 3;
    public PositionTester tankP1;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public PositionUtility utilityP1;
    public PositionDealer dealerP1;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAbility;
    public KeyCode attackButton;
    public SelectControllerP2 selectionP2;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float strength;
    public int vibrato;
    public BaseGrid grid;
    public PositionHealer healerP1;
    public float duration = 0.2f;
    public bool isBlock;
    public int Counter;
    public int CounterTurnA;
    public bool isCharging;

    // Use this for initialization
    void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        vibrato = 10;
        strength = 0.1f;
        Counter = 2;
        CounterTurnA = 0;
    }

    void Update()
    {
        ChargeAbility();
        SetAttackBase();
        RotationAttack();
        StartCoroutine(SetDirectionAttackBase());
        DisactivePrewiewTank();
    }

   public void ChargeAbility()
    {
        if (Counter == 0 && CounterTurnA == 0 && turn.isTurn == true)
        {
            Counter = 1;
            CounterTurnA = 1;
        }
        if (Counter == 1 && CounterTurnA == 1 && turn.isTurn == false)
        {
            CounterTurnA = 2;
        }
        if (Counter == 1 && CounterTurnA == 2 && turn.isTurn == true)
        {
            Counter = 2;
            CounterTurnA = 0;
        }
    }

    /* public void SetRange()
     {

         RangeHzTank = tank.maxRangeHzTankPlayer1 - tankP2.maxRangeHzTankPlayer2;
         RangeVtTank = tank.maxRangeVtTankPlayer1 - tankP2.maxRangeVtTankPlayer2;
         RangeHzHealer = tank.maxRangeHzTankPlayer1 - healerP2.maxRangeHzHealerPlayer2;
         RangeVtHealer = tank.maxRangeVtTankPlayer1 - healerP2.maxRangeVtHealerPlayer2;
         //altre unità

     }*/

    public void SetAttackBase()
    {
        if (Input.GetKeyDown(attackButton) && turn.isTurn == false && isAbility == false && selectionP2.isActiveTankP2 == true && Counter == 2)
        {
            isAbility = true;

            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(attackButton) && turn.isTurn == false && isAbility == true && selectionP2.isActiveTankP2 == true)
        {
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if (isAbility == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                isAttUp = true;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = false;

            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                isAttUp = false;
                isAttDown = true;
                isAttLeft = false;
                isAttRight = false;

            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = true;

            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = true;
                isAttRight = false;

            }
        }
    }

    IEnumerator SetDirectionAttackBase()
    {
        //SetRange();
        //tank destra
        if (Input.GetKeyDown(KeyCode.Space) && isAbility == true  && tankP2.isUnitEnemie == true)
        {
            if (tankP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x++, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x++, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x++, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x++, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }

        }

        //tanke sinistra
        /*if (Input.GetKeyDown(KeyCode.I) && isAbility == true && isAttDown == true && tankP2.isUnitEnemie == true)
        {


            if (tankP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
               
                DamageTankP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x--, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x--, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x--, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x--, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
        }

        //tank sopra
        if (Input.GetKeyDown(KeyCode.L) && isAbility == true && isAttLeft == true && tankP2.isUnitEnemie == true)
        {

            if (tankP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y++);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y++);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y++);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y++);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }

        }

        // healer sotto
        if (Input.GetKeyDown(KeyCode.J) && isAbility == true && isAttRight == true && tankP2.isUnitEnemie == true)
        {

            if (tankP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y--);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y--);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y--);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            else if (tankP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y--);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
        }*/
    }

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewTank()
    {
        if (turn.isTurn == true)
        {
            isAbility = false;
            tankP2.contMp = 2;
        }
    }


    public void DamageTankP1()
    {
                lm.lifeTank -= att;
                //turn.isTurn = true;
                isAbility = false;
                selectionP2.isActiveTankP2 = false;
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
               selectionP2.contSelectionP2 = 0;
    }

    public void DamageHealerP1()
    {
        lm.lifeHealer -= att;
        //turn.isTurn = true;
        isAbility = false;
        selectionP2.isActiveTankP2 = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selectionP2.contSelectionP2 = 0;
    }

    public void DamageUtilityP1()
    {
        lm.lifeUtility -= att;
        //turn.isTurn = true;
        isAbility = false;
        selectionP2.isActiveTankP2 = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selectionP2.contSelectionP2 = 0;
    }

    public void DamageDealerP1()
    {
        lm.lifeDealer -= att;
        //turn.isTurn = true;
        isAbility = false;
        selectionP2.isActiveTankP2 = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selectionP2.contSelectionP2 = 0;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "UnitP1") {

            Debug.Log("entra dotween");
            if (isAttUp == true) {
                //tank.transform.position = grid.GetWorldPosition(tank.x, tank.y);
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x--, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                //tank.transform.DOMoveX(tank.x, duration).SetAutoKill(false);
            }
            else if (isAttDown == true) {
                //tank.transform.position = grid.GetWorldPosition(tank.x, tank.y);
                
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x++, tankP2.y);
                tankP2.transform.DOMoveX(tankP2.x, duration).SetAutoKill(false);
                //tank.transform.DOMoveX(tank.x, duration).SetAutoKill(false);
            }
            else if (isAttLeft == true) {
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y++);
                tankP2.transform.DOMoveZ(tankP2.y, duration).SetAutoKill(false);
            }
            else if (isAttRight == true) {
                tankP2.transform.position = grid.GetWorldPosition(tankP2.x, tankP2.y++);
                tankP2.transform.DOMoveZ(tankP2.y, duration).SetAutoKill(false);
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "UnitP1") {
            isBlock = false;

        }
    }

}
