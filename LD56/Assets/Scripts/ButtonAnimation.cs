using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Button))]
    public class ButtonAnimation : MonoBehaviour
    {
        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(AnimateButton);
        }

        private void AnimateButton()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(0.8f, 0.05f)).SetEase(Ease.OutSine);
            sequence.Append(transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack));
            sequence.Play();
        }
    }
}