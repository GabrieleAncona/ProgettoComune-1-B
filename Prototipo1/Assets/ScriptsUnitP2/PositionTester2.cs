using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

//tank giocatore 2
public class PositionTester2 : MovementBase
{
    public float duration = 0.5f;
    public int x, y;
    public BaseGrid grid;
    public TurnManager turn;
    public SelectControllerP2 selectionP2;
    public int maxRangeHzTankPlayer2;
    public int maxRangeVtTankPlayer2;
    public int contMp;
    public bool isBlock;
    public bool isLeft;
    public bool isRight;
    public bool isDown;
    public bool isUp;
    public bool isUnitEnemie;
    public AttackBase2 att;
    public AbilityTank2 ab;
    public float timer;
    public RaycastHit hit;
    public LifeManager lm;
    public bool myTurn;
    public bool isStun;
    public bool isDead;

    public HudUnitController HUC;

    public void Start() {
        lm = FindObjectOfType<LifeManager>();
        timer = 0.5f;
        contMp = 3;
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
        transform.position = grid.GetWorldPosition(x, y);
        maxRangeHzTankPlayer2 = x;
        maxRangeVtTankPlayer2 = y;
        att = FindObjectOfType<AttackBase2>();
        ab = FindObjectOfType<AbilityTank2>();

    }

    void Update() {
        timer -= Time.deltaTime;
        RayCastingControllerAttack();
        RayCastingControllerAbility();
        Death();
        MyTurn();
        ResetMp();


    }

    public void GoToLeft() {
        if (x > 0 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveTankP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true) {

            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x--, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            if (OnMovement != null)
            {
                OnMovement();
            }
            turn.ContRound += 1;
            maxRangeHzTankPlayer2 = x;
            contMp--;
            isLeft = true;

            isUp = false;
            isRight = false;
            isDown = false;
            timer = 0.5f;
            if (ab.Counter < 2) {
                ab.Counter = 0;
            }
        }
    }

    public void GoToRight() {
        if (x < 11 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveTankP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true) {

            transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x++, y);
            transform.DOMoveX(x, duration).SetAutoKill(false);
            if (OnMovement != null)
            {
                OnMovement();
            }
            turn.ContRound += 1;
            maxRangeHzTankPlayer2 = x;
            contMp--;
            isRight = true;
            isLeft = false;
            isUp = false;
            isDown = false;
            timer = 0.5f;
            if (ab.Counter < 2) {
                ab.Counter = 0;
            }
        }
    }

    public void GoToDown() {
        if (y > 0 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveTankP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true) {

            transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y--);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            if (OnMovement != null)
            {
                OnMovement();
            }
            turn.ContRound += 1;
            maxRangeVtTankPlayer2 = y;
            contMp--;
            isDown = true;
            isRight = false;
            isLeft = false;
            isUp = false;
            timer = 0.5f;
            if (ab.Counter < 2) {
                ab.Counter = 0;
            }
        }
    }

    public void GoToUp() {
        if (y < 11 && turn.isTurn == false && contMp > 0 && selectionP2.isActiveTankP2 == true && timer < 0 && GameManager.singleton.acm.isMovement == true) {

            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
            transform.position = grid.GetWorldPosition(x, y++);
            transform.DOMoveZ(y, duration).SetAutoKill(false);
            if (OnMovement != null)
            {
                OnMovement();
            }
            turn.ContRound += 1;
            maxRangeVtTankPlayer2 = y;
            contMp--;
            isUp = true;
            isRight = false;
            isLeft = false;
            isDown = false;
            timer = 0.5f;
            if (ab.Counter < 2) {
                ab.Counter = 0;
            }
        }
    }


    public void ToPass() {
        turn.isTurn = true;
        contMp = 2;
        selectionP2.isActiveTankP2 = false;
    }

    public void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "UnitP1" || coll.gameObject.tag == "UnitP2") {
            Debug.Log("non ha senso");
            isBlock = true;
            if (myTurn == false) {

                if (isLeft == true) {
                    Debug.Log("cazzo in culo");
                    transform.position = grid.GetWorldPosition(x++, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzTankPlayer2 = x;
                    contMp++;

                }
                if (isRight == true) {
                    Debug.Log("cazzo in culo");
                    transform.position = grid.GetWorldPosition(x--, y);
                    transform.DOMoveX(x, duration).SetAutoKill(false);
                    maxRangeHzTankPlayer2 = x;
                    contMp++;

                }
                if (isDown == true) {
                    Debug.Log("cazzo in culo");
                    transform.position = grid.GetWorldPosition(x, y++);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtTankPlayer2 = y;
                    contMp++;

                }
                if (isUp == true) {
                    Debug.Log("cazzo in culo");
                    transform.position = grid.GetWorldPosition(x, y--);
                    transform.DOMoveZ(y, duration).SetAutoKill(false);
                    maxRangeVtTankPlayer2 = y;
                    contMp++;

                }
                Debug.Log("left: " + isLeft);
                Debug.Log("right: " + isRight);
                Debug.Log("up: " + isUp);
                Debug.Log("down: " + isDown);
            }
        }
    }

    public void OnTriggerExit(Collider coll) {
        if (coll.gameObject.tag == "Obstacle") {
            isBlock = false;
        }
    }


    public void RayCastingControllerAttack() {
        if (att.isAttack == true) {
            //RaycastHit hit;
            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 1) && hit.collider.tag == "UnitP1") {
                Debug.DrawRay(transform.position + new Vector3(0, 0.1f), Vector3.forward * hit.distance, Color.red);

                isUnitEnemie = true;

            }
            else {
                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitEnemie = false;
                Debug.Log("isUnitEnemie: " + isUnitEnemie);
            }

        }
    }

    public void RayCastingControllerAbility() {
        if (ab.isAbility == true) {
            Ray rayRight = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(rayRight, out hit, 2) && hit.collider.tag == "UnitP1") {
                Debug.DrawRay(transform.position + new Vector3(0, 0.2f), Vector3.forward * hit.distance, Color.red);

                isUnitEnemie = true;

            }
            else {
                //Debug.DrawRay(GameObject.FindGameObjectWithTag("UnitP2").transform.position + new Vector3(0, 0.5f), Vector3.right * hit.distance, Color.blue);
                isUnitEnemie = false;
            }
        }
    }

    public void GetDamage(int damage)
    {
        lm.lifeTankPlayer2 -= damage;
    }

    public void MyTurn()
    {
        if (selectionP2.isActiveTankP2 == true && turn.isTurn == false)
        {
            myTurn = true;
        }
        else
        {
            myTurn = false;
        }
    }

    public void Death() {

        if (lm.lifeTankPlayer2 <= 0) {

            gameObject.SetActive(false);
            isDead = true;
            lm.lifeTankPlayer2 = 0;
            if (OnDeath != null)
            {
                OnDeath();
            }
            SoundManager.PlaySound(SoundManager.Sound.tankDie);
            HUC.Cross.enabled = true;
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
