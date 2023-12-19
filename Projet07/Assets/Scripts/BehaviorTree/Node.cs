using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node
{
    public Node Parent => _parent;

    protected NodeState _currentState;
    protected List<Node> _children = new();

    private Node _parent;
    private Dictionary<string, object> _data = new();

    public Node()
    {
        _parent = null;
    }

    public Node(List<Node> children)
    {
        foreach (var child in children) Attach(child);
    }

    private void Attach(Node node)
    {
        node._parent = this;
        _children.Add(node);
    }

    public void SetData(string key, object value)
    {
        _data[key] = value;
    }

    public object GetData(string key)
    {
        if (_data.TryGetValue(key, out object data)) return data;
        if (_parent != null) data = _parent.GetData(key);

        return data;
    }

    public bool ClearData(string key)
    {
        bool cleared = false;

        if (_data.ContainsKey(key))
        {
            _data.Remove(key);
            return true;
        }

        if (_parent != null)
        {
            cleared = _parent.ClearData(key);
        }

        return cleared;
    }

    public virtual NodeState Evaluate() => NodeState.FAILURE;
}