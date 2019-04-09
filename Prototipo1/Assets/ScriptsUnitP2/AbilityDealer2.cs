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
    public int MaxCounterA = 2;
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
        selector.SetActive(false);
        selectionP2 = Object.FindObjectOfType<SelectControllerP2>().GetComponent<SelectControllerP2>();
       
        dealerP2 = FindObjectOfType<PositionDealer2>();
       
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
        CounterA = 2;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PassTurn());
    }

    public void ChargeAbility()
    {
        if (CounterA == 0 && turn.isTurn == false)
        {
            CounterA++;
        }
        else if (CounterA == 2)
        {
            CounterA = MaxCounterA;
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
        if (Input.GetKeyDown(KeyCode.Keypad5) && isAbility == true)
        {
            Shoot();
            isAbility = false;
            yield return new WaitForSeconds(3f);
            turn.isTurn = true;
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

                    x = dealerP2.x;
                    y = dealerP2.y;


                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                    isAttUp = false;
                    isAttDown = true;
                    isAttLeft = false;
                    isAttRight = false;

                    x = dealerP2.x;
                    y = dealerP2.y;


                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                    isAttUp = false;
                    isAttDown = false;
                    isAttLeft = false;
                    isAttRight = true;

                    x = dealerP2.x;
                    y = dealerP2.y;

                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
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
            if (Input.GetKeyDown(abilityButton) && turn.isTurn == false && isAbility == false && selectionP2.isActiveDealerP2 == true && CounterA == 2)
            {
                isAbility = true;
            selector.SetActive(true);
            selector.transform.position = grid.GetWorldPosition(dealerP2.x, dealerP2.y);
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;
            }
            else if (Input.GetKeyDown(abilityButton) && turn.isTurn == false && isAbility == true && selectionP2.isActiveDealerP2 == true && CounterA == 2)
            {
                isAbility = false;
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
                if (isAttUp == true && Input.GetKeyDown(KeyCode.Keypad4))
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
                else if (isAttDown == true && Input.GetKeyDown(KeyCode.Keypad4))
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
                if (isAttLeft == true && Input.GetKeyDown(KeyCode.Keypad4))
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
                else if (isAttRight == true && Input.GetKeyDown(KeyCode.Keypad4))
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
