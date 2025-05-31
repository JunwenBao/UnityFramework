using UnityEngine;

public class State : IState
{
    private StateController controller;
    private string animName;

    public State(StateController controller, string animName)
    {
        this.controller = controller;
        this.animName = animName;
    }

    public void Enter()
    {
        controller.PlayAnimation(animName);
    }

    public void Exit()
    {
        controller.StopAnimation(animName);
    }

    public void Update()
    {

    }
}