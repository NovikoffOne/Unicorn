using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _pool;
    [SerializeField] private Player _player;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;

    [SerializeField] private float _maxPositionX = 45;
    [SerializeField] private float _offsetX = 22f;

    [SerializeField] private float _delay;

    private WaitForSeconds _waitForSpawn;

    private bool _canSpawn = true;

    private float RandomEnemySpeed => Random.Range(-_maxSpeed, -_minSpeed);
    private float RandomPositionX => Random.Range(_player.transform.position.x, _maxPositionX);
    private Vector3 _spawnPosition => new Vector3(RandomPositionX + _offsetX, transform.position.y, transform.position.z);

    private void Start()
    {
        _waitForSpawn = new WaitForSeconds(_delay);

        StartCoroutine(Spawn());
    }

    private void OnEnable()
    {
        _player.OnLoose += OnSpawnStopit;
        _player.OnWin += OnSpawnStopit;
    }

    private void OnDisable()
    {
        _player.OnLoose -= OnSpawnStopit;
        _player.OnWin -= OnSpawnStopit;
    }

    private IEnumerator Spawn()
    {
        while (_canSpawn)
        {
            CreateEnemy();

            yield return _waitForSpawn;
        }
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, _pool.position, Quaternion.identity, _pool);

        enemy.Init(_player.transform.position.x, RandomEnemySpeed, _player, _spawnPosition);

        enemy.transform.parent = transform;

        enemy.gameObject.SetActive(true);
    }

    private void OnSpawnStopit()
    {
        _canSpawn = false;
    }
}