using System;
using UnityEngine;

namespace Services.Input
{
    public interface IInputManager
    {
        InputActions Actions { get; }
        Vector3 InputValue { get; }
        void PlayerEnable(bool value);
        bool PlayerInteract();
    }
}