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
        [SerializeField] private TextMeshProUGUI heartLoss;
        [SerializeField] private TextMeshProUGUI textGroupSize;
        [SerializeField] private TextMeshProUGUI textArmor;
        [Space]
        [SerializeField] private TextMeshProUGUI textPurchaseButtonAmount;
        [SerializeField] private TextMeshProUGUI textPurchaseButtonCost;

        private int _amount;
        private MobData _mobData;

        private readonly Color zeroColor = new Color(1f, 1f, 1, 0.25f);
        
        public void Show(MobData mobData)
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.DOScale(1f, 0.1f).SetEase(Ease.OutSine);

            _amount = 1;
            _mobData = mobData;
            
            textName.text = mobData.Name;
            textDescription.text = mobData.Description;
            textCost.text = $"Cost: " + mobData.Cost.ToString();
            textHealth.text = $"Health: " + mobData.Health.ToString();
            textSpeed.text = $"Speed: " + mobData.Speed.ToString();
            heartLoss.text = $"Sugar: " + mobData.HeartLoss.ToString();
            textGroupSize.text = $"Group Size: " + mobData.MaxUnitSize.ToString();

            if (mobData.Armor <= 0)
                textArmor.color = zeroColor;
            else if (mobData.Armor >= 1)
                textArmor.color = Color.green;
            else 
                textArmor.color = Color.white;
            
            if (mobData.HeartLoss <= 0)
                heartLoss.color = zeroColor;
            else if (mobData.HeartLoss > 1)
                heartLoss.color = Color.green;
            else
                heartLoss.color = Color.white;
            
                
            textArmor.text = $"Armor: " + mobData.Armor.ToString();
            
            UpdatePurchaseButton();
        }

        private void UpdatePurchaseButton()
        {
            textPurchaseButtonAmount.text = $"Purchase x{_amount}";
            textPurchaseButtonCost.text = (_mobData.Cost * _amount).ToString();
            textPurchaseButtonCost.color = GameController.Instance.Gold < _mobData.Cost * _amount ? Color.red : Color.white;
        }

        public void Hide()
        {
            transform.DOScale(0f, 0.1f).SetEase(Ease.InSine).OnComplete(() => gameObject.SetActive(false));
        }

        public void ButtonBuy()
        {
            var cost = _mobData.Cost * _amount;
            if (GameController.Instance.SpendGold(cost))
            {
                GameController.Instance.AddMob(_mobData, _amount);
                UpdatePurchaseButton();
            }
        }

        public void ButtonIncreaseAmount()
        {
            _amount++;
            if (_amount >= _mobData.MaxUnitSize)
                _amount = _mobData.MaxUnitSize;
            UpdatePurchaseButton();
        }

        public void ButtonDecreaseAmount()
        {
            _amount--;
            if (_amount <= 1)
                _amount = 1;
            UpdatePurchaseButton();
        }
    }
}
