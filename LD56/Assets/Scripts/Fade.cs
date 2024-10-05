using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private MobShop shopMenu;
        [SerializeField] private BuyMobWindow mobMenu;
        [SerializeField] private GameObject fade;
        
        public void OnPress()
        {
            if (mobMenu.gameObject.activeSelf)
            {
                shopMenu.Show();
                mobMenu.Hide();
            }
            else if (shopMenu.gameObject.activeSelf)
            {
                shopMenu.Hide();
                mobMenu.Hide();
                fade.SetActive(false);
            }
        }
    }
}
