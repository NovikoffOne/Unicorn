using Spine.Unity;

public class EnemyRunState : State
{
    private Movement _mover;

    public EnemyRunState(Enemy enemy, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(enemy, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        _mover = Enemy.Mover;

        SkeletonAnimation.AnimationState.SetAnimation(0, Enemy.RunAnimation, true);
    }

    public override void LogicUpdate()
    {
        if (Enemy.TargetPositionX < Enemy.transform.position.x)
            _mover.Move(Enemy.TargetPositionX, Enemy.Speed);
        else
            Enemy.Die();
    }
}
