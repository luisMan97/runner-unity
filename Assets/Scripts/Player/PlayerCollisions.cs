using System.Diagnostics;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagConstants.directCollision))
        {
            IsGameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConstants.rubCollision) && GameManager.Instance.playerHit)
        {
            IsGameOver();
        }
        else if (other.CompareTag(TagConstants.rubCollision))
        {
            EnabledEnemy();
        }
    }

    private void IsGameOver()
    {
        GameManager.Instance.isGameOver = true;
        Time.timeScale = 0;
    }

    private void EnabledEnemy()
    {
        GameManager.Instance.enemy.SetActive(true);
        GameManager.Instance.playerHit = true;
        Invoke("DisabledEnemy", GameManager.Instance.countdown);
    }

    private void DisabledEnemy()
    {
        GameManager.Instance.enemy.SetActive(false);
        GameManager.Instance.playerHit = false;
    }
}
