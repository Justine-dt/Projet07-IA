using System.Collections;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;

    public Color normalColor = Color.white;
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.005f;

    void Awake()
    {
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
        _sprite.color = hitColor;
        yield return new WaitForSeconds(hitColorDuration);
        _sprite.color = normalColor;
    }
}
