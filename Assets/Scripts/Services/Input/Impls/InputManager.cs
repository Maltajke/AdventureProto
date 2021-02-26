using UnityEngine;

namespace Services.Input.Impls
{
    public class InputManager : IInputManager
    {
        private InputActions Actions { get; }
        
        public InputManager()
        {
            Actions = new InputActions();
            Actions.Enable();
        }

        private static Vector3 GetInput(Vector2 inputValue) => new Vector3 {x = inputValue.x, z = inputValue.y};

        public Vector3 InputValue => GetInput(Actions.Player.Move.ReadValue<Vector2>());
    }
}