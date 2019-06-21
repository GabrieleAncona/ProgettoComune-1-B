using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AttackBaseHealer : AttackBase
{

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
    public RaycastHit hitUnits;
    public UnitsData units;
    public float speedBullet = 500f;
    public GameObject gameObjectDot;

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
        if (turn.isTurn == true && GameManager.singleton.acm.isAttackHealer == true && selection.isActiveHealer == true)
        {
            isAttackHealer = true;
            gameObject.GetComponent<InputController>().enabled = false;


        }
        else if (turn.isTurn == true && GameManager.singleton.acm.isAttackHealer == false && selection.isActiveHealer == true)
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
            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester2>())
            {

                ///hitUnits.transform.gameObject.GetComponent<UnitController>().pedina.life -= GameManager.singleton.lm.DamageAttack(units.damageAttackBase);
                DamageTankP2();
                if (OnAttack != null)
				{
					OnAttack();
				}
                Shoot();
                yield return new WaitForSeconds(0.5f);
                GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxHealerHit, new Vector3(tankP2.x, 0.3f, tankP2.y), Quaternion.identity);
                //tankP2.transform.DOShakePosition(2f, strength, vibrato);
                healerP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionHealer = false;
                GameManager.singleton.sc.isHealerUsable = false;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                Shoot();
                yield return new WaitForSeconds(0.5f);
                GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxHealerHit, new Vector3(healerP2.x, 0.3f, healerP2.y), Quaternion.identity);
                //healerP2.transform.DOShakePosition(2f, strength, vibrato);
                healerP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionHealer = false;
                GameManager.singleton.sc.isHealerUsable = false;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                Shoot();
                yield return new WaitForSeconds(0.5f);
                GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxHealerHit, new Vector3(utilityP2.x, 0.3f, utilityP2.y), Quaternion.identity);
                //utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                healerP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionHealer = false;
                GameManager.singleton.sc.isHealerUsable = false;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                Shoot();
                yield return new WaitForSeconds(0.5f);
                GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxHealerHit, new Vector3(dealerP2.x, 0.3f, dealerP2.y), Quaternion.identity);
                //dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                healerP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionHealer = false;
                GameManager.singleton.sc.isHealerUsable = false;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }

        }


       


    }

    /// <summary>
    /// funzione per instanzare vfx attacco
    /// </summary>
    public void Shoot()
    {
        GameObject gameObject = Instantiate(GameManager.singleton.vfx.vfxHealerPosion, transform.forward + new Vector3(healerP1.x, 1, healerP1.y), Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speedBullet);
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
            Destroy(gameObjectDot);
            lifeHitTankP2 -= att;
            lm.lifeTankPlayer2 = lifeHitTankP2;
            contTurn = 0;
            isHitTank = false;
        }

        if (turn.isTurn == true && contTurn == 1 && isHitHealer == true)
        {
            Destroy(gameObjectDot);
            lifeHitHealerP2 -= att;
            lm.lifeHealerPlayer2 = lifeHitHealerP2;
            contTurn = 0;
            isHitHealer = false;
        }
        if (turn.isTurn == true && contTurn == 1 && isHitUtility == true)
        {
            Destroy(gameObjectDot);
            lifeHitUtilityP2 -= att;
            lm.lifeUtilityPlayer2 = lifeHitUtilityP2;
            contTurn = 0;
            isHitUtility = false;
        }

        if (turn.isTurn == true && contTurn == 1 && isHitDealer == true)
        {
            Destroy(gameObjectDot);
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
        gameObjectDot = Instantiate(GameManager.singleton.vfx.vfxHealerDot, new Vector3(tankP2.x, 1, tankP2.y), Quaternion.identity);
        lm.lifeTankPlayer2 -= att;
        isAttackHealer = false;
        //turn.isTurn = false;
        isHitTank = true;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 2;
        selection.isActiveHealer = false;
        lifeHitTankP2 = lm.lifeTankPlayer2;
       
    }

    public void DamageHealerP2()
    {
        gameObjectDot = Instantiate(GameManager.singleton.vfx.vfxHealerDot, new Vector3(healerP2.x, 1, healerP2.y), Quaternion.identity);
        lm.lifeHealerPlayer2 -= att;
        isAttackHealer = false;
        //turn.isTurn = false;
        isHitHealer = true;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.isActiveHealer = false;
        lifeHitHealerP2 = lm.lifeHealerPlayer2;
        selection.contSelectionP1 = 2;

    }
    public void DamageUtilityP2()
    {
        gameObjectDot = Instantiate(GameManager.singleton.vfx.vfxHealerDot, new Vector3(utilityP2.x, 1, utilityP2.y), Quaternion.identity);
        lm.lifeUtilityPlayer2 -= att;
        isAttackHealer = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 2;
        selection.isActiveHealer = false;

        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

    public void DamageDealerP2()
    {
        gameObjectDot = Instantiate(GameManager.singleton.vfx.vfxHealerDot, new Vector3(dealerP2.x, 1, dealerP2.y), Quaternion.identity);
        lm.lifeDealerPlayer2 -= att;
        isAttackHealer = false;
        gameObject.GetComponent<InputController>().enabled = true;
        selection.contSelectionP1 = 2;
        selection.isActiveHealer = false;

        // turn.isTurn = false;
    }
}
