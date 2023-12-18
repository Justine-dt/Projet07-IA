using UnityEngine;

public class FindHidingPlace : State
{
    /*
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        SearchHidePoint();
    }

    
    void SearchHidePoint()
    {
        brain._player = GameObject.FindGameObjectWithTag("Player");

        //Find every obstacles
        brain.obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        float baseMagnitude = 100.0f;

        //Find the nearest obstacle
        if (brain.obstacles.Length > 0)
        {
            foreach (GameObject obstacle in brain.obstacles)
            {
                //If the current obstacle is nearer than the previous one, update the variable nearestObstacle
                if (obstacle.transform.position.magnitude < baseMagnitude)
                {
                    brain.nearestObstacle = obstacle;
                    baseMagnitude = obstacle.transform.position.magnitude;
                }
            }
        }

        //Put the direction of movement to the nearest obstacle
        brain.target = brain.nearestObstacle.transform.position;


        //Check position of player to go to the best side of the nearest obstacle to hide
        brain.playerPosition = brain._player.transform.position - brain._malingre.transform.position;

        if (Mathf.Abs(brain.playerPosition.x) > Mathf.Abs(brain.playerPosition.y))
        {
            if (brain.playerPosition.x > 0)
            {
                brain.target.x -= 1;
            }
            else
            {
                brain.target.x += 1;
            }
        }
        else
        {
            if (brain.playerPosition.y > 0)
            {
                brain.target.y -= 1.4f;
            }
            else
            {
                brain.target.y += 1.4f;
            }
        }
    }

    public override void OnUpdate()
    {
        brain._malingre.transform.position = Vector2.MoveTowards(brain._malingre.transform.position, brain.target, Time.deltaTime * 4);
    }
    */

}
