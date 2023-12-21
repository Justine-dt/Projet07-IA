using System.Collections.Generic;

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node
{
    public Node Parent;
    protected List<Node> _children;
    protected NodeState _state;

    private readonly Dictionary<string, object> _dataContext = new();

    public Node()
    {
        Parent = null;
    }

    public Node(List<Node> children)
    {
        foreach (Node child in children) Attach(child);
    }

    private void Attach(Node node)
    {
        node.Parent = this;
        _children.Add(node);
    }

    public virtual NodeState Evaluate() => NodeState.FAILURE;

    public void SetData(string key, object value)
    {
        _dataContext[key] = value;
    }

    public object GetData(string key)
    {
        if (_dataContext.TryGetValue(key, out object val)) return val;
        if (Parent != null) val = Parent.GetData(key);
        return val;
    }

    public bool ClearData(string key)
    {
        bool cleared = false;

        if (_dataContext.ContainsKey(key))
        {
            _dataContext.Remove(key);
            return true;
        }

        if (Parent != null) cleared = Parent.ClearData(key);

        return cleared;
    }
}