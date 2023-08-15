using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private Movement _mover;

    public RunState(Player player, StateMachine stateMachine, PlayerAnimation playerAnimation) : base(player, stateMachine, playerAnimation){ }

    public override void Enter()
    {
        _mover = _player.Movement;

        _playerAnimation.PlayRun();
    }

    public override void LogicUpdate()
    {
        _mover.Move(_player.TargetPositionX, _player.Speed);
    }
}
