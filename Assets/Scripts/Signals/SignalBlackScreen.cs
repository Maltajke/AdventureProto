using System;

namespace Signals
{
    public struct SignalBlackScreen
    {
        public readonly bool Open;
        public readonly Action Complete;

        public SignalBlackScreen(bool open, Action complete)
        {
            Open = open;
            Complete = complete;
        }
    }
}