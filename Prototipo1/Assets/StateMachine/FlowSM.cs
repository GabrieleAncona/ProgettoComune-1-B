using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
/// <summary>
/// State machine del Flow.
/// Decide quando cambiare gli stati.
/// </summary>
public class FlowSM : MonoBehaviour
{
    public Animator SMController;
    public Player _currentPlayer;


    // Use this for initialization
    void Start()
    {

        SetupPlayer();

        SMController = GetComponent<Animator>();
        StateBehaviourBase.Context context = new StateBehaviourBase.Context()
        {

            SetupDone = false,

        };
        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {
            ///eseguo setup iniziale
            state.Setup(context);
        }

    }

    // Update is called once per frame
    void Update()
    {
        ChangeContext();
    }

    public void SetupPlayer()
    {
        _currentPlayer = FindObjectOfType<Player>();
    }

    ///funzione per cambiare contenuto context
    public void ChangeContext()
    {
        StateBehaviourBase.Context context = new StateBehaviourBase.Context()
        {

            SetupDone = false,

            currentPlayer = this._currentPlayer,

        };

        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {

            state.Setup(context);
            Debug.Log("context" + _currentPlayer.IdPlayer);

        }

    }
}
