using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AttackBaseUtility : AttackBase 
{
    public LifeManager lm;
    public TurnManager turn;
    public int att = 3;
    public PositionUtility utility;
    public PositionTester2 tankP2;
    public PositionHealer2 healerP2;
    public PositionUtility2 utilityP2;
    public PositionDealer2 dealerP2;
    public int RangeHzTank;
    public int RangeVtTank;
    public int RangeHzHealer;
    public int RangeVtHealer;
    public int RangeHzUtility;
    public int RangeVtUtility;
    public int RangeHzDealer;
    public int RangeVtDealer;
    public bool isAttack;
    public KeyCode attackButton;
    public SelectionController selection;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public float strength;
    public int vibrato;
    public AbilityUtility ab;
    public float speedBullet = 500f;

    // Use this for initialization
    void Start()
    {
        selection = FindObjectOfType<SelectionController>();
        utility = FindObjectOfType<PositionUtility>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAttack = false;
        vibrato = 10;
        strength = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        SetAttackBase();
        RotationAttack();
        StartCoroutine(SetDirectionAttackBase());
        DisactivePrewiewUtility();
    }

   /* public void SetRange()
    {
        RangeHzTank = utility.maxRangeHzUtilityPlayer1 - tankP2.maxRangeHzTankPlayer2;
        RangeVtTank = utility.maxRangeVtUtilityPlayer1 - tankP2.maxRangeVtTankPlayer2;

        RangeHzHealer = utility.maxRangeHzUtilityPlayer1 - healerP2.maxRangeHzHealerPlayer2;
        RangeVtHealer = utility.maxRangeVtUtilityPlayer1 - healerP2.maxRangeVtHealerPlayer2;

        RangeHzUtility = utility.maxRangeHzUtilityPlayer1 - utilityP2.maxRangeHzUtilityPlayer2;
        RangeVtUtility = utility.maxRangeVtUtilityPlayer1 - utilityP2.maxRangeVtUtilityPlayer2;

        RangeHzDealer = utility.maxRangeHzUtilityPlayer1 - dealerP2.maxRangeHzDealerPlayer2;
        RangeVtDealer = utility.maxRangeVtUtilityPlayer1 - dealerP2.maxRangeVtDealerPlayer2;
    }*/

    public void SetAttackBase()
    {
        if (turn.isTurn == true && GameManager.singleton.acm.isAttackUtility == true && selection.isActiveUtility == true)
        {
            isAttack = true;
            gameObject.GetComponent<InputController>().enabled = false;
        }
        else if (turn.isTurn == true && GameManager.singleton.acm.isAttackUtility == false && selection.isActiveUtility == true)
        {
            isAttack = false;
            gameObject.GetComponent<InputController>().enabled = true;
        }
    }

    public void RotationAttack()
    {
        if (isAttack == true)
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
        //SetRange();

        if (Input.GetKeyDown(KeyCode.Space) && isAttack == true && utility.isUnitEnemie == true /*&& isAttUp == true*/)
        {
            if (utility.hit.transform.gameObject.GetComponent<PositionTester2>())
            {
                DamageTankP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                SoundManager.PlaySound(SoundManager.Sound.utilityAttack);
                // Shoot();
                //yield return new WaitForSeconds(0.5f);
                //GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxUtilityHit, new Vector3(tankP2.x, 0.3f, tankP2.y), Quaternion.identity);
                //tankP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
                //yield return new WaitForSeconds(0.5f);
                //Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);

                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utility.hit.transform.gameObject.GetComponent<PositionHealer2>())
            {
                DamageHealerP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                SoundManager.PlaySound(SoundManager.Sound.utilityAttack);
                //Shoot();
                //yield return new WaitForSeconds(0.5f);
                //GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxUtilityHit, new Vector3(healerP2.x, 0.3f, healerP2.y), Quaternion.identity);
                //healerP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
               // yield return new WaitForSeconds(0.5f);
                //Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utility.hit.transform.gameObject.GetComponent<PositionDealer2>())
            {
                DamageDealerP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                SoundManager.PlaySound(SoundManager.Sound.utilityAttack);
                //Shoot();
                //yield return new WaitForSeconds(0.5f);
                //GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxUtilityHit, new Vector3(utilityP2.x, 0.3f, utilityP2.y), Quaternion.identity);
                //dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
               // yield return new WaitForSeconds(0.5f);
                //Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
            else if (utility.hit.transform.gameObject.GetComponent<PositionUtility2>())
            {
                DamageUtilityP2();
				if (OnAttack != null)
				{
					OnAttack();
				}
                SoundManager.PlaySound(SoundManager.Sound.utilityAttack);
                //Shoot();
                //yield return new WaitForSeconds(0.5f);
                //GameObject gameObjectHit = Instantiate(GameManager.singleton.vfx.vfxUtilityHit, new Vector3(dealerP2.x, 0.3f, dealerP2.y), Quaternion.identity);
                //utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                utility.hit.transform.GetComponent<Player>().HitAnim();
                GameManager.singleton.acm.isActionUtility = false;
                GameManager.singleton.sc.isUtilityUsable = false;
               // yield return new WaitForSeconds(0.5f);
                //Destroy(gameObjectHit);
                yield return new WaitForSeconds(2f);
                GameManager.singleton.stateMachine.SMController.SetTrigger("GoToSelection");
                if (ab.Counter < 2)
                {
                    ab.Counter = 0;
                }
            }
        }
    }

    /*public void Shoot()
    {
        GameObject gameObject = Instantiate(GameManager.singleton.vfx.vfxUtilityAtt, transform.forward + new Vector3(utility.x, 1, utility.y), Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speedBullet);
    }*/

    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewUtility()
    {
        if (turn.isTurn == false)
        {
            isAttack = false;
        }
    }

    public void DamageTankP2()
    {
        lm.lifeTankPlayer2 -= att;
        //turn.isTurn = false;
        isAttack = false;
        selection.contSelectionP1 = 3;
        selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
       
    }

    public void DamageHealerP2()
    {
        lm.lifeHealerPlayer2 -= att;
        //turn.isTurn = false;
        isAttack = false;
        selection.contSelectionP1 = 3;
         selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;

    }

    public void DamageDealerP2()
    {
        lm.lifeDealerPlayer2 -= att;
        //turn.isTurn = false;
        isAttack = false;
        selection.contSelectionP1 = 3;
         selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        
    }

    public void DamageUtilityP2()
    {
        lm.lifeUtilityPlayer2 -= att;
        // turn.isTurn = false;
        isAttack = false;
        selection.contSelectionP1 = 3;
          selection.isActiveUtility = false;
        //riabilito input controller per i movimenti(wasd)
        gameObject.GetComponent<InputController>().enabled = true;
        
    }

}
