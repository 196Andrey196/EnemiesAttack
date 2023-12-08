using UnityEngine;

public class Dizzy : FSMState
{
    public Dizzy(FSM fsm, AnimationSystem animator, PlayerControler playerControler) : base(fsm)
    {
        _fsM = fsm;
        _animator = animator;
        _playerControler = playerControler;
    }
    private FSM _fsM;
    private AnimationSystem _animator;
    private float timer = 0.0f;
    private float _disableDuraton;
    private PlayerControler _playerControler;
    private float _curenHelth;


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
            Debug.Log(_disableDuraton);
            _fsm.SetState<Idle>();
        }
    }
}