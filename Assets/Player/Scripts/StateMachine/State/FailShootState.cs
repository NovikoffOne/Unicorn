using Spine;
using Spine.Unity;

public class FailShootState : State
{
    public FailShootState(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(player, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        SkeletonAnimation.AnimationState.Event += OnFailShooting;

        Player.StartDelayShootEnd(Player.FailShootAnimationState);
    }

    public override void Exit()
    {
        SkeletonAnimation.AnimationState.Event -= OnFailShooting;
    }

    private void OnFailShooting(TrackEntry trackEntry, Spine.Event e)
    {
        Player.SpawnShootParticle();
    }
}
