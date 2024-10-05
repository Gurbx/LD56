using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class BuyMobWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private TextMeshProUGUI textDescription;
        [Space]
        [SerializeField] private TextMeshProUGUI textCost;
        [SerializeField] private TextMeshProUGUI textHealth;
        [SerializeField] private TextMeshProUGUI textSpeed;
        [SerializeField] private TextMeshProUGUI textArmor;
        [Space]
        [SerializeField] private TextMeshProUGUI textPurchaseButtonAmount;
        [SerializeField] private TextMeshProUGUI textPurchaseButtonCost;

        private int _amount;
        
        public void Show(MobData mobData)
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.DOScale(1f, 0.1f).SetEase(Ease.OutSine);
            
            textName.text = mobData.Name;
            textDescription.text = mobData.Description;
            textCost.text = $"Cost: " + mobData.Cost.ToString();
            textHealth.text = $"Health: " + mobData.Health.ToString();
            textSpeed.text = $"Speed: " + mobData.Speed.ToString();
            
            if (mobData.Armor <= 0) textArmor.transform.parent.gameObject.SetActive(false);
            else textArmor.text = $"Armor: " + mobData.Armor.ToString();
        }

        public void Hide()
        {
            transform.DOScale(0f, 0.1f).SetEase(Ease.InSine).OnComplete(() => gameObject.SetActive(false));
        }

        public void ButtonBuy()
        {
            
        }

        public void ButtonIncreaseAmount()
        {
            
        }

        public void ButtonDecreaseAmount()
        {
            
        }
    }
}
