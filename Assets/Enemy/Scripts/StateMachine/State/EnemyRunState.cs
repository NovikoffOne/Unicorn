using Spine.Unity;

public class EnemyRunState : State
{
    private Movement _mover;
    private SkeletonAnimation _skeletonAimation;

    public EnemyRunState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        _mover = _enemy.Mover;

        _skeletonAimation = _enemy.SkeletonAnimation;
        _skeletonAimation.AnimationState.SetAnimation(0, _enemy.RunAnimation, true);
    }

    public override void LogicUpdate()
    {
        if (_enemy.TargetPositionX < _enemy.transform.position.x)
            _mover.Move(_enemy.TargetPositionX, _enemy.Speed);
        else
            _enemy.Die();
    }
}
