using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private TextMeshProUGUI timer;

    private void Awake()
    {
        timer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !GameManager.Instance.isGameOver)
            PauseGame();
    }

    public void Play()
    {
        pause.SetActive(false);
        timer.enabled = true;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        timer.text = "3";
        yield return new WaitForSecondsRealtime(1);
        timer.text = "2";
        yield return new WaitForSecondsRealtime(1);
        timer.text = "1";
        yield return new WaitForSecondsRealtime(1);
        timer.text = "GO";
        yield return new WaitForSecondsRealtime(0.2f);
        timer.enabled = false;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneConstants.menu);
    }

    public void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
}
