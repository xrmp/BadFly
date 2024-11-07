using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public static event Action OnSpacePressed;
    public static event Action OnSpaceReleased;
    public static event Action OnMoveLeft;
    public static event Action OnMoveRight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnSpaceReleased?.Invoke();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            OnMoveLeft?.Invoke();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            OnMoveRight?.Invoke();
        }
    }
}
