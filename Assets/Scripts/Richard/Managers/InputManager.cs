using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager
{
    private static Control _Controls;
    private static Control _Control2;

    public static void Init(Player myplayer)
    {
        _Controls = new Control();
        
        _Controls.Game.PMovement.performed += hi =>
        {
            myplayer.SetMovementDirection(hi.ReadValue<Vector2>());
        };
        _Controls.Permanent.Enable();
    }
    public static void SetGameControls()
    {
        _Controls.Game.Enable();
        _Control2.Game.Enable();
        _Controls.UI.Disable();
    }

    public static void SetUIControls()
    {
        _Controls.UI.Enable();
        _Controls.Game.Disable();
        _Control2.Game.Disable();
    }
}