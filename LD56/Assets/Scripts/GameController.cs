using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Level level;
        
        [Header("Statics")]
        [SerializeField] private Transform mobContainer;
        
        public static GameController Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this;
        }

        public IEnumerator SpawnMobs(List<(Mob mob, int amount)> mobs)
        {
            foreach (var m in mobs)
            {
                for (int i = 0; i < m.amount; i++)
                {
                    var mob = Instantiate(m.mob, mobContainer);
                    mob.Spawn(level.MobSpawnPoint);
                    yield return new WaitForSeconds(0.1f);
                }

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}