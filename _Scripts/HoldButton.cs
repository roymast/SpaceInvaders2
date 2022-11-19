using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButton : MonoBehaviour
{
    public InputManager inputManager;

    public bool IsLeft;        

    public void OnMouseDown()
    {
        Debug.Log("on button pressed: " + (IsLeft ? "left" : "right"));
        if (IsLeft)
            inputManager.MoveLeft();
        else
            inputManager.MoveRight();
    }
    private void OnMouseUp()
    {
        inputManager.StopMoving();
    }    
}
