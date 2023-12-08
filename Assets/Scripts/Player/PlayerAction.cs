using System;
using UnityEngine;

public class PlayerAction : CharacterInfo
{
    private PlayerControler _playerControler;
    private AnimationSystem _animationSystem;
    private Animator _animator;
    private FSM _fsm;
    private Dizzy _dizzy;
    private HealthBarManager _helthBarManager;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private GameObject _pointForBlock;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private float _attackStrengh;
    public static Action<string> crossfadeAnimation;
    private void OnEnable()
    {
        _playerControler?.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControler?.Player.Disable();
    }

    void Awake()
    {

        _curentHealth = _startHealth;
        _helthBarManager = new HealthBarManager();
        _animator = GetComponent<Animator>();
        _animationSystem = new AnimationSystem(_animator);
        _playerControler = new PlayerControler();
        _fsm = new FSM();
        _dizzy = new Dizzy(_fsm, _animationSystem, _playerControler);
        _fsm.AddState(new Idle(_fsm, transform, _playerControler));
        _fsm.AddState(new Attack(_fsm, _playerControler, _animationSystem, _attackPoint, _attackRange, _enemyLayers, _attackStrengh));
        _fsm.AddState(new Block(_fsm, _playerControler, _animationSystem, _pointForBlock));
        _fsm.AddState(_dizzy);
        _fsm.SetState<Idle>();
    }
    private void Update()
    {
        if (_animationSystem.CheckOverAnimation("Hit"))
        {
            _playerControler.Player.Enable();
        }
        _fsm.Update();
        if (_curentHealth <= 0) Die();
    }
    public override void Die()
    {
        GameManager.gameOver?.Invoke();
        _playerControler.Player.Disable();
        Destroy(gameObject);
    }
    public void TakeDamage(float damageCost)
    {

        if (damageCost != 0)
        {
            _playerControler.Player.Disable();
            _animationSystem.SetTrigerAnimation("Hit");
            _helthBarManager.TakeDamage(ref _curentHealth, damageCost);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Firebol"))
        {
            _disableDuration = collision.GetComponent<Firebol>().disableDurationCharacter;
            float damageCost = collision.GetComponent<Firebol>().damageCost;
            _helthBarManager.TakeDamage(ref _curentHealth, damageCost);
            _dizzy.SetDuration(_disableDuration);
            _fsm.SetState<Dizzy>();
        }
    }
    private void OnDrawGizmos()
    {
        if (_attackPoint == null) return;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}