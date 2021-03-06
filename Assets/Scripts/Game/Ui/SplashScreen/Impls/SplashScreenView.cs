using System;
using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.Video;

namespace Game.Ui.SplashScreen.Impls
{
    public class SplashScreenView : UiView
    {
        [SerializeField] private VideoPlayer player;

        public void CompleteClip(Action OnComplete)
        {
            player.loopPointReached += x => OnComplete?.Invoke();
        }
    }
}