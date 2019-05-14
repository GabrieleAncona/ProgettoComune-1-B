using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class GameManager : MonoBehaviour {
    public static GameManager singleton;
    public LifeManager lm;
    public TurnManager tm;
    public HudManagerTest ui;
    public MainMenùController mc;
    public ActionMenuController acm;
    public SelectionController sc;

    /// <summary>
    /// dichiarazione delegati
    /// </summary>
    public delegate void MenuActions();
    public MenuActions MainMenu;
    public delegate void InitAction();
    public InitAction InitSM;

    public Animator SMController;

    // Use this for initialization
    void Start ()
    {

        SingletonFunction();

        SMController = GetComponent<Animator>();
        StateBehaviourBase.Context contextPlayer1 = new StateBehaviourBase.Context()
        {
            //SetupDone = false,

        };
        StateBehaviourBase.Context contextPlayer2 = new StateBehaviourBase.Context()
        {
            //SetupDone = false,

        };
        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {
           //state.Setup(contextPlayer1);
        }
        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {
            //state.Setup(contextPlayer2);
        }

       /// GoToMainMenu();
    }
	
	// Update is called once per frame
	void Update () {
		
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
        if(singleton == this)
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
        if (mc.menuIsActive == true)
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

    public void SetupActionMenu()
    {

        if(sc.isActiveTank == true || sc.isActiveHealer == true || sc.isActiveUtility == true || sc.isActiveDealer == true)
        {
            acm.isActionMenu = true;
        }

    }

    /// <summary>
    /// funzione che mi iscrive a tutti gli eventi
    /// </summary>
    public static void Setup()
    {

    }
}
