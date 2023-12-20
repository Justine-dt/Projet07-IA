using System.Collections;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] private Color _hitColor = Color.red;
    [SerializeField] private float _hitColorDuration = 0.1f;

    private Color _normalColor;

    void Awake()
    {
        _normalColor = _sprite.color;
        EntityStats.OnHurt += ChangeColor;
    }

    private void OnDestroy()
    {
        EntityStats.OnHurt -= ChangeColor;
    }

    void ChangeColor(SpriteRenderer source, GameObject damageDealer)
    {
        if (source != _sprite) return;
        StartCoroutine(ColorChange());
    }

    IEnumerator ColorChange()
    {
        _sprite.color = _hitColor;
        yield return new WaitForSeconds(_hitColorDuration);
        _sprite.color = _normalColor;
    }
}