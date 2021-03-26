using System.Collections.Generic;
using Zenject;

namespace ECS.DataSave
{
    public class GameStatePool : MemoryPool<GameState>
    {
        protected override void OnDespawned(GameState item)
        {
            item.States = new List<SaveState>();
        }
    }
}