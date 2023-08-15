using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }

    public virtual void Initialize(State statrState)
    {
        CurrentState = statrState;
        statrState.Enter();
    }

    public virtual void ChangeState(State newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }
}
