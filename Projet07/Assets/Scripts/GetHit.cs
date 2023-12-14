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
        Collision.OnHurt += ChangeColor;
    }

    private void OnDestroy()
    {
        Collision.OnHurt -= ChangeColor;
    }

    void ChangeColor()
    {
        StartCoroutine(ColorChange());
    }

    // Coroutine pour changer temporairement la couleur du SpriteRenderer
    IEnumerator ColorChange()
    {
        _sprite.color = hitColor;
        yield return new WaitForSeconds(hitColorDuration);
        _sprite.color = normalColor;
    }
}