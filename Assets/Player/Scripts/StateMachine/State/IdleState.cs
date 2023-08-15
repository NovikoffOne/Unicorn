using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player player, StateMachine stateMachine, PlayerAnimation playerAnimation) : base(player, stateMachine, playerAnimation)
    {
    }

    public override void Enter()
    {
        _playerAnimation.PlayIdle();
    }
}
