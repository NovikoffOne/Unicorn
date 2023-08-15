using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private Movement _mover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Transform _particleFailShootTransform;
    [SerializeField] private ParticleSystem _particleShoot;

    [SerializeField] private float _targetPositionX;
    [SerializeField] private float _speed;

    private AudioSource _audioSource;

    private State _runState;
    private State _shootState;
    private State _failShootState;
    private State _looseState;
    private State _winState;
    private State _idleState;

    private Ray2D _ray;
    
    private bool _canMove = false;

    public bool CanMove => _canMove;

    public float TargetPositionX => _targetPositionX;

    public float Speed => _speed;

    public Movement Movement => _mover;
    public Vector2 ParticleShootPosition => _particleFailShootTransform.position;

    public event Action OnWin;
    public event Action OnLoose;

    public event Action<Enemy> OnEnemyHit;

    private void Awake()
    {
        _runState = new RunState(this, _stateMachine, _playerAnimation);
        _shootState = new ShootState(this, _stateMachine, _playerAnimation);
        _failShootState = new FailShootState(this, _stateMachine, _playerAnimation);
        _looseState = new LooseState(this, _stateMachine, _playerAnimation);
        _winState = new WinState(this, _stateMachine, _playerAnimation);
        _idleState = new IdleState(this, _stateMachine, _playerAnimation);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _ray = new Ray2D();

        _ray.origin = transform.position;

        StartCoroutine(DelayStartMove());
    }

    private void Update()
    {
        if (transform.position.x < _targetPositionX)
        {
            _stateMachine.CurrentState.LogicUpdate();
        }
        else if(transform.position.x >= _targetPositionX)
        {
            _canMove = false;
            OnWin?.Invoke();
            _stateMachine.ChangeState(_winState);
        }    
    }

    public void Loose()
    {
        _canMove = false;
        _stateMachine.ChangeState(_looseState);
        OnLoose?.Invoke();
    }

    public void Shoot(Vector2 targetPosition)
    {
        _canMove = false;

        _audioSource.Play();

        if (Physics2D.OverlapPoint(targetPosition).TryGetComponent<Enemy>(out Enemy enemy))
        {
            _stateMachine.ChangeState(_shootState);
            OnEnemyHit?.Invoke(enemy);
        }
        else
        {
            _stateMachine.ChangeState(_failShootState);
        }
    }

    public void AllowMove()
    {
        _canMove = true;
        
        _stateMachine.ChangeState(_runState);
    }
    
    private IEnumerator DelayStartMove()
    {
        _stateMachine.Initialize(_idleState);

        yield return new WaitForSeconds(1f);

        AllowMove();
    }
}
