using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject start;
    public bool tutorialStep;

    private void Awake()
    {
        DisableMenu();
        EnableCurrentMenu();
    }

    private void EnableCurrentMenu()
    {
        if (tutorialStep)
        {
            start.SetActive(true);
        }

        else
            tutorial.SetActive(true);
    }

    private void DisableMenu()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
