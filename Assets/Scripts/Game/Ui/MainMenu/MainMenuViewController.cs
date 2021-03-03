﻿using Game.SceneLoading;
using Game.Ui.BlackScreen;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Ui.MainMenu
{
    public class MainMenuViewController : UiController<MainMenuView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly SignalBus _signalBus;

        public MainMenuViewController(ISceneLoadingManager sceneLoadingManager, SignalBus signalBus)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            View.start.OnClickAsObservable().Subscribe(x => OnStart()).AddTo(View.start);
            View.exit.OnClickAsObservable().Subscribe(x => OnExit()).AddTo(View.exit);
        }

        public override void OnShow()
        {
            base.OnShow();
            View.start.Select();
            View.start.OnSelect(null);
        }

        private void OnStart()
        {
            _signalBus.OpenWindow<BlackScreenWindow>(EWindowLayer.Project);
            _signalBus.Fire(new SignalBlackScreen(false, () =>
            {
                _sceneLoadingManager.LoadGameFromMenu();
            }));
        }
        private void OnAbout()
        {
            
        }
        private void OnExit()
        {
            Application.Quit();
        }
    }
}