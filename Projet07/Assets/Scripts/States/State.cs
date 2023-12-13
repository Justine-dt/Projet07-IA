public abstract class State
{
    protected Brain _brain;

    public virtual void OnEnter(Brain brain)
    {
        _brain = brain;
    }

    public virtual void OnHurt()
    {
        //Animation
        _brain.ClearTarget();
    }

    public virtual void OnUpdate() { }

    public virtual void OnExit() { }
}