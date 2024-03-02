using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }

    private Controls _controls;

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    //Function yang terpanggil bila gameobject dihancurkan
    private void OnDestroy()
    {
        _controls.Player.Disable();
    }

    //Function yang terpanggil bila gerakan onMove (yaitu dari arrow keys) terpanngil
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }
}
