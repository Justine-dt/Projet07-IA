using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    // Déclaration d'une variable privée de type SpriteRenderer pour stocker la référence au composant SpriteRenderer de l'objet
    private SpriteRenderer spriteRenderer;

    // Déclaration de variables publiques pour les couleurs normale et de frappe, ainsi que la durée de la couleur de frappe
    public Color normalColor = Color.white;
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.2f;

    void Start()
    {
        // Obtention de la référence au composant SpriteRenderer de l'objet
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    // Méthode appelée lorsqu'un autre collider entre en collision avec le collider de cet objet
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérification si l'objet entrant a un tag spécifique (vérifiez et remplacez "VotreTag" par le tag approprié)
        if (other.CompareTag("VotreTag"))
        {
            // Démarrage de la coroutine ColorChange
            StartCoroutine(ColorChange());
            // Ajoutez ici le code supplémentaire pour gérer la collision
        }
    }

    // Coroutine pour changer temporairement la couleur du SpriteRenderer
    IEnumerator ColorChange()
    {
        // Changement de la couleur du SpriteRenderer à la couleur de frappe
        spriteRenderer.color = hitColor;
        // Attente pendant une courte durée spécifiée
        yield return new WaitForSeconds(hitColorDuration);
        // Rétablissement de la couleur normale après la durée spécifiée
        spriteRenderer.color = normalColor;
    }
}
