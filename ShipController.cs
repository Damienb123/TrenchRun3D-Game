using UnityEngine;
using UnityEngine.SceneManagement; // for reloading the game

public class ShipController : MonoBehaviour
{
    // Speeds can be adjusted in the Inspector  
    public float speed = 5f;        // Horizontal movement speed
    public float forwardSpeed = 1f; // Forward movement speed

    void Update()
    {
        // Get input for A/D or Left/Right Arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Left/right movement
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f);

        // Forward movement (constant)
        Vector3 forwardMovement = new Vector3(0f, 0f, 1f);

        // Combine horizontal and forward movement
        Vector3 movement = horizontalMovement * speed + forwardMovement * forwardSpeed;

        // Move the ship in world space
        transform.Translate(movement * Time.deltaTime, Space.World);
    }
    // Handle collisions with walls and obstacles for restarting the game
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Reload the current scene on collision with an obstacle
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}