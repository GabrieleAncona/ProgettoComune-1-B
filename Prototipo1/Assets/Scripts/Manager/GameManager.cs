﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public FlowSM stateMachine;
    public LifeManager lm;
    public TurnManager tm;
    public HudManagerTest hud;
    public MainMenùController mc;
    public ActionMenuController acm;
    public SelectionController sc;
    public SelectControllerP2 sc2;
    /// <summary>
    /// dichiarazione delegati
    /// </summary>
    public delegate void MenuActions();
    public MenuActions MainMenu;
    public delegate void InitAction();
    public InitAction InitSM;
    public Player _player;
    public GameObject hudUnit;
    public GameObject hudUnit2;
    public ButtonNavigation buttNav;
    public VfxManager vfx;
    public GameObject animDragon;
    public GameObject musicMenu;
    public GameObject musicGame;

    //StateBehaviourBase.Context contextPlayer2 = new StateBehaviourBase.Context();


    // Use this for initialization
    void Awake()
    {

        SingletonFunction();
        SetupManager();
    }

    // Update is called once per frame
    void Update()
    {



    }

    /// <summary>
    /// iscrizione agli eventi
    /// </summary>
    private void OnEnable()
    {
        if (singleton == this)
        {
            singleton.MainMenu += SetupMainMenu;
            singleton.InitSM += SetupInit;
        }
    }

    /// <summary>
    /// disiscrizione agli eventi
    /// </summary>
    private void OnDisable()
    {
        if (singleton == this)
        {
            singleton.MainMenu -= SetupMainMenu;
            singleton.InitSM -= SetupInit;
        }
    }

    /// <summary>
    /// funzione pattern singleton
    /// </summary>
    public void SingletonFunction()
    {
        //Check if instance already exists
        if (singleton == null)

            //if not, set instance to this
            singleton = this;

        //If instance already exists and it's not this:
        else if (singleton != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    public void SetupMainMenu()
    {
        if (mc.menuIsActive == false)
        {
            mc.SetupMainMenu();
            //SMController.SetTrigger("GoToMainMenu");
            Debug.Log("funziona");
        }

    }

    public void SetupInit()
    {
        if (mc.menuIsActive == true)
        {
            mc.SetupInitCanvas();
            Debug.Log("inizializazione");
            Debug.Log("funziona");
        }
    }

    /*public void GoToMainMenu()
    {
        SMController.SetTrigger("GoToMainMenu");
    }
    public void GoToInit()
    {
        SMController.SetTrigger("GoToInit");
    }*/



    /// <summary>
    /// funzione che mi iscrive a tutti gli eventi
    /// </summary>
    public void SetupManager()
    {
        vfx = FindObjectOfType<VfxManager>();
        lm = GetComponent<LifeManager>();
        lm = FindObjectOfType<LifeManager>();
        tm = FindObjectOfType<TurnManager>();
        hud = FindObjectOfType<HudManagerTest>();
        mc = FindObjectOfType<MainMenùController>();
        acm = FindObjectOfType<ActionMenuController>();
        sc = FindObjectOfType<SelectionController>();
        stateMachine = FindObjectOfType<FlowSM>();
        _player = FindObjectOfType<Player>();
        sc2 = FindObjectOfType<SelectControllerP2>();
        buttNav = FindObjectOfType<ButtonNavigation>();

        musicGame = GameObject.FindGameObjectWithTag("MusicBattle");
        musicMenu = GameObject.FindGameObjectWithTag("MusicGame");
        animDragon = GameObject.FindGameObjectWithTag("Dragon");
        hudUnit = GameObject.FindGameObjectWithTag("HUDUnit1");
        hudUnit2 = GameObject.FindGameObjectWithTag("HUDUnit2");
    }
}