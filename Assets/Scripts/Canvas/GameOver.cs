
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private TextMeshProUGUI countdownText; 
    private bool playerMadeChoice = false;
    private float countdownTime = 8f; 
    private bool isCoroutineRunning = false; 

    private void Awake()
    {
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            if (!gameOver.activeSelf)
            {
                gameOver.SetActive(true);

               
                if (!isCoroutineRunning)
                {
                    StartCoroutine(HandleGameOverScreen());
                }
            }
        }
    }

    private IEnumerator HandleGameOverScreen()
    {
        isCoroutineRunning = true; 

        float startTime = Time.time;
        float endTime = startTime + countdownTime;

        while (Time.time < endTime)
        {
            float remainingTime = Mathf.Max(endTime - Time.time, 0);
            countdownText.text = Mathf.Ceil(remainingTime).ToString(); 
            yield return new WaitForSeconds(1f); 
        }

      
        countdownText.text = "0";

       
        if (!playerMadeChoice)
        {
            GoToMainMenu();
        }

        isCoroutineRunning = false; 
    }

    public void Retry()
    {
        playerMadeChoice = true;
        Time.timeScale = 1;
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        playerMadeChoice = true;
        Time.timeScale = 1;
        GoToMainMenu();
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneConstants.menu);
    }
}

