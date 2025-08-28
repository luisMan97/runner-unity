using UnityEngine;

public class DeniedMovement : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private PlayerMovement playerMovement;

    private Vector3 rightDirection;
    private Vector3 leftDirection;

    private void Awake()
    {
        rightDirection = transform.right;
        leftDirection = -transform.right;
    }

    private void Update()
    {
        RightSideDetection();
        LeftSideDtecion();
    }


    public void RightSideDetection()
    {
        Ray rayRight = new Ray(transform.position, rightDirection);
        Debug.DrawRay(rayRight.origin, rayRight.direction * distance, Color.red);

        if (Physics.Raycast(rayRight, distance) && GameManager.Instance.playerHit && !GameManager.Instance.sideCrash)
        {
            IsGameOver();
        }
          
        else if (Physics.Raycast(rayRight, distance))
        {
            GameManager.Instance.sideCrash = true;
            EnabledEnemy();
            Invoke("DisableSideCrash", 0.5f);
        }
    }

    public void LeftSideDtecion()
    {
        Ray rayLeft = new Ray(transform.position, leftDirection);
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * distance, Color.blue);

        if (Physics.Raycast(rayLeft, distance) && GameManager.Instance.playerHit && !GameManager.Instance.sideCrash)
        {
            IsGameOver();
        }
           
        else if (Physics.Raycast(rayLeft, distance))
        {
            GameManager.Instance.sideCrash = true;
            EnabledEnemy();
            Invoke("DisableSideCrash", 0.5f);
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

    private void DisableSideCrash()
    {
        GameManager.Instance.sideCrash = false;
    }
}
