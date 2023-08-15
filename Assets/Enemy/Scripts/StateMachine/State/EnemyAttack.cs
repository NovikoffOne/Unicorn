using Spine.Unity;

public class EnemyAttack : State
{
    private SkeletonAnimation _skeletonAimation;

    public EnemyAttack(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        _skeletonAimation = _enemy.SkeletonAnimation;
        _skeletonAimation.AnimationState.SetAnimation(0, _enemy.AngryAnimation, true);
    }
}
