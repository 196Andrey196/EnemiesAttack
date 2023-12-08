using UnityEngine;

public class Ninja : Enemy
{
    private FSM _fsm;
    private AnimationSystem _animationSystem;
    private Animator _animator;
    private HealthBarManager _helthBarManager;
    [SerializeField] private float _attackStrengh;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayers;

    void Start()
    {
        _curentHealth = _startHealth;
        _helthBarManager = new HealthBarManager();
        _animator = GetComponent<Animator>();
        _animationSystem = new AnimationSystem(_animator);
        _fsm = new FSM();
        _fsm.AddState(new EnemyMove(_fsm, _animationSystem, this, _targetToMoveOrAttack, _moveSpeed, proximityThresholdToTarget));
        _fsm.AddState(new EnemyAttack(_fsm, _animationSystem, _attackPoint, _attackRange, _enemyLayers, _attackStrengh));
        _fsm.AddState(new EnemyCharge(_fsm, this.reloadAtack, this));
        _fsm.SetState<EnemyMove>();
    }
    private void Update()
    {
        _fsm.Update();
        if (_curentHealth <= 0) Die();
    }
    public void TakeDamage(float damageCost)
    {
        if (damageCost != 0)
        {
            _animationSystem.SetTrigerAnimation("Hit");
            _helthBarManager.TakeDamage(ref _curentHealth, damageCost);
        }
    }

    public override void Die()
    {
        GameManager.addCountDieEnemy?.Invoke();
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        if (_attackPoint == null) return;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
