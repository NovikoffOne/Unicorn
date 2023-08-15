public class LooseState : State
{
    public LooseState(Player player, StateMachine stateMachine, PlayerAnimation playerAnimation) : base(player, stateMachine, playerAnimation)
    {
    }

    public override void Enter()
    {
        _playerAnimation.PlayLoose();
    }
}