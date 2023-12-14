using System.Collections;
using UnityEngine;

public class BatBrain : Brain
{
    [SerializeField] EntityMove _entityMove;

    Coroutine _move;

    void Start()
    {
        _move = StartCoroutine(RandomMove());
    }

    private IEnumerator RandomMove()
    {
        while (true)
        {
            Vector2 randomDestination = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));

            while(Vector2.Distance(transform.position, randomDestination)  > 1f)
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
