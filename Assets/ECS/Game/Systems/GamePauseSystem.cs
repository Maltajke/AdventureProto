using System;
using DataBase.Game;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Game.Components.Events;
using Leopotam.Ecs;
using Services.PauseService;

namespace ECS.Game.Systems
{
    public class GamePauseSystem : ReactiveSystem<ChangeStageComponent>
    {
        protected override EcsFilter<ChangeStageComponent> ReactiveFilter { get; }
        private readonly EcsFilter<LinkComponent> _links;
        protected override bool DeleteEvent() => false;
        protected override void Execute(EcsEntity entity)
        {
            var stage = ReactiveFilter.Get1(0).Value;
            foreach (var i in _links)
            {
                try
                {
                    var view = (IPause) _links.Get1(i).View;
                    if(stage == EGameStage.Pause)
                        view.Pause();
                    else
                        view.UnPause();
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
        }
    }
}