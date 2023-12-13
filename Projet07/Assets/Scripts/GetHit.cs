using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    // D�claration d'une variable priv�e de type SpriteRenderer pour stocker la r�f�rence au composant SpriteRenderer de l'objet
    private SpriteRenderer spriteRenderer;

    // D�claration de variables publiques pour les couleurs normale et de frappe, ainsi que la dur�e de la couleur de frappe
    public Color normalColor = Color.white;
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.2f;

    void Start()
    {
        // Obtention de la r�f�rence au composant SpriteRenderer de l'objet
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    // M�thode appel�e lorsqu'un autre collider entre en collision avec le collider de cet objet
    void OnTriggerEnter2D(Collider2D other)
    {
        // V�rification si l'objet entrant a un tag sp�cifique (v�rifiez et remplacez "VotreTag" par le tag appropri�)
        if (other.CompareTag("VotreTag"))
        {
            // D�marrage de la coroutine ColorChange
            StartCoroutine(ColorChange());
            // Ajoutez ici le code suppl�mentaire pour g�rer la collision
        }
    }

    // Coroutine pour changer temporairement la couleur du SpriteRenderer
    IEnumerator ColorChange()
    {
        // Changement de la couleur du SpriteRenderer � la couleur de frappe
        spriteRenderer.color = hitColor;
        // Attente pendant une courte dur�e sp�cifi�e
        yield return new WaitForSeconds(hitColorDuration);
        // R�tablissement de la couleur normale apr�s la dur�e sp�cifi�e
        spriteRenderer.color = normalColor;
    }
}
