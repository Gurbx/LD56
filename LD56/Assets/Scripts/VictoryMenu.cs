using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class VictoryMenu : MonoBehaviour
    {
        [SerializeField] private Image fade;
        
        public void ButtonBack()
        {
            GameController.CurrentLevelIndex = 0;
            
            fade.gameObject.SetActive(true);
            fade.color = new Color(0f, 0f, 0f, 0f);
            fade.DOFade(1f, 0.5f).OnComplete(() => SceneManager.LoadScene("MainMenu", LoadSceneMode.Single));
        }
    }
}