using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityDealer2 : MonoBehaviour
{
    public BaseGrid grid;
    public KeyCode abilityButton;
    public TurnManager turn;
    public PositionDealer2 dealerP2;
    public int x, y;
    public bool isAbility;
    public SelectControllerP2 selectionP2;
    public float duration = 0.2f;
    public bool isAttRight;
    public bool isAttLeft;
    public bool isAttUp;
    public bool isAttDown;
    public int Counter = 0;
    public bool isStun;
    public GameObject selector;
    public int rangeFire;
    public int cont;
    public GameObject fireBall;
    public int speed;

    public int CounterA;
    public int CounterTurnA;
    public bool isCharging;

    // Use this for initialization
    void Start()
    {
        speed = 100;
        cont = 0;
        x = dealerP2.x;
        y = dealerP2.y;
        // controllare
        selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
        transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
        selector.transform.GetChild(0).gameObject.SetActive(false);
        selectionP2 = Object.FindObjectOfType<SelectControllerP2>().GetComponent<SelectControllerP2>();
       
        dealerP2 = FindObjectOfType<PositionDealer2>();
       
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        CounterA = 2;
        CounterTurnA = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PassTurn());
    }

    public void ChargeAbility()
    {
        if (CounterA == 0 && CounterTurnA == 0 && turn.isTurn == true)
        {
            CounterA = 1;
            CounterTurnA = 1;
        }
        if (CounterA == 1 && CounterTurnA == 1 && turn.isTurn == false)
        {
            CounterTurnA = 2;
        }
        if (CounterA == 1 && CounterTurnA == 2 && turn.isTurn == true)
        {
            CounterA = 2;
            CounterTurnA = 0;
        }
    }

    IEnumerator PassTurn()
    {
        ChargeAbility();
        SetAbility();
        SetRange();
        DisactivePrewiewDealer();
        RotationAbility();
        ActiveSelector();
        if (Input.GetKeyDown(KeyCode.RightControl) && isAbility == true)
        {
            Shoot();
            isAbility = false;
            // selectionP2.isActiveDealerP2 = false;
            dealerP2.contMp = 3;
            GameManager.singleton.acm.isActionDealer2 = false;
            yield return new WaitForSeconds(3f);
            selector.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToActionMenu");
        }
    }
        public void RotationAbility()
        {
            if (isAbility == true)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                    isAttUp = true;
                    isAttDown = false;
                    isAttLeft = false;
                    isAttRight = false;

                    x = dealerP2.x;
                    y = dealerP2.y;


                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                    isAttUp = false;
                    isAttDown = true;
                    isAttLeft = false;
                    isAttRight = false;

                    x = dealerP2.x;
                    y = dealerP2.y;


                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                    isAttUp = false;
                    isAttDown = false;
                    isAttLeft = false;
                    isAttRight = true;

                    x = dealerP2.x;
                    y = dealerP2.y;

                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                    isAttUp = false;
                    isAttDown = false;
                    isAttLeft = true;
                    isAttRight = false;

                    x = dealerP2.x;
                    y = dealerP2.y;

                }
            }
        }

        public void SetAbility()
        {
            //abilito abilita
            if (turn.isTurn == false && GameManager.singleton.acm.isAbilityDealer2 == true && selectionP2.isActiveDealerP2 == true && CounterA == 2)
            {
                isAbility = true;
            selector.transform.GetChild(0).gameObject.SetActive(true);
            selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;
            }
            else if (turn.isTurn == false && GameManager.singleton.acm.isAbilityDealer2 == false && selectionP2.isActiveDealerP2 == true)
            {
                isAbility = false;
            selector.transform.GetChild(0).gameObject.SetActive(true);
            //riabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = true;
            }
        }

        //set up range verticale e orrizontale per portata ability
        public void SetRange()
        {

            rangeFire = 4;

        }

        public void ActiveSelector()
        {
            if (isAbility == true)
            {
                if (isAttUp == true && Input.GetKeyDown(KeyCode.RightShift))
                {

                    if (cont <= rangeFire - 1 && x <= 11)
                    {
                        x++;
                        cont++;
                        selector.transform.position = grid.GetWorldPosition(x, y);
                        Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                    else if (cont >= rangeFire || x > 11)
                    {
                        cont = 0;
                    x = dealerP2.x;
                    y = dealerP2.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
                    CounterA = 0;
                }
                }
                else if (isAttDown == true && Input.GetKeyDown(KeyCode.RightShift))
                {

                    if (cont <= rangeFire - 1 && x >= 0)
                    {
                        x--;
                        cont++;
                        selector.transform.position = grid.GetWorldPosition(x, y);
                        Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                    else if (cont >= rangeFire || x < 0)
                    {
                        cont = 0;
                    x = dealerP2.x;
                    y = dealerP2.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
                    CounterA = 0;
                }
                }
                if (isAttLeft == true && Input.GetKeyDown(KeyCode.RightShift))
                {

                    if (cont <= rangeFire - 1 && y <= 11)
                    {
                        y++;
                        cont++;
                        selector.transform.position = grid.GetWorldPosition(x, y);
                        Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                    else if (cont >= rangeFire || y >= 11)
                    {
                        cont = 0;
                    x = dealerP2.x;
                    y = dealerP2.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
                        Debug.Log(dealerP2.y);
                    CounterA = 0;
                }
                }
                else if (isAttRight == true && Input.GetKeyDown(KeyCode.RightShift))
                {

                    if (cont <= rangeFire - 1 && y >= 0)
                    {
                        y--;
                        cont++;
                        selector.transform.position = grid.GetWorldPosition(x, y);
                        Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                    else if (cont >= rangeFire || y < 0)
                    {
                        cont = 0;
                    x = dealerP2.x;
                    y = dealerP2.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
                    CounterA = 0;
                }
                }

            }
        }

        public void Shoot()
        {

            GameObject temp;
            temp = Instantiate(fireBall, transform.forward + new Vector3(dealerP2.transform.position.x, 0.5f, dealerP2.transform.position.z), Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            Debug.Log("sparo palla di fuoco");

        }


    

        //disattivo prewiew attacco/abilità quando finisco turno
        public void DisactivePrewiewDealer()
        {
            if (turn.isTurn == true)
            {
                isAbility = false;
            }
        }

    
}
