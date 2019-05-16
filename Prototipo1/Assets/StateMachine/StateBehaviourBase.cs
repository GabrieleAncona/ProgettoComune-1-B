using System;
using UnityEngine;
using UnityEngine.Animations;

public class StateBehaviourBase : StateMachineBehaviour
{

    public class Context
    {
        public bool SetupDone;
        public Player currentPlayer;

    }

    protected Context ctx;

    public void Setup(Context _ctx)
    {
        ctx = _ctx;
    }


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEnter();
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        OnEnter();
    }
    public virtual void OnEnter() { }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnUpdate();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        OnUpdate();
    }
    public virtual void OnUpdate() { }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnExit();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        OnExit();
    }
    public virtual void OnExit() { }

}