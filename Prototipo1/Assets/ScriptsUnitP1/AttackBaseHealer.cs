using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AttackBaseHealer : MonoBehaviour{

    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionTester tankP1;
    public PositionHealer healerP1;
    public PositionHealer2 healerP2;
    public PositionTester2 tankP2;
    public PositionUtility2 utilityP2;
    public PositionDealer2 dealerP2;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttackHealer;
    public KeyCode attackButtonHealer;
    public int contTurn;
    public bool isHitHealer;
    public bool isHitTank;
    private int lifeHitHealerP2;
    private int lifeHitTankP2;
    public bool isHitUtility;
    public bool isHitDealer;
    private int lifeHitDealerP2;
    private int lifeHitUtilityP2;
    public SelectionController selection;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float strength;
    public int vibrato;
    public AbilityHealer ab;

    // Use this for initialization
    void Start()
    {
        selection = FindObjectOfType<SelectionController>();
        healerP1 = FindObjectOfType<PositionHealer>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAttackHealer = false;
        ab = FindObjectOfType<AbilityHealer>();
        vibrato = 10;
        strength = 0.1f;
    }

    void Update()
    {

        SetAttackBase();
        StartCoroutine(SetDirectionAttackBase());
        ContTurn();
        DamageForTurn();
        DisactivePrewiewHealer();
        RotationAttack();


    }

   /* public void SetRange()
    {


        RangeHzTank = tankP2.maxRangeHzTankPlayer2 - healerP1.maxRangeHzHealerPlayer1;
        RangeVtTank = tankP2.maxRangeVtTankPlayer2 - healerP1.maxRangeVtHealerPlayer1;
        RangeHzHealer = healerP2.maxRangeHzHealerPlayer2 - healerP1.maxRangeHzHealerPlayer1;
        RangeVtHealer = healerP2.maxRangeVtHealerPlayer2 - healerP1.maxRangeVtHealerPlayer1;
        // fare calcolo range altre unità


    }*/

    public void SetAttackBase()
    {
        if (Input.GetKeyDown(attackButtonHealer) && turn.isTurn == true && isAttackHealer == false && selection.isActiveHealer == true)
        {
            isAttackHealer = true;
            gameObject.GetComponent<InputController>().enabled = false;


        }
        else if (Input.GetKeyDown(attackButtonHealer) && turn.isTurn == true && isAttackHealer == true && selection.isActiveHealer == true)
        {
            isAttackHealer = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if (isAttackHealer == true)
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

    IEnumerator SetDirectionAttackBase()
    {
       // SetRange();
        // tanks
        if (Input.GetKeyDown(KeyCode.Space)  && isAttackHealer == true  && healerP1.isUnitEnemie == true)
        {
            if (healerP1.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }


        /*//tank
        if (Input.GetKeyDown(KeyCode.S) && isAttackHealer == true && isAttDown == true && healerP1.isUnitEnemie == true)
        {

            if (healerP1.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }



        //tank
        if (Input.GetKeyDown(KeyCode.A) && isAttackHealer == true && isAttLeft == true && healerP1.isUnitEnemie == true)
        {
            if (healerP1.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }


        // tank
        if (Input.GetKeyDown(KeyCode.D)  && isAttackHealer == true && isAttRight == true && healerP1.isUnitEnemie == true)
        {
            if (healerP1.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                healerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP1.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
        }*/


    }

    public void ContTurn()
    {
        if(turn.isTurn == false && contTurn == 0 && isHitTank == true)
        {
            contTurn += 1;
        }

        if(turn.isTurn == false && contTurn == 0 && isHitHealer == true)
        {
            contTurn += 1;
        }
        if (turn.isTurn == false && contTurn == 0 && isHitDealer == true)
        {
            contTurn += 1;
        }

        if (turn.isTurn == false && contTurn == 0 && isHitUtility == true)
        {
            contTurn += 1;
        }

    }

    public void DamageForTurn()
    {
        if (turn.isTurn == true && contTurn == 1 && isHitTank == true)
        {
            
            lifeHitTankP2 -= att;
            lm.lifeTankPlayer2 = lifeHitTankP2;
            contTurn = 0;
            isHitTank = false;
        }

        if (turn.isTurn == true && contTurn == 1 && isHitHealer == true)
        {

            lifeHitHealerP2 -= att;
            lm.lifeHealerPlayer2 = lifeHitHealerP2;
            contTurn = 0;
            isHitHealer = false;
        }
        if (turn.isTurn == true && contTurn == 1 && isHitUtility == true)
        {

            lifeHitUtilityP2 -= att;
            lm.lifeUtilityPlayer2 = lifeHitUtilityP2;
            contTurn = 0;
            isHitUtility = false;
        }

        if (turn.isTurn == true && contTurn == 1 && isHitDealer == true)
        {

            lifeHitDealerP2 -= att;
            lm.lifeDealerPlayer2 = lifeHitDealerP2;
            contTurn = 0;
            isHitDealer = false;
        }

    }

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewHealer()
    {
        if (turn.isTurn == false)
        {
            isAttackHealer = false;
        }
    }

    public void DamageTankP2()
    {
        lm.lifeTankPlayer2 -= att;
        isAttackHealer = false;
        //turn.isTurn = false;
        isHitTank = true;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.isActiveHealer = false;
        lifeHitTankP2 = lm.lifeTankPlayer2;
        selection.contSelectionP1 = 0;
    }

    public void DamageHealerP2()
    {
        lm.lifeHealerPlayer2 -= att;
        isAttackHealer = false;
        //turn.isTurn = false;
        isHitHealer = true;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.isActiveHealer = false;
        lifeHitHealerP2 = lm.lifeHealerPlayer2;
        selection.contSelectionP1 = 0;

    }
    public void DamageUtilityP2()
    {
        lm.lifeUtilityPlayer2 -= att;
        isAttackHealer = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.isActiveTank = false;
        selection.contSelectionP1 = 0;
        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

    public void DamageDealerP2()
    {
        lm.lifeDealerPlayer2 -= att;
        isAttackHealer = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.isActiveTank = false;
        selection.contSelectionP1 = 0;
        // turn.isTurn = false;
    }
}
