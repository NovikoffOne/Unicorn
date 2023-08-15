using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private string _runAnimationState;
    [SerializeField] private string _shootAnimationState;
    [SerializeField] private string _failShootAnimationState;
    [SerializeField] private string _looseAnimationState;
    [SerializeField] private string _winAnimationState;
    [SerializeField] private string _walkAnimationState;
    [SerializeField] private string _idleAnimationState;

    [SerializeField] private ParticleSystem _particleShootFail;


    private SkeletonAnimation _skeletonAnimation;
    private Spine.AnimationState _animationState;

    private ShootState _currentState;

    private void Awake()
    {
        _skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        _animationState = _skeletonAnimation.AnimationState;
    }

    public void PlayIdle()
    {
        _animationState.SetAnimation(0, _idleAnimationState, false);
    }

    public void PlayRun()
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, _walkAnimationState, false);
        _skeletonAnimation.AnimationState.AddAnimation(0, _runAnimationState, true, 0);
    }

    public void PlayShoot(ShootState state)
    {
        _currentState = state;

        _skeletonAnimation.AnimationState.Event += OnEnemyShooting;

        StartCoroutine(DelayShootEnd(_shootAnimationState));
    }

    public void PlayShootFail()
    {
        _skeletonAnimation.AnimationState.Event += OnFailShooting;

        StartCoroutine(DelayShootEnd(_failShootAnimationState));

    }

    public void PlayWin()
    {
        _skeletonAnimation.AnimationState.AddAnimation(0, _winAnimationState, false, -2f);
    }

    public void PlayLoose()
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, _looseAnimationState, false);
    }

    private IEnumerator DelayShootEnd(string animationName)
    {
        var track = _skeletonAnimation.state.SetAnimation(0, animationName, false);

        yield return new WaitForSpineAnimationComplete(track);

        _player.AllowMove();
    }

    private void OnEnemyShooting(TrackEntry trackEntry, Spine.Event e)
    {
        _currentState.DieEnemy();
    }

    private void OnFailShooting(TrackEntry trackEntry, Spine.Event e)
    {
        Instantiate(_particleShootFail, _player.ParticleShootPosition, Quaternion.identity);
    }
}
