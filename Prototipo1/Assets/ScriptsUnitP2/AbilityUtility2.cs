using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityUtility2 : AbilityBase
{
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
    public int counterStun;
    public int Counter;
    public int CounterTurnA;
    public bool isCharging;
    public GameObject gameObjectVfx;

    // Use this for initialization
    void Start()
    {
        counterStun = 0;
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
        Counter = 2;
        CounterTurnA = 0;
    }

    void Update()
    {
        ChargeAbility();
        SetAttackBase();
        RotationAttack();
        StartCoroutine(SetDirectionAttackBase());
        DisactivePrewiewUtility();
        Stun();
        
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
        if (turn.isTurn == false && GameManager.singleton.acm.isAbilityUtility2 == true && selectionP2.isActiveUtilityP2 == true && Counter == 2)
        {
            isAbility = true;

            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (turn.isTurn == false && GameManager.singleton.acm.isAbilityUtility2 == false && selectionP2.isActiveUtilityP2 == true )
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
        if (Input.GetKeyDown(KeyCode.Return) && isAbility == true  && utilityP2.isUnitEnemie == true)
        {
            if (utilityP2.hit.transform.gameObject.GetComponent<PositionTester>())
            {
                DamageTankP1();
                if (OnAbility != null)
                {
                    OnAbility();
                }
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                //tankP1.transform.DOShakePosition(2f, strength, vibrato);
                utilityP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionHealer>())
            {
                DamageHealerP1();
                if (OnAbility != null)
                {
                    OnAbility();
                }
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                //healerP1.transform.DOShakePosition(2f, strength, vibrato);
                utilityP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionUtility>())
            {
                DamageUtilityP1();
                if (OnAbility != null)
                {
                    OnAbility();
                }
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                //utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                utilityP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
            }
            else if (utilityP2.hit.transform.gameObject.GetComponent<PositionDealer>())
            {
                DamageDealerP1();
                if (OnAbility != null)
                {
                    OnAbility();
                }
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                //dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                utilityP2.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility2 = false;
                GameManager.singleton.sc2.isUtilityUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
            }

        }

        
    }

        //disattivo prewiew attacco/abilità quando finisco turno
        public void DisactivePrewiewUtility()
        {
            if (turn.isTurn == true)
            {
                isAbility = false;
            utilityP2.contMp = 4;
        }
        }

        public void DamageTankP1()
        {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(tankP1.x, 1, tankP1.y), Quaternion.identity);
        lm.lifeTank -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
          selectionP2.isActiveUtilityP2 = false;
         selectionP2.contSelectionP2 = 3;
        tankP1.isStun = true;
            // turn.isTurn = false;
            //tankP2.transform.DOShakePosition(2f, strength, vibrato);
        }

        public void DamageHealerP1()
        {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(healerP1.x, 1, healerP1.y), Quaternion.identity);
        lm.lifeHealer -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
         selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 3;
        healerP1.isStun = true;
        // turn.isTurn = false;
    }

        public void DamageUtilityP1()
        {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(utilityP1.x, 1, utilityP1.y), Quaternion.identity);
        lm.lifeUtility -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
          selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 3;
        utilityP1.isStun = true;
        // turn.isTurn = false;
        //tankP2.transform.DOShakePosition(2f, strength, vibrato);
    }

        public void DamageDealerP1()
        {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(dealerP1.x, 1, dealerP1.y), Quaternion.identity);
        lm.lifeDealer -= att;
            isAbility = false;
            gameObject.GetComponent<InputController>().enabled = true;
          selectionP2.isActiveUtilityP2 = false;
        selectionP2.contSelectionP2 = 3;
        dealerP1.isStun = true;
        // turn.isTurn = false;
    }

        public void Stun()
        {
            if ((tankP1.isStun == true || healerP1.isStun == true || utilityP1.isStun == true || dealerP1.isStun == true) && counterStun == 0 && turn.isTurn == true)
            {
                counterStun++;
            }
            else if (counterStun >= 1 && turn.isTurn == false)
            {
            tankP1.isStun = false;
            healerP1.isStun = false;
            utilityP1.isStun = false;
            dealerP1.isStun = false;
            counterStun = 0;
            Destroy(gameObjectVfx);
        }
        }


    }
