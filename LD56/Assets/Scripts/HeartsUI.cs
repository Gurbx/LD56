using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class HeartsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI heartsText;
        [SerializeField] private Image icon;
        [SerializeField] private Sprite redHeart, greenHeart;

        private void Start()
        {
            GameController.Instance.HeartsUpdated += OnHeartsUpdated;
        }

        private void OnHeartsUpdated()
        {
            heartsText.text = GameController.Instance.Hearts.ToString();
            
            heartsText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            heartsText.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBounce);
            icon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            icon.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBounce);

            icon.sprite = GameController.Instance.Hearts > 0 ? redHeart : greenHeart;
        }

        private void OnDestroy()
        {
            GameController.Instance.HeartsUpdated -= OnHeartsUpdated;
        }
    }
}