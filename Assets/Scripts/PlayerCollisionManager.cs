using System;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    const int OBSTACLE_LAYER = 6;
    const int POINT_LAYER = 7;

    public event EventHandler OnObstacleCollision;
    public event EventHandler OnScoreCollision;
    // TODO: Create Event for OnCollisionEnter
    // Check which collider layer type
    // End game if Obstacle
    // OnCollisionExit with Point layer Add Point

    private void ObstacleCollision_performed()
    {
        OnObstacleCollision?.Invoke(this, EventArgs.Empty);        
    }

    private void ScoreCollision_performed()
    {
        OnScoreCollision?.Invoke(this, EventArgs.Empty);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == OBSTACLE_LAYER)
        {
            ObstacleCollision_performed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == POINT_LAYER)
        {
            ScoreCollision_performed();
        }
    }
}
