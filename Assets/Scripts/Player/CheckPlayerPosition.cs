using UnityEngine;

public class CheckPlayerPosition : MonoBehaviour
{
    public static CheckPlayerPosition Instance;

    public float playerHorizontalPosition;
    public bool playerIsInTheRight;
    public bool playerIsInTheLeft;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    private void Update()
    {
        CheckToPlayerPosition();
    }

    private void CheckToPlayerPosition()
    {
        playerHorizontalPosition = transform.position.x;
        playerIsInTheRight = playerHorizontalPosition >= -0.5f;
        playerIsInTheLeft = playerHorizontalPosition <= 0.5f;
    }
}