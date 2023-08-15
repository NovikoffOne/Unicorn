using Spine.Unity;

public class EnemyAttack : State
{
    public EnemyAttack(Enemy enemy, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(enemy, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        SkeletonAnimation.AnimationState.SetAnimation(0, Enemy.AngryAnimation, true);
    }
}
