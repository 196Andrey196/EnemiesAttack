using UnityEngine;
using UnityEngine.InputSystem;
public class Block : FSMState
{
    public Block(FSM fsm, PlayerControler playerControler, AnimationSystem animator, GameObject pointForBlock) : base(fsm)
    {
        _fsM = fsm;
        _playerControler = playerControler;
        _animator = animator;
        _pointForBlock = pointForBlock;
        _blockAction = _playerControler.Player.Block;
    }
    private FSM _fsM;
    private PlayerControler _playerControler;
    private AnimationSystem _animator;
    private GameObject _pointForBlock;
    private InputAction _blockAction;

    public override void Enter()
    {
    
        _blockAction.performed += OnBlock;

        _blockAction.canceled += OffBlock;

        _blockAction.Enable();
    }
    public override void Exit()
    {
        _blockAction.performed -= OnBlock;
        _blockAction.canceled -= OffBlock;
        _animator.SetboolAnimation("Block", false);
        _pointForBlock.SetActive(false);
        _blockAction.Disable();
    }

    private void OnBlock(InputAction.CallbackContext context)
    {
        _animator.SetboolAnimation("Block", true);
        _pointForBlock.SetActive(true);
    }
    private void OffBlock(InputAction.CallbackContext context)
    {

        _fsM.SetState<Idle>();

    }
}
