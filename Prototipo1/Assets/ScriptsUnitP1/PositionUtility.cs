using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class PositionUtility : MovementBase
{
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzUtilityPlayer1;
    public int maxRangeVtUtilityPlayer1;
    public int contMp;
    public SelectionController selection;
    public float duration = 0.5f;
    public bool isBlock;
    public bool isLeft;
    public bool isRight;
    public bool isDown;
    public bool isUp;
    public float sec = 3f;
    public AttackBaseUtility att;
    public AbilityUtility ab;
    public bool isUnitEnemie;
    public RaycastHit hit;
    public LifeManager lm;
    public bool myTurn;
    public bool isStun;
    public float timer;
    public bool isDead;
    public int idPlayer;

    // Use this for initialization
    void Start()
    {
        timer = 0.5f;
        myTurn = false;
        lm = FindObjectOfType<LifeManager>();
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzUtilityPlayer1 = x;
        maxRangeVtUtilityPlayer1 = y;
        turn.isTurn = true;
        contMp = 4;
        att = FindObjectOfType<AttackBaseUtility>();
        ab = FindObjectOfType<AbilityUtility>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        RayCastingController();
        MyTurn();
        Death();
        ResetMp();
    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == true && contMp > 0 && selection.isActiveUtility == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {

            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
			if (OnMovement != null)
			{
				OnMovement();
			}
			turn.ContRound += 1;
            maxRangeHzUtilityPlayer1 = x;
            contMp--;
            isLeft = true;
            isUp = false;
            isRight = false;
            isDown = false;
            timer = 0.5f;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == true && contMp > 0 && selection.isActiveUtility == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {

            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
			if (OnMovement != null)
			{
				OnMovement();
			}
			turn.ContRound += 1;
            maxRangeHzUtilityPlayer1 = x;
            contMp--;
            isRight = true;
            isLeft = false;
            isUp = false;
            isDown = false;
            timer = 0.5f;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }

        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == true && contMp > 0 && selection.isActiveUtility == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {

            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
			if (OnMovement != null)
			{
				OnMovement();
			}
			turn.ContRound += 1;
            maxRangeVtUtilityPlayer1 = y;
            contMp--;
            isDown = true;
            isRight = false;
            isLeft = false;
            isUp = false;
            timer = 0.5f;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == true && contMp > 0 && selection.isActiveUtility == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {

            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
			if (OnMovement != null)
			{
				OnMovement();
			}
			turn.ContRound += 1;
            maxRangeVtUtilityPlayer1 = y;
            contMp--;
            isUp = true;
            isRight = false;
            isLeft = false;
            isDown = false;
            timer = 0.5f;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }


    public void ToPass()
    {
        turn.isTurn = false;
        selection.isActiveUtility = false;
        contMp = 3;
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "UnitP1" || coll.gameObject.tag == "UnitP2")
        {
            isBlock = true;
            if (myTurn == true)
            {
                if (isLeft == true)
                {
                    transform.position = grid.GetWorldPosition(x++, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzUtilityPlayer1 = x;
                    contMp++;

                }
                if (isRight == true)
                {
                    transform.position = grid.GetWorldPosition(x--, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzUtilityPlayer1 = x;
                    contMp++;
                }
                if (isDown == true)
                {
                    transform.position = grid.GetWorldPosition(x, y++);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtUtilityPlayer1 = y;
                    contMp++;
                }
                if (isUp == true)
                {
                    transform.position = grid.GetWorldPosition(x, y--);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtUtilityPlayer1 = y;
                    contMp++;
                }
            }
        }
    }

    public void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            isBlock = false;
        }
    }

    public void RayCastingController()
    {
        if (att.isAttack == true || ab.isAbility == true)
        {
            //RaycastHit hit;
            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 3) && hit.collider.tag == "UnitP2")
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.3f), Vector3.forward * hit.distance, Color.red);

                isUnitEnemie = true;

            }
            else
            {
                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitEnemie = false;
                Debug.Log("isUnitEnemie " + isUnitEnemie);
            }
        }
    }

    public void GetDamage(int damage)
    {
        lm.lifeUtility -= damage;
    }

    public void MyTurn()
    {
        if (selection.isActiveUtility == true && turn.isTurn == true)
        {
            myTurn = true;
        }
        else
        {
            myTurn = false;
        }
    }

    public void Death() 
    {

        if (lm.lifeUtility <= 0) {

            //gameObject.SetActive(false);
            isDead = true;
            if (OnDeath != null)
            {
                OnDeath();
            }

        }

    }

    public void ResetMp()
    {
        if (turn.isTurn == false)
        {
            contMp = 4;
        }
    }
    public void TestAnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
