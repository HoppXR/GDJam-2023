using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager
{
    private static Control _Controls;

    public static void Init(Player myplayer)
    {
        _Controls = new Control();
        
        _Controls.Game.PMovement.performed += hi =>
        {
            myplayer.SetMovementDirection(hi.ReadValue<Vector2>());
        };
    }
    public static void Init2(Monster mymonster)
    {
        _Controls.Game.MMovement.performed += hi =>
        {
            mymonster.SetMovementDirection(hi.ReadValue<Vector2>());
        };

        _Controls.Permanent.Enable();
    }
    
    public static void SetGameControls()
    {
        _Controls.Game.Enable();
        _Controls.UI.Disable();
    }

    public static void SetUIControls()
    {
        _Controls.UI.Enable();
        _Controls.Game.Disable();
    }
}