public abstract class State
{
    protected Brain _brain;

    public virtual void OnEnter(Brain brain)
    {
        Collision.OnHurt += OnHurt;
        _brain = brain;
    }

    public virtual void OnHurt() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        Collision.OnHurt -= OnHurt;
    }
}