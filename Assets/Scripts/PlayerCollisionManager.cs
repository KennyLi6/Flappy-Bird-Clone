using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    const int OBSTACLE_LAYER = 6;
    const int POINT_LAYER = 7;
    // TODO: Create Event for OnCollisionEnter
    // Check which collider layer type
    // End game if Obstacle
    // OnCollisionExit with Point layer Add Point

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == OBSTACLE_LAYER)
        {
            // End game
            // Currently works, but maybe better to set pipespeed to 0
            // and stop spawn timer counting to allow for player rb
            // to play out physics for game feel
            Time.timeScale = 0;
            Debug.Log(collision);
        }
        if (collision.gameObject.layer == POINT_LAYER)
        {
            // event listener for point trigger
        }
    }
}
