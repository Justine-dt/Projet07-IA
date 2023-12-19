using UnityEngine;

public abstract class Tree : MonoBehaviour
{
    private Node _root = null;

    private void Awake()
    {
        SetupTree();
    }

    private void Update()
    {
        _root?.Evaluate();
    }

    protected abstract Node SetupTree();
}