using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.75f;
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private InputActionAsset inputActions;
    private InputAction moveAction;
    private Vector2 moveInput;

    void Awake()
    {
        if (inputActions != null)
        {
            var map = inputActions.FindActionMap("Player");
            if (map != null) moveAction = map.FindAction("Move");
        }
    }

    void OnEnable()
    {
        if (moveAction != null) moveAction.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null) moveAction.Disable();
    }

    void Update()
    {
        if (moveAction != null)
        {
            moveInput = moveAction.ReadValue<Vector2>();
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = moveInput * moveSpeed;
        }
    }
}