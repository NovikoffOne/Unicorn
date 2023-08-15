using Spine.Unity;

public class RunState : State
{
    private Movement _mover;

    public RunState(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation) : base(player, stateMachine, skeletonAnimation) { }

    public override void Enter()
    {
        _mover = Player.Movement;

        SkeletonAnimation.AnimationState.SetAnimation(0, Player.RunAnimationState, false);
        SkeletonAnimation.AnimationState.AddAnimation(0, Player.RunAnimationState, true, -0.5f);
    }

    public override void LogicUpdate()
    {
        _mover.Move(Player.TargetPositionX, Player.Speed);
    }
}
