using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;


public class AttackBaseHealer2 : MonoBehaviour {

    public LifeManager lm;
    public TurnManager turn;
    public int att = 1;
    public int attMax = 2;
    public PositionTester tankP1;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
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
    public int contTurn;
    public int lifeHitTankP1;
    public int lifeHitHealerP1;
    public bool isHitTankP1;
    public bool isHitHealerP1;
    public int lifeHitUtilityP1;
    public int lifeHitDealerP1;
    public bool isHitUtilityP1;
    public bool isHitDealerP1;
    public AbilityHealer2 ab;
    public GameObject vfxPoison;

    // Use this for initialization
    void Start()
    {

        selectionP2 = FindObjectOfType<SelectControllerP2>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
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
        ContTurn();
        DamageForTurn();
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
        if (turn.isTurn == false && GameManager.singleton.acm.isAttackHealer2 == true && selectionP2.isActiveHealerP2 == true)
        {
            isAttack = true;

            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (turn.isTurn == false && GameManager.singleton.acm.isAttackHealer2 == false && selectionP2.isActiveHealerP2 == true)
        {
            isAttack = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if (isAttack == true)
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
        if (Input.GetKeyDown(KeyCode.Return) && isAttack == true && healerP2.isUnitEnemie == true)
        {
            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                tankP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                healerP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }

        //tanke sinistra
       /* if (Input.GetKeyDown(KeyCode.I) && isAttack == true && isAttDown == true && healerP2.isUnitEnemie == true)
        {


            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionHealer>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer>())
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
        if (Input.GetKeyDown(KeyCode.L) && isAttack == true && isAttLeft == true && healerP2.isUnitEnemie == true)
        {

            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionHealer>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer>())
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
        if (Input.GetKeyDown(KeyCode.J) && isAttack == true && isAttRight == true && healerP2.isUnitEnemie == true)
        {

            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionHealer>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility>())
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
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer>())
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



    public void ContTurn()
    {
        if (turn.isTurn == true && contTurn == 0 && isHitTankP1 == true)
        {
            contTurn += 1;
        }

        if (turn.isTurn == true && contTurn == 0 && isHitTankP1 == true)
        {
            contTurn += 1;
        }
        if (turn.isTurn == true && contTurn == 0 && isHitUtilityP1 == true)
        {
            contTurn += 1;
        }
        if (turn.isTurn == true && contTurn == 0 && isHitDealerP1 == true)
        {
            contTurn += 1;
        }
    }

    public void DamageForTurn()
    {
        if (turn.isTurn == false && contTurn == 1 && isHitTankP1 == true)
        {

            lifeHitTankP1 -= att;
            lm.lifeTank = lifeHitTankP1;
            contTurn = 0;
            isHitTankP1 = false;
        }

        if (turn.isTurn == false && contTurn == 1 && isHitHealerP1 == true)
        {

            lifeHitHealerP1 -= att;
            lm.lifeHealer = lifeHitHealerP1;
            contTurn = 0;
            isHitHealerP1 = false;
        }
        if (turn.isTurn == false && contTurn == 1 && isHitUtilityP1 == true)
        {

            lifeHitUtilityP1 -= att;
            lm.lifeUtility = lifeHitUtilityP1;
            contTurn = 0;
            isHitUtilityP1 = false;
        }
        if (turn.isTurn == false && contTurn == 1 && isHitDealerP1 == true)
        {

            lifeHitDealerP1 -= att;
            lm.lifeDealer = lifeHitDealerP1;
            contTurn = 0;
            isHitDealerP1 = false;
        }
    }

    public void DamageTankP1()
    {
        lm.lifeTank -= attMax;
        Instantiate(vfxPoison, tankP1.transform.position, Quaternion.identity);
        
        isAttack = false;
        //turn.isTurn = true;
        isHitTankP1 = true;
        selectionP2.isActiveHealerP2 = false;
        gameObject.GetComponent<InputController>().enabled = true;
        lifeHitTankP1 = lm.lifeTank;
        //selectionP2.isActiveHealerP2 = false;
        selectionP2.contSelectionP2 = 0;
    }

    public void DamageHealerP1()
    {
        lm.lifeHealer -= attMax;
        Instantiate(vfxPoison,  new Vector3(healerP2.x , 0 , healerP2.y) , Quaternion.identity);
        isAttack = false;
        //turn.isTurn = true;
        isHitHealerP1 = true;
        selectionP2.isActiveHealerP2 = false;
        gameObject.GetComponent<InputController>().enabled = true;
        lifeHitHealerP1 = lm.lifeHealer;
        //selectionP2.isActiveHealerP2 = false;
        selectionP2.contSelectionP2 = 0;
    }

    public void DamageUtilityP1()
    {
        lm.lifeUtility -= attMax;
        Instantiate(vfxPoison, new Vector3(healerP2.x, 0, healerP2.y), Quaternion.identity);
        isAttack = false;
        //turn.isTurn = true;
        isHitUtilityP1 = true;
        selectionP2.isActiveHealerP2 = false;
        gameObject.GetComponent<InputController>().enabled = true;
        lifeHitUtilityP1 = lm.lifeUtility;
        //selectionP2.isActiveHealerP2 = false;
        selectionP2.contSelectionP2 = 0;
    }

    public void DamageDealerP1()
    {
        lm.lifeDealer -= attMax;
        Instantiate(vfxPoison, new Vector3(healerP2.x, 0, healerP2.y), Quaternion.identity);
        isAttack = false;
        //turn.isTurn = true;
        isHitDealerP1 = true;
        selectionP2.isActiveHealerP2 = false;
        gameObject.GetComponent<InputController>().enabled = true;
        lifeHitDealerP1 = lm.lifeDealer;
        // selectionP2.isActiveDealerP2 = false;
        selectionP2.contSelectionP2 = 0;
    }

    //disattivo prewiew attacco/abilità
    public void DisactivePrewiewHealerP2()
    {
        if (turn.isTurn == false)
        {
            isAttack = false;
        }
    }
}
