using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private GameObject fade;


        private void Start()
        {
            foreach (var md in availableMobs)
            {
                var mb = Instantiate(mobButtonPrefab, mobButtonContainer);
                mb.onClick.AddListener((() => MobButtonPressed(md)));
                mb.gameObject.SetActive(true);
            }
        }

        private void MobButtonPressed(MobData mobData)
        {
            fade.SetActive(true);
            buyMobWindow.gameObject.SetActive(true);
            buyMobWindow.Show(mobData);
        }
    }
}
