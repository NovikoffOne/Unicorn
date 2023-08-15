using Spine.Unity;

public class EnemyWinState : State
{
    public EnemyWinState(Enemy enemy, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(enemy, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        SkeletonAnimation.AnimationState.SetAnimation(0, Enemy.WinAnimation, true);
    }
}
