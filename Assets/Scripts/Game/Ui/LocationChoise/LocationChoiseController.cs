using System;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Game.SceneLoading;
using Game.Ui.BlackScreen;
using Leopotam.Ecs;
using Services.Input;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Ui.LocationChoise
{
    public class LocationChoiseController : UiController<LocationChoiseView>, IInitializable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly IInputManager _inputManager;
        private readonly SignalBus _signalBus;

        public LocationChoiseController(
            ISceneLoadingManager sceneLoadingManager, IInputManager inputManager,
            SignalBus signalBus)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _inputManager = inputManager;
            _signalBus = signalBus;
        }

        public override void OnShow()
        {
            base.OnShow();
            View.zalupinsk.Select();
            View.zalupinsk.OnSelect(null);
            _inputManager.PlayerEnable(false);
            View.frame1.SetActive(true);
            View.frame2.SetActive(false);
        }

        public void Initialize()
        {
            _inputManager.Actions.UI.Cancel.ObserveEveryValueChanged(x => x.phase).Subscribe(x =>
            {
                if (!IsActive) return;
                if(x == InputActionPhase.Started)
                    OnClose();
            }).AddTo(View);

            View.cancel.OnClickAsObservable().Subscribe(x => OnClose()).AddTo(View.cancel);
            View.zalupinsk.OnClickAsObservable().Subscribe(x => OnLocationChoose()).AddTo(View.zalupinsk);
            View.ebenevo.OnClickAsObservable().Subscribe(x => OnLocationChooseWrong()).AddTo(View.ebenevo);
            View.eblansk.OnClickAsObservable().Subscribe(x => OnLocationChooseWrong()).AddTo(View.eblansk);
            View.pizdyansk.OnClickAsObservable().Subscribe(x => OnLocationChooseWrong()).AddTo(View.pizdyansk);
            View.submit.OnClickAsObservable().Subscribe(x => OnLocationChoose()).AddTo(View.submit);
        }

        private void OnLocationChooseWrong()
        {
            View.frame1.SetActive(false);
            View.frame2.SetActive(true);
            View.submit.Select();
            View.submit.OnSelect(null);
        }

        private void OnLocationChoose()
        {
            _signalBus.BackWindow();
            _signalBus.OpenWindow<BlackScreenWindow>(EWindowLayer.Project);
            _signalBus.Fire(new SignalBlackScreen(false, () =>
            {
                _sceneLoadingManager.LoadGameScene("Zalupinsk");
                _inputManager.PlayerEnable(true);
            }));
        }

        private void OnClose()
        {
            _signalBus.BackWindow();
            _inputManager.PlayerEnable(true);
        }
    }
}