using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class AbilityDealer : MonoBehaviour {

    public int att = 2;
    public PositionUtility utility;
    public BaseGrid grid;
    public KeyCode abilityButton;
    public LifeManager lm;
    public TurnManager turn;
    public PositionTester2 tankP2;
    private PositionHealer2 healerP2;
    public PositionUtility2 utilityP2;
    public PositionDealer2 dealerP2;
    public PositionDealer dealerP1;
    public int x, y;
    public bool isAbility;
    public SelectionController selection;
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
        x = dealerP1.x;
        y = dealerP1.y;
        dealerP1 = FindObjectOfType<PositionDealer>();
        // controllare
        selector.transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
        transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
        selector.SetActive(false);
        selection = Object.FindObjectOfType<SelectionController>().GetComponent<SelectionController>();
        Debug.Log("Selection: " + selection);
        utility = FindObjectOfType<PositionUtility>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        isAbility = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PassTurn());
        if(isAbility == false)
        {
            selector.SetActive(false);
        }
    }

    IEnumerator PassTurn()
    {
        SetAbility();
        SetRange();
        DisactivePrewiewDealer();
        RotationAbility();
        ActiveSelector();
        if (Input.GetKeyDown(KeyCode.R) && isAbility == true)
        {
            Shoot();
            isAbility = false;
            yield return new WaitForSeconds(3f);
            turn.isTurn = false;
        }
       
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

    public void RotationAbility()
    {
        if (isAbility == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.DOLocalRotate(new Vector3(0, 90, 0), 0.2f);
                isAttUp = true;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = false;

                x = dealerP1.x;
                y = dealerP1.y;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.2f);
                isAttUp = false;
                isAttDown = true;
                isAttLeft = false;
                isAttRight = false;

                x = dealerP1.x;
                y = dealerP1.y;


            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.DOLocalRotate(new Vector3(0, 180, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = false;
                isAttRight = true;

                x = dealerP1.x;
                y = dealerP1.y;

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                isAttUp = false;
                isAttDown = false;
                isAttLeft = true;
                isAttRight = false;

                x = dealerP1.x;
                y = dealerP1.y;

            }
        }
    }

    public void SetAbility()
    {
        //abilito abilita
        if (Input.GetKeyDown(abilityButton) && (turn.isTurn == true && isAbility == false && selection.isActiveDealer == true && CounterA == 2))
        {
            isAbility = true;
            selector.SetActive(true);
            selector.transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
            //disabilito input controller per i movimenti(wasd)
            gameObject.GetComponent<InputController>().enabled = false;
        }
        else if (Input.GetKeyDown(abilityButton) && turn.isTurn == true && isAbility == true && selection.isActiveDealer == true && CounterA == 2)
        {
            isAbility = false;
            selector.SetActive(false);
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

            if (isAttUp == true && Input.GetKeyDown(KeyCode.Space))
            {

                if (cont <= rangeFire-1 && x < 11)
                {
                    x++;
                    cont++;
                    selector.transform.position = grid.GetWorldPosition(x , y);
                    Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                else if (cont >= rangeFire || x >= 11)
                {
                    cont = 0;
                    x = dealerP1.x;
                    y = dealerP1.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
                    CounterA = 0;
                }
            }
            else if (isAttDown == true && Input.GetKeyDown(KeyCode.Space))
            {

                if (cont <= rangeFire - 1 && x > 0)
                {
                    x--;
                    cont++;
                    selector.transform.position = grid.GetWorldPosition(x, y);
                    Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                else if (cont >= rangeFire || x <= 0)
                {
                    cont = 0;
                    x = dealerP1.x;
                    y = dealerP1.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
                    CounterA = 0;
                }
            }
            if (isAttLeft == true && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(selector.transform.position.z);
                if (cont <= rangeFire - 1 && y < 11)
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
                    x = dealerP1.x;
                    y = dealerP1.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
                    Debug.Log(dealerP1.y);
                    CounterA = 0;
                }
            }
            else if (isAttRight == true && Input.GetKeyDown(KeyCode.Space))
            {

                if (cont <= rangeFire - 1 && y > 0)
                {
                    y--;
                    cont++;
                    selector.transform.position = grid.GetWorldPosition(x, y);
                    Debug.Log(selector.transform.position);
                    CounterA = 0;
                }
                else if (cont >= rangeFire || y <= 0)
                {
                    cont = 0;
                    x = dealerP1.x;
                    y = dealerP1.y;
                    selector.transform.position = grid.GetWorldPosition(dealerP1.x, dealerP1.y);
                    CounterA = 0;
                }
            }

        }
    }

    public void Shoot()
    {
            GameObject temp;
            temp = Instantiate(fireBall, transform.forward + new Vector3(dealerP1.transform.position.x, 0.5f, dealerP1.transform.position.z), Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            Debug.Log("sparo palla di fuoco");
    }


    //disattivo prewiew attacco/abilità quando finisco turno
    public void DisactivePrewiewDealer()
    {
        if (turn.isTurn == false)
        {
            isAbility = false;
        }
    }

    /*
     * 
     * Ogni tipo di pedina deve essere anche Player
     * 
     * 
    public List<Players> FindPlayersAt(Vector3 position)
    {
        List<Player> foundPlayers = new List<Player>();
        Player[] players = Object.FindObjectsOfType<Players>() as Player[];

        foreach (EnemyManager player in players)
        {
            Player player = player.GetComponent<Player>();

            if (player.transform.position == position)
            {
                foundPlayers.Add(player);
            }
        }
        return foundPlayers;
    }*/




    /*
     *
     * public void DoAbility(){
     *      foreach(Player player in FindPlayersAt(selector.transform.position)){
     *          player.getDamage(5);
     *      }
     *      
     *      for(int i = -4 , i <= 4 , i++){
     *          selector.transform.position.x = i
     *          foreach(Player player in FindPLayersAt(selector.transform.position))
     *              player.getDamage(2);
     *      }
     *      
     *      for(int i = -4 , i <= 4 , i++){
     *          selector.transform.position.y = i
     *          foreach(Player player in FindPLayersAt(selector.transform.position))
     *              player.getDamage(2);
     *      }
     * 
     * }
     * 
     */



}
