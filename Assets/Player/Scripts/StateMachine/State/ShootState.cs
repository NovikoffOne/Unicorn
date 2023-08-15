using Spine;
using Spine.Unity;

public class ShootState : State
{
    public ShootState(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(player, stateMachine, skeletonAnimation)
    {
        Player.OnEnemyHit += OnEnemyHiting;
    }

    public override void Enter()
    {
        SkeletonAnimation.AnimationState.Event += OnEnemyShooting;

        Player.StartDelayShootEnd(Player.ShootAnimationState);
    }

    public override void Exit()
    {
        SkeletonAnimation.AnimationState.Event -= OnEnemyShooting;
    }

    private void OnEnemyHiting(Enemy enemy)
    {
        Enemy = enemy;
    }

    private void OnEnemyShooting(TrackEntry trackEntry, Spine.Event e)
    {
        Player.SpawnShootParticle();

        if (Enemy != null)
            Enemy.Die();
    }
}
