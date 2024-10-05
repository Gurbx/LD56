using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class WaveUI : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private Image iconPrefab;
        [SerializeField] private Button fightButton;
        [SerializeField] private Transform mainContainer;
        [SerializeField] private Transform shopContainer;
        
        private void Start()
        {
            GameController.Instance.MobWaveUpdated += OnWavesUpdated;
        }

        private void OnWavesUpdated()
        {
            foreach (Transform child in container)
            {
                Destroy(child.gameObject);
            }

            float delayPer = 0.025f;
            float delay = GameController.Instance.MobWave.Count * delayPer;
            foreach (var mw in GameController.Instance.MobWave)
            {
                var icon = Instantiate(iconPrefab, container);
                icon.transform.GetChild(0).GetComponent<Image>().sprite = mw.mob.Icon;
                icon.GetComponentInChildren<TextMeshProUGUI>().text = $"x{mw.amount}";
                icon.transform.localScale = Vector3.zero;
                icon.gameObject.SetActive(true);
                icon.transform.SetSiblingIndex(0);
                icon.transform.DOScale(1, 0.15f).SetEase(Ease.OutBounce).SetDelay(delay);
                delay -= delayPer;
                if (delay <= 0)
                    delay = 0;
            }
        }

        public void ButtonAttack()
        {
            fightButton.interactable = false;
            GameController.Instance.LaunchWave();
            mainContainer.DOLocalMove(new Vector3(0, -1000, 0), 0.5f).SetEase(Ease.InSine).SetDelay(0.5f);
            shopContainer.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            GameController.Instance.MobWaveUpdated -= OnWavesUpdated;
        }
    }
}