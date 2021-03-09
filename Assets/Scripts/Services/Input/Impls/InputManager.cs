using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.Input.Impls
{
    public class InputManager : IInputManager
    {
        private class CacheInput
        {
            public readonly Dictionary<InputAction, bool> ActionsCache;
            public bool MoveEnable;
            public CacheInput(Dictionary<InputAction, bool> actionsCache, bool moveEnable)
            {
                ActionsCache = actionsCache;
                MoveEnable = moveEnable;
            }
        }
        public InputActions Actions { get; }
        private readonly CacheInput _cacheInput;
        private bool moveEnable;
        public InputManager()
        {
            _cacheInput = new CacheInput(new Dictionary<InputAction, bool>(), true);
            Actions = new InputActions();
            Actions.Enable();
        }

        private static Vector3 GetInput(Vector2 inputValue) => new Vector3 {x = inputValue.x, z = inputValue.y};

        public Vector3 InputValue => moveEnable ? GetInput(Actions.PlayerMove.Move.ReadValue<Vector2>()) : Vector3.zero;

        public void PlayerEnable(bool value)
        {
            if (value)
            {
                if (LoadStates()) return;
                Actions.PlayerInteractions.Enable();
            }
            else
            {
                SaveStates();
                Actions.PlayerInteractions.Disable();
            }
            moveEnable = value;
        }

        public void MoveEnable(bool value)
        {
            if(value)
                Actions.PlayerInteractions.Dive.Enable();
            else 
                Actions.PlayerInteractions.Dive.Disable();
            moveEnable = value;
        }

        private void SaveStates()
        {
            _cacheInput.ActionsCache.Clear();
            foreach (var a in Actions.PlayerInteractions.Get().actions)
                _cacheInput.ActionsCache.Add(a, a.enabled);
            _cacheInput.MoveEnable = moveEnable;
        }

        private bool LoadStates()
        {
            if (_cacheInput.ActionsCache.Count == 0)
                return false;
            foreach (var a in _cacheInput.ActionsCache)
            {
                if(a.Value)
                    a.Key.Enable();
                else
                    a.Key.Disable();
            }
            moveEnable = _cacheInput.MoveEnable;
            return true;
        }

        public void Dispose()
        {
            _cacheInput.ActionsCache.Clear();
        }
    }
}