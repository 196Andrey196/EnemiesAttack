using System;
using UnityEngine;

public class Dragon : Enemy
{
    private FSM _fsm;
    private DragonDizzy _dizzy;
    private AnimationSystem _animationSystem;
    private Animator _animator;
    [SerializeField] private GameObject _firebolPrefab;
    public Transform _pointForSpawn;
    private HealthBarManager _helthBarManager;

    void Start()
    {
        _curentHealth = _startHealth;
        _helthBarManager = new HealthBarManager();
        _animator = GetComponent<Animator>();
        _animationSystem = new AnimationSystem(_animator);
        _fsm = new FSM();
        _fsm.AddState(new EnemyMove(_fsm, _animationSystem, this, _targetToMoveOrAttack, _moveSpeed, proximityThresholdToTarget));
        _fsm.AddState(new DragonAttack(_fsm, _animationSystem));
        _dizzy = new DragonDizzy(_fsm, _animationSystem);
        _fsm.AddState(_dizzy);
        _fsm.AddState(new EnemyCharge(_fsm, this.reloadAtack, this));
        _fsm.SetState<EnemyMove>();
    }
    private void Update()
    {
        _fsm.Update();
        if (_curentHealth <= 0) _animationSystem.SetTrigerAnimation("Die");
    }

    public override void Die()
    {
        GameManager.addCountDieEnemy?.Invoke();
        Destroy(gameObject);
    }
    public void TakeDamage(float damageCost)
    {
        if (damageCost != 0)
        {
            _animationSystem.SetTrigerAnimation("Hit");
            _helthBarManager.TakeDamage(ref _curentHealth, damageCost);
        }
    }
    public void SpawnFirebol()
    {
        if (_pointForSpawn != null && _firebolPrefab != null) Instantiate(_firebolPrefab, _pointForSpawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Firebol"))
        {
            _disableDuration = collision.GetComponent<Firebol>().disableDurationCharacter;
            float damageCost = collision.GetComponent<Firebol>().damageCost;
            _helthBarManager.TakeDamage(ref _curentHealth, damageCost);
            if (_curentHealth > 0)
            {

                _dizzy.SetDuration(_disableDuration);
                _fsm.SetState<DragonDizzy>();
            }
        }
    }

}
