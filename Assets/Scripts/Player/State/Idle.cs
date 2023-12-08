using UnityEngine;
using UnityEngine.InputSystem;

public class Idle : FSMState
{
    public Idle(FSM fsm, Transform transform, PlayerControler playerControler) : base(fsm)
    {
        _fsM = fsm;
        _playerControler = playerControler;
        _transform = transform;
    }
    private FSM _fsM;
    private PlayerControler _playerControler;
    private InputAction _direction;
    private Vector2 _playerLookDirection;
    private Transform _transform;

    public override void Enter()
    {
        _direction = _playerControler.Player.Turn;

        _direction.performed += OnMovePerformed;
        _direction.Enable();

        _playerControler.Player.Attack.started += OnAttackStarted;
        _playerControler.Player.Block.started += OnBlockStarted;
        _playerControler.Player.Attack.Enable();
        _playerControler.Player.Block.Enable();
    }
    public override void Exit()
    {

        _direction.performed -= OnMovePerformed;
        _direction.Disable();
        _playerControler.Player.Attack.started -= OnAttackStarted;
        _playerControler.Player.Block.started -= OnBlockStarted;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _playerLookDirection = _direction.ReadValue<Vector2>();
        float moveX = _playerLookDirection.x;

        if (moveX != 0f)
        {
            PlayerRotate(moveX > 0f ? 0f : 180f);
        }
    }

    private void OnAttackStarted(InputAction.CallbackContext context)
    {
        _fsM.SetState<Attack>();
    }

    private void OnBlockStarted(InputAction.CallbackContext context)
    {
        _fsM.SetState<Block>();
    }
    private void PlayerRotate(float angle)
    {
        _transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
