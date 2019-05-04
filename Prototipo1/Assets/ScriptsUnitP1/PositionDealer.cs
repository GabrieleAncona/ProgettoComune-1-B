using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class PositionDealer : MonoBehaviour {

    public int x ,y;
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
    public AttackBaseDealer att;
    public AbilityDealer ab;
    public bool isUnitEnemie;
    public RaycastHit hit;
    public LifeManager lm;
    public bool isStun;
    public bool myTurn;
    public float timer;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        timer = 0.5f;
        myTurn = false;
        lm = FindObjectOfType<LifeManager>();
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        Debug.Log("X: " + x + "Y: " + y);
        turn.isTurn = true;
        contMp = 3;
        att = FindObjectOfType<AttackBaseDealer>();
        ab = FindObjectOfType<AbilityDealer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //transform.position = grid.GetWorldPosition(x, y);
        RayCastingAttackController();
        Death();
        MyTurn();

        if (selection.isActiveDealer == false)
        {
            contMp = 3;
        }
    }

    public void GoToLeft()
    {
        Debug.Log("entra" + contMp);
        if (x > 0 && turn.isTurn == true && contMp > 0 && selection.isActiveDealer == true && timer < 0)
        {
            
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            timer = 0.5f;
            contMp--;
            isLeft = true;
            isUp = false;
            isRight = false;
            isDown = false;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }

    public void GoToRight()
    {
        if (x < 11 && turn.isTurn == true && contMp > 0 && selection.isActiveDealer == true && timer < 0)
        {

            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            timer = 0.5f;
            contMp--;
            isRight = true;
            isLeft = false;
            isUp = false;
            isDown = false;

            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }

    public void GoToDown()
    {
        if (y > 0 && turn.isTurn == true && contMp > 0 && selection.isActiveDealer == true && timer < 0)
        {

            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false); ;
            turn.ContRound += 1;
            timer = 0.5f;
            contMp--;
            isDown = true;
            isRight = false;
            isLeft = false;
            isUp = false;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }

    public void GoToUp()
    {
        if (y < 11 && turn.isTurn == true && contMp > 0 && selection.isActiveDealer == true && timer < 0)
        {

            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            timer = 0.5f;
            contMp--;
            isUp = true;
            isRight = false;
            isLeft = false;
            isDown = false;
            if (ab.Counter < 2)
            {
                ab.Counter = 0;
            }
        }
    }


    public void ToPass()
    {
        turn.isTurn = false;
        selection.isActiveDealer = false;
        contMp = 3;
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "UnitP1" || coll.gameObject.tag == "UnitP2")
        {
            Debug.Log("collider funziona");
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

    public void RayCastingAttackController()
    {
             // primo raycast per attacco base
            if (att.isAttack == true)
            {
                //RaycastHit hit;
                Ray rayRight = new Ray(transform.position, transform.forward);

                if (Physics.Raycast(rayRight, out hit, 4) && hit.collider.tag == "UnitP2")
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
        lm.lifeDealer -= damage;
    }

    public void MyTurn()
    {
        if (selection.isActiveDealer == true && turn.isTurn == true)
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

        if (lm.lifeDealer <= 0) {

            gameObject.SetActive(false);
            isDead = true;

        }

    }
}
