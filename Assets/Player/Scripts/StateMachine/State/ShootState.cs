public class ShootState : State
{
    public ShootState(Player player, StateMachine stateMachine, PlayerAnimation playerAnimation) : base(player, stateMachine, playerAnimation)
    {
        _player.OnEnemyHit += OnEnemyHiting;
    }

    public override void Enter()
    {
        _playerAnimation.PlayShoot(this);
    }

    public void DieEnemy()
    {
        if (_enemy != null)
            _enemy.Die();

    }

    private void OnEnemyHiting(Enemy enemy)
    {
        _enemy = enemy;
    }
}
