using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class MobShop : MonoBehaviour
    {
        [SerializeField] private List<MobData> availableMobs;
        [SerializeField] private Button mobButtonPrefab;
        [SerializeField] private Transform mobButtonContainer;
        [SerializeField] private BuyMobWindow buyMobWindow;


        private void Start()
        {
            foreach (var md in availableMobs)
            {
                var mb = Instantiate(mobButtonPrefab, mobButtonContainer);
                mb.onClick.AddListener((() => MobButtonPressed(md)));
                mb.GetComponent<ShopButton>().Init(md);
                mb.gameObject.SetActive(true);
            }
        }

        public void Show()
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.DOScale(1f, 0.1f).SetEase(Ease.OutSine);
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            transform.DOScale(0f, 0.1f).SetEase(Ease.InSine).OnComplete(() => gameObject.SetActive(false));
        }

        private void MobButtonPressed(MobData mobData)
        {
            Hide();
            buyMobWindow.gameObject.SetActive(true);
            buyMobWindow.Show(mobData);
        }
    }
}
