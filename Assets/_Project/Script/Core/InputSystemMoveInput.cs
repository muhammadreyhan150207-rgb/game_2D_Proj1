using UnityEngine;

public class InputSystemMoveInput : IMoveInput
{
    private InputSystem_Actions inputActions;

    public InputSystemMoveInput()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable(); 
    }

    public Vector2 Move => inputActions.Player.Move.ReadValue<Vector2>();
    
    // Untuk sementara dimatikan dulu agar tidak error
    public bool IsRunning => false; 
}