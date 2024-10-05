using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cost;
        [SerializeField] private Image icon;

        public void Init(MobData md)
        {
            cost.text = md.Cost.ToString();
            icon.sprite = md.Icon;
        }
    }
}
