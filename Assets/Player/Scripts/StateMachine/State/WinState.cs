using Spine.Unity;

public class WinState : State
{
    public WinState(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(player, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        SkeletonAnimation.AnimationState.AddAnimation(0, Player.WinAnimationState, false, -2f);
    }
}