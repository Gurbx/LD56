using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class VictoryMenu : MonoBehaviour
    {
        [SerializeField] private Image fade;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI text2;
        [SerializeField] private GameObject button;

        private void Start()
        {
            text.transform.localScale = Vector3.zero;
            text2.transform.localScale = Vector3.zero;
            button.transform.localScale = Vector3.zero;

            fade.gameObject.SetActive(true);
            fade.color = new Color(0f, 0f, 0f, 1f);
            fade.DOFade(0f, 0.5f).SetDelay(0.2f).OnComplete(() => fade.gameObject.SetActive(false));
            
            text.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(1.5f);
            text2.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(1.8f);
            button.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(2.5f);
        }

        public void ButtonBack()
        {
            GameController.CurrentLevelIndex = 0;
            
            fade.gameObject.SetActive(true);
            fade.color = new Color(0f, 0f, 0f, 0f);
            fade.DOFade(1f, 0.5f).OnComplete(() => SceneManager.LoadScene("MainMenu", LoadSceneMode.Single));
        }
    }
}