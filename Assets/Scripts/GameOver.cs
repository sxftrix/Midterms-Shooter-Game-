using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with an enemy of any color
        if (other.gameObject.CompareTag("RedEnemy") || other.gameObject.CompareTag("BlueEnemy") || other.gameObject.CompareTag("GreenEnemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                // Call the GameManager's GameOverLogic() method
                gameManager.GameOverLogic();
            }
        }
    }
}
