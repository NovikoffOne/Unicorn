using UnityEngine;

public class PlayerLooseZone : MonoBehaviour
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemy.ChangeWinState();
            player.Loose();
        }
        else
        {
            return;
        }
    }
}
