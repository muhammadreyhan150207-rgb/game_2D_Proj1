using UnityEngine;
using System;

public class InputSystemMoveInput : IMoveInput, IDisposable
{
    private InputSystem_Actions inputActions;

    public InputSystemMoveInput()
    {
        if (inputActions == null)
        {
            inputActions = new InputSystem_Actions();
        }

        // Aktifkan asset secara keseluruhan dan map Player-nya
        inputActions.Enable();
        inputActions.Player.Enable();
    }

    public Vector2 Move => inputActions.Player.Move.ReadValue<Vector2>();

    public bool IsRunning => false;

    // Tambahkan method Dispose untuk mematikan input actions dan mencegah memory leak
    public void Dispose()
    {
        if (inputActions != null)
        {
            inputActions.Player.Disable();
            inputActions.Disable();
            inputActions.Dispose();
            inputActions = null;
        }
    }
}