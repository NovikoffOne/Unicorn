using UnityEngine;

public class PlayerDetecter : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player enemy))
        {
            _enemy.ChangeAttackState();
        }
    }
}
