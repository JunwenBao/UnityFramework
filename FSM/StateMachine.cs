using UnityEngine;

public class StateMachine
{
    public static State currentState;

    public static void Initialize(State startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public static void ChangeState(State newState)
    {
        if (currentState != null) currentState.Exit();

        currentState = newState;

        if (currentState != null) currentState.Enter();
    }

    public static void Update()
    {
        if (currentState != null) currentState.Update();
    }
}
