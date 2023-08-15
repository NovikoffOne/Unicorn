public class WinState : State
{
    private Player player;
    private StateMachine stateMachine;
    private PlayerAnimation playerAnimation;

    public WinState(Player player, StateMachine stateMachine, PlayerAnimation playerAnimation) : base(player, stateMachine, playerAnimation)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerAnimation = playerAnimation;
    }

    public override void Enter()
    {
        _playerAnimation.PlayWin();
    }
}