﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityUtility : AbilityBase 
{

    public int att = 2;
    public PositionUtility utility;
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
    public int rangeHzUtility;
    public int rangeVtUtility;
    public int rangeHzDealer;
    public int rangeVtDealer;
    public bool isAbility;
    public SelectionController selection;
    public float duration = 0.2f;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public int CounterStun = 0;
    public float strength;
    public int vibrato;
    public int Counter;
    public int CounterTurnA;
    public bool isCharging;
    public HudUnitController HUC;
    public GameObject gameObjectVfx;
    public HudUnitsManager HUM;

    // Use this for initialization
    void Start()
    {
        CounterStun = 0;
        selection = FindObjectOfType<SelectionController>();
        utility = FindObjectOfType<PositionUtility>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        Counter = 2;
        CounterTurnA = 0;
        vibrato = 10;
        strength = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        ChargeAbility();
        Stun();
        SetAbility();
        StartCoroutine(SetDirectionAbility());
        DisactivePrewiewUtility();
        RotationAbility();
    }

  public void ChargeAbility()
    {
        if (Counter == 0 && CounterTurnA == 0 && turn.isTurn == false)
        {
            Counter = 1;
            CounterTurnA = 1;
        }
        if (Counter == 1 && CounterTurnA == 1 && turn.isTurn == true)
        {
            CounterTurnA = 2;
        }
        if (Counter == 1 && CounterTurnA == 2 && turn.isTurn == false)
        {
            Counter = 2;
            CounterTurnA = 0;
            HUC.AbilityOff.enabled = false;
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
        if (turn.isTurn == true && GameManager.singleton.acm.isAbilityUtility == true && selection.isActiveUtility == true && Counter == 2)
        {
            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;
        }
        else if (turn.isTurn == true && GameManager.singleton.acm.isAbilityUtility == false && selection.isActiveUtility == true)
        {
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    IEnumerator SetDirectionAbility()
    {
        //SetRange();
        //destra tank
        if (Input.GetKeyDown(KeyCode.Space) && isAbility == true && utility.isUnitEnemie == true)
        {
            if (utility.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                if (OnAbility != null)
				{
					OnAbility();
				}
                //tankP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                HUM.Freeze[0].enabled = true;
            }
            else if (utility.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                if (OnAbility != null)
				{
					OnAbility();
				}
                //healerP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                HUM.Freeze[1].enabled = true;
            }
            else if (utility.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                if (OnAbility != null)
				{
					OnAbility();
				}
                //dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                HUM.Freeze[2].enabled = true;
            }
            else if (utility.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
                SoundManager.PlaySound(SoundManager.Sound.ghiaccio);
                if (OnAbility != null)
				{
					OnAbility();
				}
                //utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                HUM.Freeze[3].enabled = true;
            }
        }
    

        
       
    }

    public void Stun()
    {
        if ((tankP2.isStun == true || healerP2.isStun == true || utilityP2.isStun == true || dealerP2.isStun == true) && CounterStun == 0 && turn.isTurn == false)
        {
            CounterStun++;
        }
        else if (CounterStun >= 1 && turn.isTurn == true)
        {
            tankP2.isStun = false;
            HUM.Freeze[0].enabled = false;
            healerP2.isStun = false;
            HUM.Freeze[1].enabled = false;
            utilityP2.isStun = false;
            HUM.Freeze[2].enabled = false;
            dealerP2.isStun = false;
            HUM.Freeze[3].enabled = false;
            CounterStun = 0;
            Destroy(gameObjectVfx);
        }
    }

    //set up range verticale e orrizontale per portata ability
    /*public void SetRange()
    {
        //range tank
        rangeHzTank = utility.maxRangeHzUtilityPlayer1 - tankP2.maxRangeHzTankPlayer2;
        rangeVtTank = utility.maxRangeVtUtilityPlayer1 - tankP2.maxRangeVtTankPlayer2;
        //range healer
        rangeHzHealer = utility.maxRangeHzUtilityPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        rangeVtHealer = utility.maxRangeVtUtilityPlayer1 - healerP2.maxRangeVtHealerPlayer2;

        rangeHzUtility = utility.maxRangeHzUtilityPlayer1 - utilityP2.maxRangeHzUtilityPlayer2;
        rangeVtUtility = utility.maxRangeVtUtilityPlayer1 - utilityP2.maxRangeVtUtilityPlayer2;

        rangeHzDealer = utility.maxRangeHzUtilityPlayer1 - dealerP2.maxRangeHzDealerPlayer2;
        rangeVtDealer = utility.maxRangeVtUtilityPlayer1 - dealerP2.maxRangeVtDealerPlayer2;
    }*/

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewUtility()
    {
        if (turn.isTurn == false)
        {
            isAbility = false;
            utility.contMp = 4;
        }
    }

    public void DamageTankP2()
    {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(tankP2.x, 1, tankP2.y), Quaternion.identity);
        lm.lifeTankPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        tankP2.isStun = true;
        HUC.AbilityOff.enabled = true;
    }

    public void DamageHealerP2()
    {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(healerP2.x, 1, healerP2.y), Quaternion.identity);
        lm.lifeHealerPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        healerP2.isStun = true;
        HUC.AbilityOff.enabled = true;
    }

    public void DamageUtilityP2()
    {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(utilityP2.x, 1, utilityP2.y), Quaternion.identity);
        lm.lifeUtilityPlayer2 -= att;
       // turn.isTurn = false;
        isAbility = false;
        selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        utilityP2.isStun = true;
        HUC.AbilityOff.enabled = true;
        selection.contSelectionP1 = 3;
    }

    public void DamageDealerP2()
    {
        gameObjectVfx = Instantiate(GameManager.singleton.vfx.vfxUtilityAb, new Vector3(dealerP2.x, 1, dealerP2.y), Quaternion.identity);
        lm.lifeDealerPlayer2 -= att;
        //turn.isTurn = false;
        isAbility = false;
        selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        dealerP2.isStun = true;
        HUC.AbilityOff.enabled = true;
        selection.contSelectionP1 = 3;
    }
}
