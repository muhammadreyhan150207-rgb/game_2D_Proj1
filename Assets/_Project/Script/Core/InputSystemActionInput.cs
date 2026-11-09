using UnityEngine;

public class InputSystemActionInput : IActionInput
{
    private readonly InputSystem_Actions inputActions;

    public InputSystemActionInput()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
    }

    public Vector2 Move => inputActions.Player.Move.ReadValue<Vector2>();
    public bool InteractPressed => inputActions.Player.Interact.WasPressedThisFrame();
}