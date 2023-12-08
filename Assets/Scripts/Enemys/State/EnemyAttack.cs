using UnityEngine;

public class EnemyAttack : FSMState
{
    public EnemyAttack(FSM fsm, AnimationSystem animator, Transform attackPoint, float attackRange, LayerMask enemyLayers, float attackStrengh) : base(fsm)
    {
        _fsM = fsm;
        _animator = animator;
        _attackPoint = attackPoint;
        _attackRange = attackRange;
        _enemyLayers = enemyLayers;
        _attackStrengh = attackStrengh;

    }
    private FSM _fsM;
    private AnimationSystem _animator;
    private Transform _attackPoint;
    private float _attackRange;
    private LayerMask _enemyLayers;
    private float _attackStrengh;
    public override void Enter()
    {
        _animator.SetTrigerAnimation("Attack");
    }

    public override void Update()
    {
        if (_animator.CheckOverAnimation("Attack"))
        {
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
            foreach (var enemy in hitEnemys)
            {
                if (enemy.GetComponent<PlayerAction>())
                {
                    PlayerAction player = enemy.GetComponent<PlayerAction>();
                    player.TakeDamage(_attackStrengh);
                }
            }
            _fsM.SetState<EnemyCharge>();
        }
    }
}
