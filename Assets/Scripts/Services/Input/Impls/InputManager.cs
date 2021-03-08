using UnityEngine;

namespace Services.Input.Impls
{
    public class InputManager : IInputManager
    {
        public InputActions Actions { get; }

        private bool moveEnable;
        public InputManager()
        {
            Actions = new InputActions();
            Actions.Enable();
        }

        private static Vector3 GetInput(Vector2 inputValue) => new Vector3 {x = inputValue.x, z = inputValue.y};

        public Vector3 InputValue => moveEnable ? GetInput(Actions.PlayerMove.Move.ReadValue<Vector2>()) : Vector3.zero;

        public void PlayerEnable(bool value)
        {
            moveEnable = value;
            if(value)
                Actions.PlayerInteractions.Enable();
            else 
                Actions.PlayerInteractions.Disable();
        }

        public void MoveEnable(bool value)
        {
            if(value)
                Actions.PlayerInteractions.Dive.Enable();
            else 
                Actions.PlayerInteractions.Dive.Disable();
            moveEnable = value;
        }
    }
}