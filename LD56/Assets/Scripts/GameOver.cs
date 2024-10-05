using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Image fade;
        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private GameObject retryButton;
        
        public void TriggerGameOver()
        {
            fade.gameObject.SetActive(true);
            fade.color = new Color(0f, 0f, 0f, 0f);
            fade.DOFade(0.75f, 1f);

            gameOverText.color = new Color(1f, 1f, 1f, 0f);
            gameOverText.DOFade(1, 1f).SetDelay(1f);
            
            retryButton.gameObject.SetActive(true);
            retryButton.transform.localScale = Vector3.zero;
            retryButton.transform.DOScale(1f, 0.5f).SetDelay(2f);
        }

        public void ButtonRetry()
        {
            //TODO
        }
    }
}