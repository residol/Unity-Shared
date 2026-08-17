public class State<T>
{
    public T Tstate { get; private set; }

    public void SetTState(T state)
    {
        Tstate = state;
    }

}
