using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public FlowSM stateMachine;
    public LifeManager lifeMngr;
    public TurnManager turnMng;
    public HudManagerTest hudMng;
    public MainMenùController mc;
    public ActionMenuController acm;
    public UiManager uiMng;
    public SelectionController sc;
    public SelectControllerP2 sc2;//NO
    /// <summary>
    /// dichiarazione delegati
    /// </summary>
    public delegate void MenuActions();
    public MenuActions MainMenu;
    public delegate void InitAction();
    public InitAction InitSM;
    public Player _player;
    public HudUnitsManager hudUnitsMng;



    #region Getter
    public UiManager GetUiManager()
    {
        if (uiMng == null)
        {
            Debug.LogWarning("testa di C, ti sei dimenticato il Manager" + uiMng.name);
            uiMng = FindObjectOfType<UiManager>();
        }
        return uiMng;
    }

    public LifeManager GetLifeManager()
    {
        if (uiMng == null)
        {
            Debug.LogWarning("testa di C, ti sei dimenticato il Manager" + lifeMngr.name);
            lifeMngr = FindObjectOfType<LifeManager>();
        }
        return lifeMngr;
    }

    public TurnManager GetTurnManager()
    {
        if (turnMng == null)
        {
            Debug.LogWarning("testa di C, ti sei dimenticato il Manager" + turnMng.name);
            turnMng = FindObjectOfType<TurnManager>();
        }
        return turnMng;
    }

    public HudUnitsManager GetHudUnitsManager()
    {
        if (hudUnitsMng == null)
        {
            Debug.LogWarning("testa di C, ti sei dimenticato il Manager" + hudUnitsMng.name);
            hudUnitsMng = FindObjectOfType<HudUnitsManager>();
        }
        return hudUnitsMng;
    }

    public HudManagerTest GetHudManagerTest()
    {
        if (hudMng == null)
        {
            Debug.LogWarning("testa di C, ti sei dimenticato il Manager" + hudUnitsMng.name);
            hudMng = FindObjectOfType<HudManagerTest>();
        }
        return hudMng;
    }
    #endregion
    public void Setup()
    {
        GetUiManager();
        //GetHudUnitsManager();
        //GetHudManagerTest();
        //GetTurnManager();
        //GetLifeManager();
    }

    // Use this for initialization
    void Awake()
    {
        SingletonFunction();
    }

    /// <summary>
    /// iscrizione agli eventi
    /// </summary>
    private void OnEnable()
    {
        singleton.MainMenu += SetupMainMenu;
    }

    /// <summary>
    /// disiscrizione agli eventi
    /// </summary>
    private void OnDisable()
    {

        singleton.MainMenu -= SetupMainMenu;


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
        if (MainMenu != null)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger("GoToMainMenu");
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
    public void SetupController()
    {
        mc = FindObjectOfType<MainMenùController>();
        acm = FindObjectOfType<ActionMenuController>();
        sc = FindObjectOfType<SelectionController>();
        stateMachine = FindObjectOfType<FlowSM>();
        _player = FindObjectOfType<Player>();
        sc2 = FindObjectOfType<SelectControllerP2>();
    }
}