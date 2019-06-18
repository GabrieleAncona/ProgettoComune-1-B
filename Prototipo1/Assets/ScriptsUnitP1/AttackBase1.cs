using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AttackBase1 : AttackBase
{
    public LifeManager lm;
    public TurnManager turn;
    public int att = 4;
    public PositionTester tank;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public PositionUtility2 utilityP2;
    public PositionDealer2 dealerP2;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public bool isAttack;
    public KeyCode attackButton;
    public SelectionController selection;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float strength;
    public int vibrato;
    public BaseGrid grid;

    public AbilityTank ab;

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
        isAttack = false;
        vibrato = 10;
        strength = 0.1f;
        ab = FindObjectOfType<AbilityTank>();
    }
	
    void Update()
    {
        RotationAttack();
        SetAttackBase();
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
        if(turn.isTurn == true && GameManager.singleton.acm.isAttackTank == true && selection.isActiveTank == true)
        {
            isAttack = true;
            
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if(turn.isTurn == true && isAttack == true && GameManager.singleton.acm.isAttackTank == false && selection.isActiveTank == true)
        {
            isAttack = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if(isAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                
                transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                
                //tank.transform.position = grid.GetWorldPosition(tank.x, tank.y);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
               
                //tank.transform.position = grid.GetWorldPosition(tank.x, tank.y);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                
                //tank.transform.position = grid.GetWorldPosition(tank.x, tank.y);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                
                //tank.transform.position = grid.GetWorldPosition(tank.x, tank.y);
            }
        }
    }

    IEnumerator SetDirectionAttackBase()
    {
        //SetRange();
        //tank destra
        if(Input.GetKeyDown(KeyCode.Space) && isAttack == true  && tank.isUnitEnemie == false /* pezza*/)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                
                DamageTankP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
				tankP2.transform.DOShakePosition(2f, strength, vibrato);
				//lm.HitAnim();
                GameManager.singleton.acm.isActionTank = false;
                GameManager.singleton.sc.isTankUsable = false;
                yield return new WaitForSeconds(2f);
               
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
                
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
				healerP2.transform.DOShakePosition(2f, strength, vibrato);
				//lm.HitAnim();
				GameManager.singleton.acm.isActionTank = false;
                GameManager.singleton.sc.isTankUsable = false;
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
            { 
                DamageUtilityP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
				utilityP2.transform.DOShakePosition(2f, strength, vibrato);
				//lm.HitAnim();
				GameManager.singleton.acm.isActionTank = false;
                GameManager.singleton.sc.isTankUsable = false;
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
				dealerP2.transform.DOShakePosition(2f, strength, vibrato);
				//lm.HitAnim();
				GameManager.singleton.acm.isActionTank = false;
                GameManager.singleton.sc.isTankUsable = false;
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
        }
      
        /*//tanke sinistra
        if (Input.GetKeyDown(KeyCode.S)  && isAttack == true && isAttDown == true && tank.isUnitEnemie == false)
        {

            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                Debug.Log("s");
                tankP2.transform.DOShakePosition(2f, strength, vibrato);
                yield return new WaitForSeconds(2f);
                turn.isTurn = false;
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
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
      
        //tank sopra
        if (Input.GetKeyDown(KeyCode.A) && isAttack == true && isAttLeft == true && tank.isUnitEnemie == false)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
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
      
        // healer sotto
        if (Input.GetKeyDown(KeyCode.D)  && isAttack == true && isAttRight == true && tank.isUnitEnemie == false)
        {
            if (tank.hit.transform.gameObject.GetComponent<PositionTester2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionHealer2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionUtility2>())
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
            else if (tank.hit.transform.gameObject.GetComponent<PositionDealer2>())
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

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewTank()
    {
        if (turn.isTurn == false)
        {
            isAttack = false;
        }
    }

    public void DamageTankP2()
    {
        lm.lifeTankPlayer2 -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.isActiveTank = false;
        selection.contSelectionP1 = 1;
        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

    public void DamageHealerP2()
    {
        lm.lifeHealerPlayer2 -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 1;
         selection.isActiveTank = false;

        // turn.isTurn = false;
    }

    public void DamageUtilityP2()
    {
        lm.lifeUtilityPlayer2 -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 1;
         selection.isActiveTank = false;

        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

    public void DamageDealerP2()
    {
        lm.lifeDealerPlayer2 -= att;
        isAttack = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 1;
         selection.isActiveTank = false;

        // turn.isTurn = false;
    }

}
