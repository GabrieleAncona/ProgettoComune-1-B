using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityUtility2 : MonoBehaviour {

    public LifeManager lm;
    public TurnManager turn;
    public int att = 3;
    public PositionTester tankP1;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public PositionDealer dealerP1;
    public PositionUtility2 utilityP2;
    public PositionUtility utilityP1;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAbility;
    public KeyCode attackButton;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float strength;
    public int vibrato;
    public BaseGrid grid;
    public PositionHealer healerP1;
    public SelectControllerP2 selectionP2;
    public bool isStun;
    public int counter;

    // Use this for initialization
    void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        tankP2 = FindObjectOfType<PositionTester2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        vibrato = 10;
        strength = 0.1f;

    }

    void Update()
    {

        SetAttackBase();
        RotationAttack();
        StartCoroutine(SetDirectionAttackBase());
        DisactivePrewiewTank();
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
        if (Input.GetKeyDown(attackButton) && turn.isTurn == false && isAbility == false && selectionP2.isActiveUtilityP2 == true)
        {
            isAbility = true;

            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (Input.GetKeyDown(attackButton) && turn.isTurn == false && isAbility == true && selectionP2.isActiveUtilityP2 == true)
        {
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if (isAbility == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                isAttUp = true;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = false;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                isAttUp = false;
                isAttDown = true;
                isAttLeft = false;
                isAttRight = false;

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = true;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
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
        if (Input.GetKeyDown(KeyCode.DownArrow) && isAbility == true && isAttUp == true && utilityP2.isUnitEnemie == true)
        {
            if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }

        }

        //tanke sinistra
        if (Input.GetKeyDown(KeyCode.UpArrow) && isAbility == true && isAttDown == true && utilityP2.isUnitEnemie == true)
        {


            if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
            }

            //tank sopra
            if (Input.GetKeyDown(KeyCode.RightArrow) && isAbility == true && isAttLeft == true && utilityP2.isUnitEnemie == true)
            {

                if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
                {
                    DamageTankP1();
                    tankP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
                else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
                {
                    DamageHealerP1();
                    healerP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
                else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
                {
                    DamageUtilityP1();
                    utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
                else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
                {
                    DamageDealerP1();
                    dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }

            }

            // healer sotto
            if (Input.GetKeyDown(KeyCode.LeftArrow) && isAbility == true && isAttRight == true && utilityP2.isUnitEnemie == true)
            {

                if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
                {
                    DamageTankP1();
                    tankP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
                else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
                {
                    DamageHealerP1();
                    healerP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
                else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
                {
                    DamageUtilityP1();
                    utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
                else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
                {
                    DamageDealerP1();
                    dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                    yield return new WaitForSeconds(2f);
                    turn.isTurn = true;
                }
            }
        }
    }

        //disattivo prewiew attacco/abilità quando finisco turno
        public void DisactivePrewiewTank()
        {
            if (turn.isTurn == true)
            {
                isAbility = false;
            }
        }

        public void DamageTankP1()
        {
            lm.lifeTank -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveUtilityP2 = false;
            selectionP2.contSelectionP2 = 0;
            tankP1.isStun = true;
            // turn.isTurn = false;
            //tankP2.transform.DOShakePosition(2f, strength, vibrato);
        }

        public void DamageHealerP1()
        {
            lm.lifeHealer -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveUtilityP2 = false;
            selectionP2.contSelectionP2 = 0;
            healerP1.isStun = true;
        // turn.isTurn = false;
    }

        public void DamageUtilityP1()
        {
            lm.lifeUtility -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveUtilityP2 = false;
            selectionP2.contSelectionP2 = 0;
        utilityP1.isStun = true;
        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

        public void DamageDealerP1()
        {
            lm.lifeDealer -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
            selectionP2.isActiveUtilityP2 = false;
            selectionP2.contSelectionP2 = 0;
            dealerP1.isStun = true;
        // turn.isTurn = false;
    }

        public void Stun()
        {
            if (isStun == true && counter == 0 && turn.isTurn == true)
            {
                counter++;
            }
            else if (counter >= 1 && turn.isTurn == false)
            {
            tankP1.isStun = false;
            healerP1.isStun = false;
            utilityP1.isStun = false;
            dealerP1.isStun = false;
            counter = 0;
            }
        }


    }
