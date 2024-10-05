using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Custom/MobData")]
    public class MobData : ScriptableObject
    {
        public string Name;
        [TextArea] public string Description;
        public int Cost = 100;
        public int Health = 10;
        public int Armor = 0;
        public float Speed = 1f;
        public int MaxUnitSize;
        public int HeartLoss = 1;
        public Mob Prefab;
        public Sprite Icon;
    }
}