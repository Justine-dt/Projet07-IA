using UnityEngine;

public class TwinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _twinAPrefab;
    [SerializeField] private GameObject _twinBPrefab;

    private GameObject _twinA;
    private GameObject _twinB;
    private TwinBrain _twinABrain;
    private TwinBrain _twinBBrain;

    private void Awake()
    {
        _twinA = Instantiate(_twinAPrefab, transform);
        _twinB = Instantiate(_twinBPrefab, transform);

        _twinABrain = _twinA.GetComponentInChildren<TwinBrain>();
        _twinBBrain = _twinB.GetComponentInChildren<TwinBrain>();

        _twinABrain.SetTwin(_twinBBrain);
        _twinBBrain.SetTwin(_twinABrain);

        _twinA.transform.position = transform.position;
        _twinB.transform.position = transform.position;
    }
}