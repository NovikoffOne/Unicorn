using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour { }
//{
//    [SerializeField] private Player _player;

//    [SerializeField] private string _runAnimationState;
//    [SerializeField] private string _shootAnimationState;
//    [SerializeField] private string _failShootAnimationState;
//    [SerializeField] private string _looseAnimationState;
//    [SerializeField] private string _winAnimationState;
//    [SerializeField] private string _walkAnimationState;
//    [SerializeField] private string _idleAnimationState;

//    [SerializeField] private ParticleSystem _particleShootFail;


//    private SkeletonAnimation SkeletonAnimation;
//    private Spine.AnimationState _animationState;

//    private ShootState _currentState;

//    private void Awake()
//    {
//        SkeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
//        _animationState = SkeletonAnimation.AnimationState;
//    }

    //public void PlayIdle()
    //{
        
    //}

    //public void PlayShoot(ShootState state)
    //{
    //    _currentState = state;

    //    SkeletonAnimation.AnimationState.Event += OnEnemyShooting;

    //    StartCoroutine(DelayShootEnd(_shootAnimationState));
    //}

    //public void PlayShootFail()
    //{
    //    SkeletonAnimation.AnimationState.Event += OnFailShooting;

    //    StartCoroutine(DelayShootEnd(_failShootAnimationState));

    //}

    //public void PlayWin()
    //{
    //    SkeletonAnimation.AnimationState.AddAnimation(0, _winAnimationState, false, -2f);
    //}

    //public void PlayLoose()
    //{
    //    SkeletonAnimation.AnimationState.SetAnimation(0, _looseAnimationState, false);
    //}

    //private IEnumerator DelayShootEnd(string animationName)
    //{
    //    var track = SkeletonAnimation.state.SetAnimation(0, animationName, false);

    //    yield return new WaitForSpineAnimationComplete(track);

    //    _player.AllowMove();
    //}

    //private void OnEnemyShooting(TrackEntry trackEntry, Spine.Event e)
    //{
    //    _currentState.DieEnemy();
    //}

    //private void OnFailShooting(TrackEntry trackEntry, Spine.Event e)
    //{
    //    Instantiate(_particleShootFail, _player.ParticleShootPosition, Quaternion.identity);
    //}
//}
