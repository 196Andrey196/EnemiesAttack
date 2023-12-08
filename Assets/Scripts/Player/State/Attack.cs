using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Attack : FSMState
{
    public Attack(FSM fsm, PlayerControler playerControler, AnimationSystem animator, Transform attackPoint, float attackRange, LayerMask enemyLayers, float attackStrengh) : base(fsm)
    {
        _fsM = fsm;
        _playerControler = playerControler;
        _animator = animator;
        _AttackAction = _playerControler.Player.Attack;
        _attackPoint = attackPoint;
        _attackRange = attackRange;
        _enemyLayers = enemyLayers;
        _attackStrengh = attackStrengh;

    }
    private FSM _fsM;
    private PlayerControler _playerControler;
    private AnimationSystem _animator;
    private InputAction _AttackAction;
    private Transform _attackPoint;
    private float _attackRange;
    private LayerMask _enemyLayers;
    private float _attackStrengh;

    public override void Enter()
    {
        _AttackAction.started += OnAttack;

        _AttackAction.canceled += OffAttack;
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        foreach (var enemy in hitEnemys)
        {
            if (enemy.GetComponent<Ninja>())
            {
                Ninja ninja = enemy.GetComponent<Ninja>();
                ninja.TakeDamage(_attackStrengh);
            }
            else if (enemy.GetComponent<Dragon>())
            {
                Dragon dragon = enemy.GetComponent<Dragon>();
                dragon.TakeDamage(_attackStrengh);
            }
        }

        _AttackAction.Enable();
    }


    public override void Exit()
    {
        _AttackAction.performed -= OnAttack;

        _AttackAction.canceled -= OffAttack;
        _AttackAction.Disable();
        _animator.SetboolAnimation("Attack", false);

    }


    private void OnAttack(InputAction.CallbackContext context)
    {
        _animator.SetboolAnimation("Attack", true);
    }

    private void OffAttack(InputAction.CallbackContext context)
    {
        _fsM.SetState<Idle>();
    }

}
