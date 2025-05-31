using UnityEngine;

public class State : IState
{
    protected StateController controller;
    protected string animName;

    public State(StateController controller, string animName)
    {
        this.controller = controller;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        controller.PlayAnimation(animName);
    }

    public virtual void Exit()
    {
        controller.StopAnimation(animName);
    }

    public virtual void Update()
    {
        
    }
}
