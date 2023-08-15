using Spine.Unity;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private Movement _mover;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Transform _particleFailShootTransform;
    [SerializeField] private ParticleSystem _particleShoot;

    [SerializeField] private float _targetPositionX;
    [SerializeField] private float _speed;
    [SerializeField] private float _delayStartRun = 1f;

    #region AnimationName
    public string RunAnimationState { get; private set; } = "run";
    public string ShootAnimationState { get; private set; } = "shoot";
    public string FailShootAnimationState { get; private set; } = "shoot_fail";
    public string LooseAnimationState { get; private set; } = "loose";
    public string WinAnimationState { get; private set; } = "idle";
    public string WalkAnimationState { get; private set; } = "walk";
    public string IdleAnimationState { get; private set; } = "idle";
    #endregion

    #region State
    private State _runState;
    private State _shootState;
    private State _failShootState;
    private State _looseState;
    private State _winState;
    private State _idleState;
    #endregion

    private SkeletonAnimation _skeletonAnimation;

    private AudioSource _audioSource;

    private Ray2D _ray;

    private bool _canMove = false;

    public bool CanMove => _canMove;
    public float Speed => _speed;
    public float TargetPositionX => _targetPositionX;

    public Movement Movement => _mover;
    public Vector2 ParticleShootPosition => _particleFailShootTransform.position;

    public event Action OnWin;
    public event Action OnLoose;
    public event Action<Enemy> OnEnemyHit;

    private void Awake()
    {
        _skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();

        _runState = new RunState(this, _stateMachine, _skeletonAnimation);
        _shootState = new ShootState(this, _stateMachine, _skeletonAnimation);
        _failShootState = new FailShootState(this, _stateMachine, _skeletonAnimation);
        _looseState = new LooseState(this, _stateMachine, _skeletonAnimation);
        _winState = new WinState(this, _stateMachine, _skeletonAnimation);
        _idleState = new IdleState(this, _stateMachine, _skeletonAnimation);
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
        else if (transform.position.x >= _targetPositionX)
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

    public void SpawnShootParticle()
    {
        Instantiate(_particleShoot, ParticleShootPosition, Quaternion.identity, transform.parent);
    }

    private IEnumerator DelayStartMove()
    {
        _stateMachine.Initialize(_idleState);

        yield return new WaitForSeconds(_delayStartRun);

        AllowMove();
    }


    public void StartDelayShootEnd(string AnimationName)
    {
        StartCoroutine(DelayShootEnd(AnimationName));
    }

    private IEnumerator DelayShootEnd(string animationName)
    {
        var track = _skeletonAnimation.state.SetAnimation(0, animationName, false);

        yield return new WaitForSpineAnimationComplete(track);

        AllowMove();
    }
}
