using Spine.Unity;

public class LooseState : State
{
    public LooseState(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(player, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        SkeletonAnimation.AnimationState.SetAnimation(0, Player.LooseAnimationState, false);
    }
}