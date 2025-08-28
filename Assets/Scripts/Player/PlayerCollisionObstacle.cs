using UnityEngine;

public class PlayerCollisionObstacle: MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            GameManager.Instance.isGameOver = true;
            


        }
    }
}
