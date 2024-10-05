using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ResourcesUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldAmountText;
        
        private void Awake()
        {
            GameController.Instance.GoldAmountChanged += OnGoldAmountChanged;
        }

        private void OnGoldAmountChanged()
        {
            goldAmountText.text = GameController.Instance.Gold.ToString();
            goldAmountText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            goldAmountText.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBounce);
        }

        private void OnDestroy()
        {
            GameController.Instance.GoldAmountChanged -= OnGoldAmountChanged;
        }
    }
}