
using UnityEngine;


public class EnemyMove : FSMState
{
    public EnemyMove(FSM fsm, AnimationSystem animator, Enemy chaaracter, Transform targetToMove, float moveSpeed, float proximityThresholdToTarget) : base(fsm)
    {
        _fsM = fsm;
        _animator = animator;
        _targetToMove = targetToMove;
        _moveSpeed = moveSpeed;
        _chaaracter = chaaracter;
        _proximityThresholdToTarget = proximityThresholdToTarget;
    }
    private FSM _fsM;
    private Transform _targetToMove;
    private Enemy _chaaracter;
    private float _moveSpeed;
    private AnimationSystem _animator;
    private float _proximityThresholdToTarget;
    public override void Enter()
    {
        _animator.SetboolAnimation("Move", true);
    }

    public override void Exit()
    {
        _animator.SetboolAnimation("Move", false);
    }

    public override void Update()
    {

        if (_targetToMove != null)
        {
            _chaaracter.transform.position = Vector2.MoveTowards(_chaaracter.transform.position, _targetToMove.position, _moveSpeed * Time.deltaTime);
        }
        Vector3 directionToTarget = _targetToMove.position - _chaaracter.transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget <= _proximityThresholdToTarget)
        {
            if (_chaaracter.GetType() == typeof(Dragon)) _fsM.SetState<DragonAttack>();
            if (_chaaracter.GetType() == typeof(Ninja)) _fsM.SetState<EnemyAttack>();
        }



    }
}
