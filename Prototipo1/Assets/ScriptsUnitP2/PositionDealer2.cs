using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class PositionDealer2 : MonoBehaviour {
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzDealerPlayer2;
    public int maxRangeVtDealerPlayer2;
    public int contMp;
    public SelectControllerP2 selection;
    public float duration = 0.5f;
    public bool isBlock;
    public bool isLeft;
    public bool isRight;
    public bool isDown;
    public bool isUp;
    public float sec = 3f;
    public AttackBaseDealer2 att;
    public AbilityDealer2 ab;
    public bool isUnitEnemie;
    public RaycastHit hit;
    public LifeManager lm;
    public bool myTurn;
    public float timer;
    public bool isStun;
    public int contProv;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        contProv = 1;
        timer = 0.5f;
        lm = FindObjectOfType<LifeManager>();
        selection = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzDealerPlayer2 = x;
        maxRangeVtDealerPlayer2 = y;
        turn.isTurn = true;
        contMp = 3;
        att = FindObjectOfType<AttackBaseDealer2>();
        ab = FindObjectOfType<AbilityDealer2>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        RayCastingAttackController();
        Death();
        MyTurn();
        ResetMp();
        ///PEZZA
        if (contProv == 1)
        {
            transform.position = grid.GetWorldPosition(x, y);
            contProv = 0;
        }

      
        ///PEZZA
    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == false && contMp > 0 && selection.isActiveDealerP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzDealerPlayer2 = x;
            contMp--;
            isLeft = true;
            isUp = false;
            isRight = false;
            isDown = false;
            timer = 0.5f;
            if (ab.CounterA < 2)
            {
                ab.CounterA = 0;
            }
        }
    }
    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == false && contMp > 0 && selection.isActiveDealerP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzDealerPlayer2 = x;
            contMp--;
            isRight = true;
            isLeft = false;
            isUp = false;
            isDown = false;
            timer = 0.5f;
            if (ab.CounterA < 2)
            {
                ab.CounterA = 0;
            }
        }
    }
    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == false && contMp > 0 && selection.isActiveDealerP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false); ;
            turn.ContRound += 1;
            maxRangeVtDealerPlayer2 = y;
            contMp--;
            isDown = true;
            isRight = false;
            isLeft = false;
            isUp = false;
            timer = 0.5f;
            if (ab.CounterA < 2)
            {
                ab.CounterA = 0;
            }
        }
    }
    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == false && contMp > 0 && selection.isActiveDealerP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtDealerPlayer2 = y;
            contMp--;
            isUp = true;
            isRight = false;
            isLeft = false;
            isDown = false;
            timer = 0.5f;
            if (ab.CounterA < 2)
            {
                ab.CounterA = 0;
            }
        }
    }

    public void ToPass()
    {
        turn.isTurn = true;
        selection.isActiveDealerP2 = false;
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
                    maxRangeHzDealerPlayer2 = x;
                    contMp++;

                }
                if (isRight == true)
                {
                    transform.position = grid.GetWorldPosition(x--, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzDealerPlayer2 = x;
                    contMp++;
                }
                if (isDown == true)
                {
                    transform.position = grid.GetWorldPosition(x, y++);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtDealerPlayer2 = y;
                    contMp++;
                }
                if (isUp == true)
                {
                    transform.position = grid.GetWorldPosition(x, y--);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtDealerPlayer2 = y;
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

    public void RayCastingAttackController()
    {
        // primo raycast per attacco base
        if (att.isAttack == true)
        {
            //RaycastHit hit;
            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 4) && hit.collider.tag == "UnitP1")
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.4f), Vector3.forward * hit.distance, Color.red);

                isUnitEnemie = true;

            }
            else
            {
                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitEnemie = false;
            }

        }
    }

    public void GetDamage(int damage)
    {
        lm.lifeDealerPlayer2 -= damage;
    }

    public void MyTurn()
    {
        if (selection.isActiveDealerP2 == true && turn.isTurn == false)
        {
            myTurn = true;
        }
        else
        {
            myTurn = false;
        }
    }

    public void Death() {

        if (lm.lifeDealerPlayer2 == 0) {

            gameObject.SetActive(false);
            isDead = true;

        }

    }

    public void ResetMp()
    {
        if (turn.isTurn == true)
        {
            contMp = 3;
        }
    }
}
