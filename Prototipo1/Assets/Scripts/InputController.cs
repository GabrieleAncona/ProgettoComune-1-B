﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;
using UnityEngine.UI;


public class InputController : MonoBehaviour {
    public float timer;
    
    public KeyCode UpButton;
    public KeyCode DownButton;
    public KeyCode LeftButton;
    public KeyCode RightButton;
    public KeyCode PassButton;
    public TurnManager turn;

    public AttackBase1 attTankP1;
    public AttackBase2 attTankP2;
    public AttackBaseHealer attHealerP1;
    public AttackBaseHealer2 attHealerP2;
    public AttackBaseUtility attUtilityP1;
    public AttackBaseUtility2 attUtilityP2;
    public AttackBaseDealer attDealerP1;
    public AttackBaseDealer2 attDealerP2;
    

    public AbilityTank abTankP1;
    public AbilityTank2 abTankP2;
    public AbilityHealer abHealerP1;
    public AbilityHealer2 abHealerP2;
    public AbilityUtility abUtilityP1;
    public AbilityUtility2 abUtilityP2;
    public AbilityDealer abDealerP1;
    public AbilityDealer2 abDealerP2;
    

    void Start()
    {
        timer = 0f;
        attTankP1 = FindObjectOfType<AttackBase1>();
        attTankP2 = FindObjectOfType<AttackBase2>();
        attHealerP1 = FindObjectOfType<AttackBaseHealer>();
        attHealerP2 = FindObjectOfType<AttackBaseHealer2>();
        attUtilityP1 = FindObjectOfType<AttackBaseUtility>();
        attUtilityP2 = FindObjectOfType<AttackBaseUtility2>();
        attDealerP1 = FindObjectOfType<AttackBaseDealer>();
        attDealerP2 = FindObjectOfType<AttackBaseDealer2>();

        abTankP1 = FindObjectOfType<AbilityTank>();
        abTankP2 = FindObjectOfType<AbilityTank2>();
        abHealerP1 = FindObjectOfType<AbilityHealer>();
        abHealerP2 = FindObjectOfType<AbilityHealer2>();
        abUtilityP1 = FindObjectOfType<AbilityUtility>();
        abUtilityP2 = FindObjectOfType<AbilityUtility2>();
        abDealerP1 = FindObjectOfType<AbilityDealer>();
        abDealerP2 = FindObjectOfType<AbilityDealer2>();

    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKeyDown(LeftButton))
        {
            ///left
            SendMessage("GoToLeft");
           
      
        }

        if (Input.GetKeyDown(RightButton))
        {
            ///right
            SendMessage("GoToRight");
           


        }

        if (Input.GetKeyDown(UpButton))
        {
            ///up
            SendMessage("GoToUp");
           


        }

        if (Input.GetKeyDown(DownButton))
        {
            ///down
            SendMessage("GoToDown");
           

        }

        if (Input.GetKey(PassButton))
        {
            timer += Time.deltaTime;
            if (attTankP1.isAttack == false && attTankP2.isAttack == false && abTankP1.isAbility == false && abTankP2.isAbility == false 
                && attHealerP1.isAttackHealer == false && attHealerP2.isAttack == false && abHealerP1.isAbility == false && abHealerP2.isAbility == false 
                && attUtilityP1.isAttack == false && attUtilityP2.isAttack == false && abUtilityP1.isAbility == false && abUtilityP2.isAbility == false 
                && attDealerP1.isAttack == false && attDealerP2.isAttack == false && abDealerP1.isAbility == false && abDealerP2.isAbility == false && timer >= 3f)
            {
                SendMessage("ToPass");
                timer = 0f;
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToEndTurn");
            }
           
        }

       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.singleton.sc.isActiveTank == true)
            {
                GameManager.singleton.sc.isActiveTank = false;
            }
           else if (GameManager.singleton.sc.isActiveHealer == true)
            {
                GameManager.singleton.sc.isActiveHealer = false;
            }
           else if (GameManager.singleton.sc.isActiveUtility == true)
            {
                GameManager.singleton.sc.isActiveUtility = false;
            }
            else if (GameManager.singleton.sc.isActiveDealer == true)
            {
                GameManager.singleton.sc.isActiveDealer = false;
            }
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
        }

    }
}
