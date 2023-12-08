using UnityEngine;

public class Enemy : CharacterInfo
{
    [SerializeField] protected Transform _targetToMoveOrAttack;
    public Transform targetToMoveOrAttack { get { return _targetToMoveOrAttack; } set { if (value != null) _targetToMoveOrAttack = value; } }
    [SerializeField] protected float _moveSpeed;
    public float moveSpeed { get { return _moveSpeed; } }
    [SerializeField] protected float _reloadAtack;
    public float reloadAtack { get { return _reloadAtack; } }
    public float proximityThresholdToTarget;
}
