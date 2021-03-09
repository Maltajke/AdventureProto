using System;
using UnityEngine;

namespace Services.Input
{
    public interface IInputManager : IDisposable
    {
        InputActions Actions { get; }
        Vector3 InputValue { get; }
        void PlayerEnable(bool value);
        void MoveEnable(bool value);

    }
}