using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

//tank giocatore 1
public class PositionTester : MonoBehaviour
{
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public int maxRangeHzTankPlayer1;
    public int maxRangeVtTankPlayer1;
    public int contMp;
    public SelectionController selection;
    public float duration = 0.5f;
    public bool isBlock;
    public bool isLeft;
    public bool isRight;
    public bool isDown;
    public bool isUp;
    public float sec = 3f;
    public AttackBase1 att;
    public AbilityTank ab;
    public bool isUnitEnemie;
    public float timer;
    public RaycastHit hit;
    public LifeManager lm;
    public bool myTurn;
    public bool isStun;
    public bool isDead;
    public int idPlayer;

    //public float random;

    public void Start()
    {
        //myTurn = false;
        // random = 2f;
        lm = FindObjectOfType<LifeManager>();
        timer = 0.5f;
        selection = FindObjectOfType<SelectionController>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzTankPlayer1 = x;
        maxRangeVtTankPlayer1 = y;
        //turn.isTurn = true;
        contMp = 2;
        att = FindObjectOfType<AttackBase1>();
        ab = FindObjectOfType<AbilityTank>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        RayCastingControllerAttack();
        RayCastingControllerAbility();
        MyTurn();
        Death();

        if (selection.isActiveTank == false)
        {
            contMp = 2;
        }
    }

	public void GoToLeft()
    {
        if (x > 0 && turn.isTurn == true && contMp > 0 && selection.isActiveTank == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
            
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                transform.position = grid.GetWorldPosition(x--, y);
                transform.DOMoveX(x, duration).SetAutoKill(false);
                turn.ContRound += 1;
                maxRangeHzTankPlayer1 = x;
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
        if (x < 11 && turn.isTurn == true && contMp > 0 && selection.isActiveTank == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
         
                transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                transform.position = grid.GetWorldPosition(x++, y);
                transform.DOMoveX(x, duration).SetAutoKill(false);
                turn.ContRound += 1;
                maxRangeHzTankPlayer1 = x;
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
        if (y > 0 && turn.isTurn == true && contMp > 0 && selection.isActiveTank == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        {
           
                transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                transform.position = grid.GetWorldPosition(x, y--);
                transform.DOMoveZ(y, duration).SetAutoKill(false); ;
                turn.ContRound += 1;
                maxRangeVtTankPlayer1 = y;
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
        if (y < 11 && turn.isTurn == true && contMp > 0 && selection.isActiveTank == true && timer < 0 && GameManager.singleton.acm.isMovement == true)
        { 
            
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                transform.position = grid.GetWorldPosition(x, y++);
                transform.DOMoveZ(y, duration).SetAutoKill(false);
                turn.ContRound += 1;
                maxRangeVtTankPlayer1 = y;
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


   public  void ToPass()
    {
        if (att.isAttack == false && ab.isAbility == false)
        {
            turn.isTurn = false;
            selection.isActiveTank = false;
            contMp = 2;
        }
    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "UnitP1" || coll.gameObject.tag == "UnitP2")
        {
            
            isBlock = true;
            if (myTurn == true)
            {
                Debug.Log("entra");
                if (isLeft == true)
                {
                    transform.position = grid.GetWorldPosition(x++, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzTankPlayer1 = x;
                    contMp++;

                }
                if (isRight == true)
                {
                    transform.position = grid.GetWorldPosition(x--, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzTankPlayer1 = x;
                    contMp++;
                }
                if (isDown == true)
                {
                    transform.position = grid.GetWorldPosition(x, y++);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtTankPlayer1 = y;
                    contMp++;
                }
                if (isUp == true)
                {
                    transform.position = grid.GetWorldPosition(x, y--);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtTankPlayer1 = y;
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

    public void RayCastingControllerAttack() {
        if (att.isAttack == true) {
            //RaycastHit hit;
            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 1)) {
                if (hit.collider.tag == "UnitP2") {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.1f), transform.forward * hit.distance, Color.red);

                    isUnitEnemie = false;
                }
                else {
                    //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                    isUnitEnemie = true;
                    Debug.Log("isUnitEnemie " + isUnitEnemie);
                }

            }
        }
    }

    public void RayCastingControllerAbility() {
        if (ab.isAbility == true) {
            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 2) && hit.collider.tag == "UnitP2") {
                Debug.DrawRay(transform.position + new Vector3(0, 0.2f), Vector3.forward * hit.distance, Color.blue);

                isUnitEnemie = false;

            }
            else {

                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitEnemie = true;
            }
        }
    }

        

    public void GetDamage(int damage)
    {
        lm.lifeTank -= damage;
    }

    public void MyTurn()
    {
        if (selection.isActiveTank == true && turn.isTurn == true)
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

        if(lm.lifeTank <= 0) 
        {

            gameObject.SetActive(false);
            isDead = true;

        }

    }

}
