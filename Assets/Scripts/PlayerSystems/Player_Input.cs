using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class Player_Input : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public bool isFiring;
        public static Player_Input instance;

        private void OnDisable()
        {
            move = Vector2.zero;
            isFiring = false;
        }


        private void Awake()
        {
            instance = this;
        }

        public void OnMoving(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnFire(InputValue value)
        {
            FireInput(value.isPressed);
        }


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void FireInput(bool newFireState)
        {
            isFiring = newFireState;
        }

    }
}