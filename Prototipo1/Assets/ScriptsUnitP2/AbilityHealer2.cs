using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityHealer2 : AbilityBase
{
    public int heal = 4;
    public PositionHealer2 healerP2;
    public PositionDealer2 dealerP2;
    public PositionUtility2 utilityP2;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tankP2;
    //altre unità
    public int x, y;
    public int rangeHzTank;
    public int rangeVtTank;
    public bool isAbility;
    public SelectControllerP2 selectionP2;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float timerAutoHeal;
    public int Counter;
    public int CounterTurnA;
    public bool isCharging;
    public HudUnitController HUC;
    public GameObject tips;

    // Use this for initialization
    void Start()
    {
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        tankP2 = FindObjectOfType<PositionTester2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        Counter = 2;
        CounterTurnA = 0;
        timerAutoHeal = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChargeAbility();
        SetAbility();
        StartCoroutine(SetDirectionAbility());
        DisactivePrewiewHealerP2();
        RotationAbility();
        if (isAbility == false)
        {
            tips.SetActive(false);
        }
        if (isAbility == true)
        {
            tips.SetActive(true);
        }
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
            HUC.AbilityOff.enabled = false;
        }
    }

    public void SetAbility()
    {

        //abilito abilita
        if (turn.isTurn == false && GameManager.singleton.acm.isAbilityHealer2 == true && selectionP2.isActiveHealerP2 == true && Counter == 2)
        {

            isAbility = true;
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;

        }
        else if (turn.isTurn == false && GameManager.singleton.acm.isAbilityHealer2 == false && selectionP2.isActiveHealerP2 == true) 
        {
            isAbility = false;
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
        }

    }

    public void RotationAbility()
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

    //scelgo direzione dove lanciare l'abilita
    IEnumerator SetDirectionAbility()
    {
        //SetRange();
        //destra
        if (Input.GetKeyDown(KeyCode.Return)  && isAbility == true && healerP2.isUnitAlly == true /* altre unita */)
        {
            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                HealTank();
                GameObject gameObject = Instantiate(GameManager.singleton.vfx.vfxHealerHeal, new Vector3(tankP2.x, 0.3f, tankP2.y), Quaternion.identity);
                ///attivo clone instanziato
                gameObject.SetActive(true);
                SoundManager.PlaySound(SoundManager.Sound.tankAttack);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                yield return new WaitForSeconds(3f);
                Destroy(gameObject);
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                HealUtility();
                GameObject gameObject = Instantiate(GameManager.singleton.vfx.vfxHealerHeal, new Vector3(utilityP2.x, 0.3f, utilityP2.y), Quaternion.identity);
                ///attivo clone instanziato
                gameObject.SetActive(true);
                SoundManager.PlaySound(SoundManager.Sound.tankAttack);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                yield return new WaitForSeconds(3f);
                Destroy(gameObject);
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                HealDealer();
                GameObject gameObject = Instantiate(GameManager.singleton.vfx.vfxHealerHeal, new Vector3(dealerP2.x, 0.3f, dealerP2.y), Quaternion.identity);
                ///attivo clone instanziato
                gameObject.SetActive(true);
                SoundManager.PlaySound(SoundManager.Sound.tankAttack);
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                Counter = 0;
                yield return new WaitForSeconds(3f);
                Destroy(gameObject);
            }
        }
        //sinistra
       /* if (Input.GetKeyDown(KeyCode.I)  && isAbility == true  && isAttDown == true && healerP2.isUnitAlly == true)
        {
            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                HealTank();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                HealUtility();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                HealDealer();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
        }
        //sopra
        if (Input.GetKeyDown(KeyCode.L)  && isAbility == true  && isAttLeft == true && healerP2.isUnitAlly == true)
        {
            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                HealTank();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                HealUtility();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                HealDealer();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
        }
        //sotto
        if (Input.GetKeyDown(KeyCode.J)  && isAbility == true && isAttRight == true && healerP2.isUnitAlly == true)
        {

            if (healerP2.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                HealTank();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                HealUtility();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
            if (healerP2.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                HealDealer();
                yield return new WaitForSeconds(2f);
                turn.isTurn = true;
                Counter = 0;
            }
        }*/


        //auto heal
        if(Input.GetKey(KeyCode.Return) && isAbility == true && lm.lifeHealerPlayer2 < lm.lifeMaxHealerPlayer2)
        {
            timerAutoHeal += Time.deltaTime;

            if (timerAutoHeal >= 2)
            {
                lm.lifeHealerPlayer2 += heal;
                HUC.AbilityOff.enabled = true;
                lm.lifeHealerPlayer2 += heal;
                SoundManager.PlaySound(SoundManager.Sound.tankAttack);
                isAbility = false;
                selectionP2.isActiveHealerP2 = false;
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                //riabilito input controller per i movimenti(wasd)
                gameObject.GetComponent<InputController>().enabled = true;
                selectionP2.contSelectionP2 = 2;
                GameManager.singleton.acm.isActionHealer2 = false;
                GameManager.singleton.sc2.isHealerUsable2 = false;
                yield return new WaitForSeconds(2f);
                Counter = 0;
                timerAutoHeal = 0;
                if(lm.lifeHealerPlayer2 > lm.lifeMaxHealerPlayer2)
                {
                    lm.lifeHealerPlayer2 = lm.lifeMaxHealerPlayer2;
                    //timerAutoHeal = 0;
                }
            }  
        }
    }

    public void HealTank()
    {
        lm.lifeTankPlayer2 += heal;
        if (lm.lifeTankPlayer2 > lm.lifeMaxTankPlayer2)
        {
            lm.lifeTankPlayer2 = 20;
        }
        //turn.isTurn = true;
        isAbility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selectionP2.isActiveHealerP2 = false;
        HUC.AbilityOff.enabled = true;
        selectionP2.contSelectionP2 = 2;
    }

    public void HealUtility()
    {
        lm.lifeUtilityPlayer2 += heal;
        if (lm.lifeUtilityPlayer2 > lm.lifeMaxUtilityPlayer2)
        {
            lm.lifeUtilityPlayer2 = 20;
        }
        //turn.isTurn = true;
        isAbility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selectionP2.isActiveHealerP2 = false;
        HUC.AbilityOff.enabled = true;
        selectionP2.contSelectionP2 = 2;
    }


    public void HealDealer()
    {
        lm.lifeDealerPlayer2 += heal;
        if (lm.lifeDealerPlayer2 > lm.lifeMaxDealerPlayer2)
        {
            lm.lifeDealerPlayer2 = 20;
        }
        //turn.isTurn = true;
        isAbility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        selectionP2.isActiveHealerP2 = false;
        HUC.AbilityOff.enabled = true;
        selectionP2.contSelectionP2 = 2;
    }



    //set up range verticale e orrizontale per portata ability
    /*public void SetRange()
    {
        rangeHzTank = healerP2.maxRangeHzHealerPlayer2 - tankP2.maxRangeHzTankPlayer2;
        rangeVtTank = healerP2.maxRangeVtHealerPlayer2 - tankP2.maxRangeVtTankPlayer2;
        //altre unità
    }*/

    //disattivo prewiew attacco/abilità
    public void DisactivePrewiewHealerP2()
    {
        if (turn.isTurn == true)
        {
            isAbility = false;
            healerP2.contMp = 4;
        }
    }
}
