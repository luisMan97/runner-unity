using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionManager : MonoBehaviour
{
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
