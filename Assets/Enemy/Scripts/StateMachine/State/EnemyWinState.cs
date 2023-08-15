using Spine.Unity;

public class EnemyWinState : State
{
    private SkeletonAnimation _skeletonAnimation;

    public EnemyWinState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        _skeletonAnimation = _enemy.SkeletonAnimation;
        _skeletonAnimation.AnimationState.SetAnimation(0, _enemy.WinAnimation, true);
    }
}
