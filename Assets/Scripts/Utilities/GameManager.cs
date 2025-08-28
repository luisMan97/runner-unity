using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Player
    public bool isMoving;
    public bool isCrouch;
    public bool playerHit;
    public bool sideCrash;
    #endregion
    #region Enemy
    public GameObject enemy;
    public int countdown;
    public bool showPolicePig;
    public bool policePigIsVisible = true;
    #endregion
    #region IU
    public bool isGameOver;
    public bool tutorialStep = false;
    #endregion
    #region Objects
    public bool platformRestored;
    #endregion

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

}