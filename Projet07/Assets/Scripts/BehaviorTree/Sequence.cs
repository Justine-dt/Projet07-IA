using System.Collections.Generic;

public class Sequence : Node
{
    //All children must succeed evaluation
    public Sequence() : base() { }
    public Sequence(List<Node> children) : base(children) { }

    public override NodeState Evaluate()
    {
        bool anyChildIsRunning = false;

        foreach (Node node in _children)
        {
            switch (node.Evaluate())
            {
                case NodeState.FAILURE:
                    _currentState = NodeState.FAILURE;
                    return _currentState;
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    anyChildIsRunning = true;
                    continue;
                default:
                    _currentState = NodeState.SUCCESS;
                    return _currentState;
            }
        }

        _currentState = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _currentState;
    }
}