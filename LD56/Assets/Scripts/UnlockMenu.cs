using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    public class UnlockMenu : MonoBehaviour
    {
        public static MobData MobData;

        [SerializeField] private Image fade;
        [SerializeField] private MobData testMobData;
        [SerializeField] private TextMeshProUGUI unlockText;
        [SerializeField] private Image icon;
        [SerializeField] private GameObject button;

        private void Start()
        {
            if (MobData == null)
                MobData = testMobData;

            unlockText.text = $"{MobData.Name} Unlocked!";
            icon.sprite = MobData.Icon;

            unlockText.transform.localScale = Vector3.zero;
            icon.transform.localScale = Vector3.zero;
            button.transform.localScale = Vector3.zero;

            fade.gameObject.SetActive(true);
            fade.color = new Color(0f, 0f, 0f, 1f);
            fade.DOFade(0f, 0.5f).SetDelay(0.2f).OnComplete(() => fade.gameObject.SetActive(false));
            
            unlockText.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(1.5f);
            icon.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(1.75f);
            button.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2.5f);
        }

        public void ButtonContinuePressed()
        {
            fade.gameObject.SetActive(true);
            fade.color = new Color(0f, 0f, 0f, 0f);
            unlockText.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack);
            icon.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack);
            button.transform.DOScale(0, 0.3f).SetEase(Ease.OutBack);
            
            fade.DOFade(1f, 0.5f).OnComplete(() => SceneManager.LoadScene("SampleScene", LoadSceneMode.Single));
        }
    }
}