using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void TransitionLevel(bool goToEndScreen, bool showMobUnlock)
        {
            image.gameObject.SetActive(true);
            image.color = new Color(0f, 0f, 0f, 0f);
            if (showMobUnlock)
            {
                image.DOFade(1f, 0.5f).OnComplete(() =>  SceneManager.LoadScene("UnlockScene", LoadSceneMode.Single));
            }
            if (goToEndScreen)
            {
                image.DOFade(1f, 0.5f).OnComplete(() =>  SceneManager.LoadScene("VictoryScreen", LoadSceneMode.Single));
            }
            else
            {
                image.DOFade(1f, 0.5f).OnComplete(() => GameController.Instance.ResetLevel());
                image.DOFade(0, 0.5f).SetDelay(0.6f).OnComplete(() => image.gameObject.SetActive(false));
            }
        }
    }
}