using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
/// <summary>
/// State machine del Flow.
/// </summary>
public class FlowSM : MonoBehaviour
{
    public Animator SMController;
  


    // Use this for initialization
    void Start()
    {

       

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



    ///funzione per cambiare contenuto context
    public void ChangeContext()
    {
        StateBehaviourBase.Context context = new StateBehaviourBase.Context()
        {

            SetupDone = false,
            currentPlayer = GameManager.singleton._player,
           
        };

        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {
            state.Setup(context);
        }

    }
}
