using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerMovement;

public class InputManager : MonoBehaviour
{
    public InputAction horizontalMovement;
    public InputAction jumping;
    public InputAction crouch;

    private InputSystem_Actions inputSystem;

    private PlayerMovement playerMovement;
    private PlayerJumping playerJumping;
    private PlayerCrouch playerCrouch;

    #region Swipe Properties

    private float thresholdSwipe = 70f;
    private float swipeTime;
    private float startTime;
    private float endTime;
    private float minTime = 0.1f;
    private float maxTime = 1f;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    #endregion

    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        horizontalMovement = inputSystem.Player.Move;
        jumping = inputSystem.Player.Jump;
        crouch = inputSystem.Player.Crouch;

        playerMovement = GetComponent<PlayerMovement>();
        playerJumping = GetComponent<PlayerJumping>();
        playerCrouch = GetComponent<PlayerCrouch>();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        horizontalMovement.Enable();
        jumping.Enable();
        crouch.Enable();
        inputSystem.Player.TouchContact.started += ctx => StartTouchContact(ctx);
        inputSystem.Player.TouchContact.canceled += ctx => EndTouchContact(ctx);
    }

    private void OnDisable()
    {
        inputSystem.Disable();
        horizontalMovement.Disable();
        jumping.Disable();
        crouch.Disable();
        inputSystem.Player.TouchContact.started -= ctx => StartTouchContact(ctx);
        inputSystem.Player.TouchContact.canceled -= ctx => EndTouchContact(ctx);
    }

    #region Swipe Methods

    private void StartTouchContact(InputAction.CallbackContext callbackContext)
    {
        startTouchPosition = inputSystem.Player.TouchPosition.ReadValue<Vector2>();
        startTime = Time.time;
    }

    private void EndTouchContact(InputAction.CallbackContext callbackContext)
    {
        endTouchPosition = inputSystem.Player.TouchPosition.ReadValue<Vector2>();

        endTime = Time.time;
        swipeTime = endTime - startTime;
        Swipe();
    }

    private void Swipe()
    {
        if (swipeTime < minTime || swipeTime > maxTime)
            return;

        if (endTouchPosition.x < startTouchPosition.x - thresholdSwipe)
        {
            playerMovement.SetTargetPosition(CheckPlayerPosition.Instance.playerIsInTheLeft ? PlayerPosition.Left : PlayerPosition.Mid);
            StartCoroutine(playerMovement.HandleAnimationState(-1));
        }
            

        if (endTouchPosition.x > startTouchPosition.x + thresholdSwipe)
        {
            playerMovement.SetTargetPosition(CheckPlayerPosition.Instance.playerIsInTheRight ? PlayerPosition.Right : PlayerPosition.Mid);
            StartCoroutine(playerMovement.HandleAnimationState(1));
        }
           
        if (endTouchPosition.y < startTouchPosition.y - thresholdSwipe)
            playerCrouch.Crouch();

        if (endTouchPosition.y > startTouchPosition.y + thresholdSwipe)
            playerJumping.Jump();
    }

    #endregion

}
