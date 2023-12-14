using System.Collections;
using UnityEngine;

public class AnimationChange : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;

    public AnimationClip newAnimationClip; // Ajoutez cette ligne pour définir le nouveau clip d'animation

    void Start()
    {
        // Assurez-vous que l'Animator est attaché
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogError("Animator not found!");
                return;
            }
        }

        // Assurez-vous que le SpriteRenderer est attaché
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (_spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer not found!");
                return;
            }
        }

        // Changez le clip d'animation
        //ChangeAnimationClip();
    }

    //void ChangeAnimationClip()
    //{
    //    // Assurez-vous que le clip d'animation est défini
    //    if (newAnimationClip != null)
    //    {
    //        // Changez le clip d'animation
    //        _animator.runtimeAnimatorController = null; // Réinitialisez le contrôleur d'animation
    //        _animator.runtimeAnimatorController = AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/NewController.controller");
    //        _animator.Play(newAnimationClip.name); // Jouez le nouveau clip

    //        // Changez également le sprite du SpriteRenderer si nécessaire
    //        // _spriteRenderer.sprite = /* votre nouveau sprite */;
    //    }
    //    else
    //    {
    //        Debug.LogError("New Animation Clip not set!");
    //    }
    //}
}
