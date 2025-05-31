using UnityEngine;

public class StateController : MonoBehaviour
{
    private Animator animator;

    private State state;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        state = new State(this, "Animation bool name");
    }

    private void Start()
    {
        StateMachine.Initialize(state);
    }

    private void Update()
    {
        StateMachine.Update();
    }

    public void PlayAnimation(string animName)
    {
        animator.SetBool(animName, true);
    }

    public void StopAnimation(string animName)
    {
        animator.SetBool(animName, false);
    }
}
