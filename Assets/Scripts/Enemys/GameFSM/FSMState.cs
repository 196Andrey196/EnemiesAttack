

public abstract class FSMState
{
    protected readonly FSM _fsm;
    public FSMState(FSM fsm)
    {
        _fsm = fsm;
    }
    public virtual void Enter(float parameter = 0) { }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }

}
