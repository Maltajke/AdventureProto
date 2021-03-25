using System.Collections.Generic;
using Zenject;

namespace ECS.DataSave
{
    public class GeneralStatePool : MemoryPool<GeneralState>
    {
        protected override void OnDespawned(GeneralState item)
        {
            item.states = new List<State>();
        }
    }
}