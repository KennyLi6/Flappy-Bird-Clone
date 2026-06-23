using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    const int OBSTACLE_LAYER = 6;
    const int POINT_LAYER = 7;
    // TODO: Create Event for OnCollisionEnter
    // Check which collider layer type
    // End game if Obstacle
    // OnCollisionExit with Point layer Add Point

    private void OisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == OBSTACLE_LAYER)
        {
            // End game
            // timescale = 0?
        }
        if (collision.gameObject.layer == POINT_LAYER)
        {
            // event listener for point trigger
        }
    }
}
