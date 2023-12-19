using System.Collections.Generic;

public class Selector : Node
{
    //At least 1 child must succeed evaluation
    public Selector() : base() { }
    public Selector(List<Node> children) : base(children) { }

    public override NodeState Evaluate()
    {
        foreach (Node node in _children)
        {
            switch (node.Evaluate())
            {
                case NodeState.FAILURE:
                    continue;
                case NodeState.RUNNING:
                    _currentState = NodeState.RUNNING;
                    return _currentState;
                case NodeState.SUCCESS:
                    _currentState = NodeState.SUCCESS;
                    return _currentState;
                default:
                    continue;
            }
        }

        _currentState = NodeState.FAILURE;
        return _currentState;
    }
}