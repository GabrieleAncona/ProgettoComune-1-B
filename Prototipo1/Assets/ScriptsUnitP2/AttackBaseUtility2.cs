using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AttackBaseUtility2 : MonoBehaviour {
    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public PositionTester tankP1;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public PositionUtility2 utilityP2;
    public PositionDealer dealerP1;
    public PositionUtility utilityP1;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttack;
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
    public AbilityUtility2 ab;

    // Use this for initialization
    void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAttack = false;
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
        if (turn.isTurn == false && GameManager.singleton.acm.isAttackUtility2 == true && selectionP2.isActiveUtilityP2 == true)
        {
            isAttack = true;

            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (turn.isTurn == false && GameManager.singleton.acm.isAttackUtility2 == false && selectionP2.isActiveUtilityP2 == true)
        {
            isAttack = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if (isAttack == true)
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
        if (Input.GetKeyDown(KeyCode.Space) && isAttack == true  && utilityP2.isUnitEnemie == false)
        {
            if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }

        //tanke sinistra
        /*if (Input.GetKeyDown(KeyCode.I) && isAttack == true && isAttDown == true && utilityP2.isUnitEnemie == true)
        {

           
           if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                   ab.Counter = 0;
                }
            }
             else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
        }

        //tank sopra
        if (Input.GetKeyDown(KeyCode.L) && isAttack == true && isAttLeft == true && utilityP2.isUnitEnemie == true)
        {

            if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }

        // healer sotto
        if (Input.GetKeyDown(KeyCode.J) && isAttack == true && isAttRight == true && utilityP2.isUnitEnemie == true)
        {

            if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
        }*/
    }

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewTank()
    {
        if (turn.isTurn == true)
        {
            isAttack = false;
        }
    }

    public void DamageTankP1()
    {
        lm.lifeTank -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        // selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 0;
        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

    public void DamageHealerP1()
    {
        lm.lifeHealer -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        // selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 0;
        // turn.isTurn = false;
    }

    public void DamageUtilityP1()
    {
        lm.lifeUtility -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        // selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 0;
        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

    public void DamageDealerP1()
    {
        lm.lifeDealer -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        //selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 0;
        // turn.isTurn = false;
    }

}
