using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private InputManager inputManager;
    private Animator animator;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float canCrouch = inputManager.crouch.ReadValue<float>();
        if (canCrouch != 0)
            Crouch();
    }

    public void Crouch()
    {
        if (!GameManager.Instance.isCrouch)
        {
            GameManager.Instance.isCrouch = true;
            animator.SetTrigger("Running Slide");
            Invoke("ResetCrouch", 1f);
        }
    }

    private void ResetCrouch()
    {
        GameManager.Instance.isCrouch = false;
    }
}
