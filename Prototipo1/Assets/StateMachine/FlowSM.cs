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

   
   

    Animator SMController;

    // Start is called before the first frame update
    void Start()
    {
        SMController = GetComponent<Animator>();
        StateBehaviourBase.Context context = new StateBehaviourBase.Context()
        {
            SetupDone = false,
           
        };
        foreach (StateBehaviourBase state in SMController.GetBehaviours<StateBehaviourBase>())
        {
            state.Setup(context);
        }
    }

  /*  // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            SMController.SetTrigger("Next");

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SMController.SetTrigger("Prev");
    }*/

}