using UnityEngine;

public class DragonDizzy : FSMState
{
    public DragonDizzy(FSM fsm, AnimationSystem animator) : base(fsm)
    {
        _fsM = fsm;
        _animator = animator;
    }
    private FSM _fsM;
    private AnimationSystem _animator;
    private float timer = 0.0f;
    private float _disableDuraton;


    public void SetDuration(float duration)
    {
        _disableDuraton = duration;
    }
    public override void Enter()
    {
        timer = 0.0f;
        _animator.SetboolAnimation("Dizzy", true);
    }
    public override void Exit()
    {
        _animator.SetboolAnimation("Dizzy", false);
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _disableDuraton)
        {
            _fsm.SetState<DragonAttack>();
        }
    }
}