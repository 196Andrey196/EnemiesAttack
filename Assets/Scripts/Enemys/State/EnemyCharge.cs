using UnityEngine;

public class EnemyCharge : FSMState
{
    public EnemyCharge(FSM fsm, float reloadAttack, Enemy chaaracter) : base(fsm)
    {
        _fsM = fsm;
        _chargeDuration = reloadAttack;
        _chaaracter = chaaracter;
    }
    private FSM _fsM;
    private float _chargeTimer = 0.0f;
    private float _chargeDuration;
    private Enemy _chaaracter;


    public override void Enter()
    {
        _chargeTimer = 0.0f;
    }

    public override void Update()
    {
        _chargeTimer += Time.deltaTime;


        if (_chargeTimer >= _chargeDuration)
        {
            if (_chaaracter.GetType() == typeof(Dragon)) _fsM.SetState<DragonAttack>();
            if (_chaaracter.GetType() == typeof(Ninja)) _fsM.SetState<EnemyAttack>();
        }
    }
}