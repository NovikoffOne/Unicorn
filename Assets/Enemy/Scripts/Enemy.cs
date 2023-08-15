using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Movement _mover;
    [SerializeField] private Transform _pariticlePosition;

    [SerializeField] private ParticleSystem _dieParticle;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _targetPositionX;

    #region State
    private State _runState;
    private State _attackState;
    private State _winState;
    #endregion

    #region AnimationName
    public string RunAnimation = "run";
    public string AngryAnimation = "angry";
    public string WinAnimation = "win";
    #endregion

    private Player _player;

    private SkeletonAnimation _skeletonAimation;

    private EnemyStateMachine _stateMachine;

    public Movement Mover => _mover;
    public float TargetPositionX => _targetPositionX;
    public float Speed => _speed;


    public event Action OnDie;

    private void Awake()
    {
        _skeletonAimation = GetComponentInChildren<SkeletonAnimation>();

        _stateMachine = GetComponent<EnemyStateMachine>();

        _runState = new EnemyRunState(this, _stateMachine, _skeletonAimation);
        _attackState = new EnemyAttack(this, _stateMachine, _skeletonAimation);
        _winState = new EnemyWinState(this, _stateMachine, _skeletonAimation);
    }

    private void Start()
    {
        _stateMachine.Initialize(_runState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void OnEnable()
    {
        _player.OnWin += OnPlayerWin;
        _player.OnLoose += OnPlayerLoose;
    }

    private void OnDisable()
    {
        _player.OnWin -= OnPlayerWin;
        _player.OnLoose -= OnPlayerLoose;
    }

    public void Init(float targetX, float speed, Player player, Vector3 startPosition)
    {
        _targetPositionX = targetX;

        _player = player;

        _speed = speed;

        transform.position = startPosition;
    }

    public void ChangeAttackState()
    {
        _stateMachine.ChangeState(_attackState);
    }
    public void ChangeWinState()
    {
        _stateMachine.ChangeState(_winState);
    }

    public void Die()
    {
        Instantiate(_dieParticle, _pariticlePosition.position, Quaternion.identity);

        OnDie?.Invoke();

        Destroy(gameObject);
    }

    public void OnPlayerLoose()
    {
        ChangeWinState();
    }

    public void OnPlayerWin()
    {
        Die();
    }
}
