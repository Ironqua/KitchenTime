using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class InputReader : MonoBehaviour
{
  public Vector2 direction { get; set; }

  public bool hanndleAction { get; set; }

public void OnMove(InputAction.CallbackContext callbackContext)
{
   direction=callbackContext.ReadValue<Vector2>();
}



public void OnAction(InputAction.CallbackContext context)
{
    hanndleAction=context.ReadValueAsButton();
}
}
