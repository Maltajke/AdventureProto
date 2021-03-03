using System;
using DG.Tweening;
using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.BlackScreen
{
    public class BlackScreenView : UiView
    {
        [SerializeField] private Image image;

        public void Show(Action complete, bool open, float duration)
        {
            var color = open ? Color.black : Color.clear;
            image.color = color;
            image.DOFade(open ? 0 : 1, duration)
                .OnComplete(() => complete?.Invoke());
        }
    }
}