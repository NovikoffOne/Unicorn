public abstract class State
{
    protected Player _player;
    protected PlayerAnimation _playerAnimation;

    protected Enemy _enemy;

    protected StateMachine _stateMachine;

    public State(Player player, StateMachine stateMachine, PlayerAnimation playerAnimation)
    {
        _player = player;
        _stateMachine = stateMachine;
        _playerAnimation = playerAnimation;
    }

    public State(Enemy enemy, StateMachine stateMachine)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void LogicUpdate() { }

    public virtual void Exit() { }
}
