
public interface IState<TStateMachine>
{
    public TStateMachine StateMachine { get; set; }
    void Enter();

    void Execute();

    void Exit();

}
