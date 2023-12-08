using UnityEngine;

public class DragonAttack : FSMState
{
    public DragonAttack(FSM fsm, AnimationSystem animator) : base(fsm)
    {
        _fsM = fsm;
        _animator = animator;

    }
    private FSM _fsM;
    private AnimationSystem _animator;
    public override void Enter()
    {
        _animator.SetTrigerAnimation("Attack");
    }

    public override void Update()
    {
        _fsM.SetState<EnemyCharge>();
    }
}
