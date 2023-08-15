using Spine.Unity;

public abstract class State
{
    protected Player Player;

    protected SkeletonAnimation SkeletonAnimation;

    protected Enemy Enemy;

    protected StateMachine StateMachine;

    public State(Player player, StateMachine stateMachine, SkeletonAnimation skeletonAnimation)
    {
        Player = player;
        StateMachine = stateMachine;
        SkeletonAnimation = skeletonAnimation;

    }

    public State(Enemy enemy, StateMachine stateMachine, SkeletonAnimation skeletonAnimation)
    {
        Enemy = enemy;
        StateMachine = stateMachine;
        SkeletonAnimation = skeletonAnimation;
    }

    public virtual void Enter() { }

    public virtual void LogicUpdate() { }

    public virtual void Exit() { }
}
