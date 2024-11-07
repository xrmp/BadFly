using System;
using UnityEngine;

namespace Game.Player
{
    public static class InputHandler
    {
        public static event Action OnSpacePressed;
        public static event Action OnSpaceReleased;
        public static event Action OnMoveLeft;
        public static event Action OnMoveRight;

        public static void Update()
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
}
