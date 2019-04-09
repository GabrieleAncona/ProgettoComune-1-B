using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

//healere giocatore 2
public class PositionHealer2 : MonoBehaviour
{
    public float duration = 0.5f;
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzHealerPlayer2;
    public int maxRangeVtHealerPlayer2;
    public int contMp;
    public SelectControllerP2 selectionP2;
    public bool isBlock;
    public bool isLeft;
    public bool isRight;
    public bool isDown;
    public bool isUp;
    public bool isUnitEnemie;
    public AttackBaseHealer2 att;
    public AbilityHealer2 ab;
    public bool isUnitAlly;
    public float timer;
    public RaycastHit hit;
    public LifeManager lm;
    public bool myTurn;
    public bool isStun;

    public void Start()
    {
        lm = FindObjectOfType<LifeManager>();
        timer = 0.5f;
        contMp = 4;
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x,y);
        maxRangeHzHealerPlayer2 = x;
        maxRangeVtHealerPlayer2 = y;
        att = FindObjectOfType<AttackBaseHealer2>();
        ab = FindObjectOfType<AbilityHealer2>();

    }

    void Update()
    {
        timer -= Time.deltaTime;
        RayCastingController();
    }

    public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveHealerP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzHealerPlayer2 = x;
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
        if (x < 11 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveHealerP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3 (0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeHzHealerPlayer2 = x;
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
        if (y > 0 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveHealerP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtHealerPlayer2 = y;
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
        if (y < 11 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveHealerP2 == true && timer < 0)
        {
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            turn.ContRound += 1;
            maxRangeVtHealerPlayer2 = y;
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
        contMp = 4;
        selectionP2.isActiveHealerP2 = false;
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
                    maxRangeHzHealerPlayer2 = x;
                    contMp++;
                }
                if (isRight == true)
                {
                    transform.position = grid.GetWorldPosition(x--, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzHealerPlayer2 = x;
                    contMp++;
                }
                if (isDown == true)
                {
                    transform.position = grid.GetWorldPosition(x, y++);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtHealerPlayer2 = y;
                    contMp++;
                }
                if (isUp == true)
                {
                    transform.position = grid.GetWorldPosition(x, y--);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtHealerPlayer2 = y;
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

            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 5) && hit.collider.tag == "UnitP1")
            {

                Debug.DrawRay(transform.position + new Vector3(0, 0.5f), Vector3.forward * hit.distance, Color.red);


                isUnitEnemie = true;



            }
            else
            {
                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitEnemie = false;
            }


            //raycast per abilità di cyra healer
            if (Physics.Raycast(rayRight, out hit, 5) && hit.collider.tag == "UnitP2")
            {
                isUnitAlly = true;
            }
            else
            {
                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitAlly = false;
            }

        }
    }

    public void GetDamage(int damage)
    {
        lm.lifeHealerPlayer2 -= damage;
    }

    public void MyTurn()
    {
        if (selectionP2.isActiveHealerP2 == true && turn.isTurn == false)
        {
            myTurn = true;
        }
        else
        {
            myTurn = false;
        }
    }
}
