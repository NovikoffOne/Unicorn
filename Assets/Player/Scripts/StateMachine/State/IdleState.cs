using Spine.Unity;

public class IdleState : State
{
    private Spine.AnimationState _animationState;

    public IdleState(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(player, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        _animationState = SkeletonAnimation.AnimationState;

        _animationState.SetAnimation(0, Player.IdleAnimationState, false);
    }
}
