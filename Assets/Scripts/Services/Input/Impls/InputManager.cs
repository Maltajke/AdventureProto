using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.Input.Impls
{
    public class InputManager : IInputManager
    {
        public InputActions Actions { get; }
        public InputManager()
        {
            Actions = new InputActions();
            Actions.Enable();
        }

        private static Vector3 GetInput(Vector2 inputValue) => new Vector3 {x = inputValue.x, z = inputValue.y};

        public Vector3 InputValue => GetInput(Actions.Player.Move.ReadValue<Vector2>());
        public void PlayerEnable(bool value)
        {
            if(value)
                Actions.Player.Enable();
            else 
                Actions.Player.Disable();
        }

        public bool PlayerInteract() => Actions.Player.Interact.triggered;
    }
}