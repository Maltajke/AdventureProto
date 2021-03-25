using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ECS.DataSave
{
    [Serializable]
    public class GeneralState
    {
        [JsonProperty] public List<State> states;
    }

    [Serializable]
    public class State
    {
        public readonly List<object> _components;
        public State(List<object> components)
        {
            _components = components;
        }
    }
}