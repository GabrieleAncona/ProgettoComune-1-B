using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class PositionUtility2 : MonoBehaviour {

    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzUtilityPlayer2;
    public int maxRangeVtUtilityPlayer2;
    public int contMp;
    public SelectControllerP2 selection;
    public float duration = 0.5f;
    public bool isBlock;
    public bool isLeft;
    public bool isRight;
    public bool isDown;
    public bool isUp;
    public float sec = 3f;
    public AttackBaseUtility2 att;
    public AbilityUtility2 ab;
    public bool isUnitEnemie;
    public RaycastHit hit;
    public LifeManager lm;
    public float timer;
    public bool myTurn;
    public bool isStun;

    // Use this for initialization
    void Start()
    {
        timer = 0.5f;
        lm = FindObjectOfType<LifeManager>();
        selection = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzUtilityPlayer2 = x;
        maxRangeVtUtilityPlayer2 = y;
        //turn.isTurn = true;
        contMp = 3;
        att = FindObjectOfType<AttackBaseUtility2>();
        ab = FindObjectOfType<AbilityUtility2>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        RayCastingController();
    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == false && contMp > 0 && selection.isActiveUtilityP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzUtilityPlayer2 = x;
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
        if (x < 11 && turn.isTurn == false && contMp > 0 && selection.isActiveUtilityP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzUtilityPlayer2 = x;
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
        if (y > 0 && turn.isTurn == false && contMp > 0 && selection.isActiveUtilityP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false); ;
            turn.ContRound += 1;
            maxRangeVtUtilityPlayer2 = y;
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
        if (y < 11 && turn.isTurn == false && contMp > 0 && selection.isActiveUtilityP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtUtilityPlayer2 = y;
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
        turn.isTurn = true;
        selection.isActiveUtilityP2 = false;
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
                    maxRangeHzUtilityPlayer2 = x;
                    contMp++;

                }
                if (isRight == true)
                {
                    transform.position = grid.GetWorldPosition(x--, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzUtilityPlayer2 = x;
                    contMp++;
                }
                if (isDown == true)
                {
                    transform.position = grid.GetWorldPosition(x, y++);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtUtilityPlayer2 = y;
                    contMp++;
                }
                if (isUp == true)
                {
                    transform.position = grid.GetWorldPosition(x, y--);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtUtilityPlayer2 = y;
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

            if (Physics.Raycast(rayRight, out hit, 3) && hit.collider.tag == "UnitP1")
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.3f), Vector3.forward * hit.distance, Color.red);

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
        lm.lifeUtilityPlayer2 -= damage;
    }

    public void MyTurn()
    {
        if (selection.isActiveUtilityP2 == true && turn.isTurn == false)
        {
            myTurn = true;
        }
        else
        {
            myTurn = false;
        }
    }
}
