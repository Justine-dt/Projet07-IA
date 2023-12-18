using System;
using System.Collections;
using UnityEngine;

public class DetonateAction : MonoBehaviour
{
    public static event Action OnExplode;

    [SerializeField] SpriteRenderer _sprite;

    [SerializeField] private Color _hitColor = Color.black;
    [SerializeField] private float _hitColorDuration = 0.2f;

    private Color _normalColor;
    private Coroutine _detonate;

    private void Awake()
    {
        DetonateState.OnDetonate += ChangeColor;
        DetonateState.OnStopDetonate += StopColor;
        _normalColor = _sprite.color;
    }

    private void OnDestroy()
    {
        DetonateState.OnDetonate -= ChangeColor;
        DetonateState.OnStopDetonate -= StopColor;
    }

    private void ChangeColor(Transform source)
    {
        if (source != transform) return;
        _detonate = StartCoroutine(ColorChange());
    }

    private void StopColor(Transform source)
    {
        if (source != transform) return;
        StopCoroutine(_detonate);
        _hitColorDuration = 0.2f;
    }

    IEnumerator ColorChange()
    {
        while (true)
        {
            _sprite.color = _hitColor;
            yield return new WaitForSeconds(_hitColorDuration);
            _sprite.color = _normalColor;
            yield return new WaitForSeconds(_hitColorDuration);
            _hitColorDuration -= 0.01f;

            if (_hitColorDuration <= 0)
            {
                OnExplode?.Invoke();
                break;
            }
        }

        yield break;
    }
}