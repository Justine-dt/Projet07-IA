using System.Collections;
using UnityEngine;

public class BatBrain : Brain
{
    [SerializeField] EntityMove _entityMove;
    [SerializeField] SpriteRenderer _spriteRenderer;
    Coroutine _move;

    void Start()
    {
        _move = StartCoroutine(RandomMove());
    }

    private IEnumerator RandomMove()
    {
        while (true)
        {
            Vector2 randomDestination = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));

            if (randomDestination.x <0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_spriteRenderer.flipX = true && randomDestination.x > 0)
            {
                _spriteRenderer.flipX = false;
            }

            while (Vector2.Distance(transform.position, randomDestination)  > 1f)
            {

                // Déplace le joueur avec la direction aléatoire
                _entityMove.Move(randomDestination - (Vector2)transform.position);
                yield return null;
            }

            // Attend un certain temps avant de générer une nouvelle direction
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
