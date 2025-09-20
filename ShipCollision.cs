using UnityEngine;
using UnityEngine.SceneManagement; // Needed to reload the scene

public class ShipCollision : MonoBehaviour // ShipCollision for handling collions with waslls and obstacles
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Wall" or "obstacle"
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
         if (collision.gameObject.CompareTag("obstacle"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggered object has the tag "Wall" or "obstacle"
        if (other.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
         if (other.CompareTag("obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}