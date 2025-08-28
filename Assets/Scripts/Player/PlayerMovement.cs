using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Animator animator;
    private PlayerJumping playerJumping;

    private bool isRightStrafeTriggered = false;
    private bool isLeftStrafeTriggered = false;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float speedMovement;
    [SerializeField] private float waitTime;

    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private Vector3 lastPosition;
    private Vector2 direction;

    private static readonly Vector3 leftPosition = new Vector3(-1.5f, 0f, -5f);
    private static readonly Vector3 rightPosition = new Vector3(1.5f, 0f, -5f);
    private static readonly Vector3 midPosition = new Vector3(0f, 0f, -5f);

    private PlayerPosition currentPlayerPosition = PlayerPosition.Mid;
    private Direction playerDirection = Direction.Neutral;

    public enum PlayerPosition
    {
        Left,
        Right,
        Mid
    }

    public enum Direction
    {
        Left = -1,
        Right = 1,
        Neutral = 0
    }

    private void Awake()
    {
        InitializeComponents();
        targetPosition = transform.position;
    }

    private void InitializeComponents()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        playerJumping = GetComponent<PlayerJumping>();
    }

    private void FixedUpdate()
    {
        HandleMovementInput();
        MoveToTargetPosition();
    }

    private void HandleMovementInput()
    {
        direction = inputManager.horizontalMovement.ReadValue<Vector2>();
        playerDirection = GetDirectionFromInput(direction.x);
        Debug.Log("Luis: " + direction.x);
        if (playerDirection == Direction.Left)
        {
            if (currentPlayerPosition == PlayerPosition.Left && CheckPlayerPosition.Instance.playerIsInTheLeft)
            {
                GameManager.Instance.showPolicePig = true;
                return;
            }
            SetTargetPosition(CheckPlayerPosition.Instance.playerIsInTheLeft ? PlayerPosition.Left : PlayerPosition.Mid);
        }
        else if (playerDirection == Direction.Right)
        {
            if (currentPlayerPosition == PlayerPosition.Right && CheckPlayerPosition.Instance.playerIsInTheRight)
            {
                GameManager.Instance.showPolicePig = true;
                return;
            }
            SetTargetPosition(CheckPlayerPosition.Instance.playerIsInTheRight ? PlayerPosition.Right : PlayerPosition.Mid);
        }
    }

     public void SetTargetPosition(PlayerPosition position)
    {
        currentPlayerPosition = position;
        lastPosition = currentPosition;
        targetPosition = position switch
        {
            PlayerPosition.Left => new Vector3(leftPosition.x, currentPosition.y, currentPosition.z),
            PlayerPosition.Right => new Vector3(rightPosition.x, currentPosition.y, currentPosition.z),
            PlayerPosition.Mid => new Vector3(midPosition.x, currentPosition.y, currentPosition.z),
            _ => currentPosition
        };
        GameManager.Instance.isMoving = true;
    }

    private void MoveToTargetPosition()
    {
        if (!GameManager.Instance.isMoving) return;

        currentPosition = transform.position;
        float newXPosition = Mathf.Lerp(transform.position.x, targetPosition.x, speedMovement * Time.deltaTime);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        StartCoroutine(HandleAnimationState(direction.x));
        CompleteMoveToTargetPosition();
    }

    private Direction GetDirectionFromInput(float inputValue)
    {
        if (inputValue < 0)
            return Direction.Left;
        else if (inputValue > 0)
            return Direction.Right;
        else
            return Direction.Neutral; // O puedes omitir este caso si no es necesario
    }

    private void CompleteMoveToTargetPosition()
    {
        if ((targetPosition - transform.position).magnitude < waitTime)
        {
            GameManager.Instance.isMoving = false;
            transform.position = targetPosition;
        }
        else if (GameManager.Instance.sideCrash)
        {
            GameManager.Instance.isMoving = false;
            targetPosition = lastPosition;
        }
    }

    public IEnumerator HandleAnimationState(float horizontalDirection)
    {
        if (horizontalDirection == 1 && !isRightStrafeTriggered)
        {
            isRightStrafeTriggered = true;
            TriggerAnimation("Jump Right", "Right Strafe");
            yield return new WaitForSeconds(0.5f);
            isRightStrafeTriggered = false;
        }
        else if (horizontalDirection == -1 && !isLeftStrafeTriggered)
        {
            isLeftStrafeTriggered = true;
            TriggerAnimation("Jump Left", "Left Strafe");
            yield return new WaitForSeconds(0.5f);
            isLeftStrafeTriggered = false;
        }
    }

    private void TriggerAnimation(string jumpTrigger, string strafeTrigger)
    {
        animator.SetTrigger(playerJumping.isJumping ? jumpTrigger : strafeTrigger);
    }
}
