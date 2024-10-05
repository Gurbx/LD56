using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int startingGold;
        [SerializeField] private Level level;
        
        [Header("Statics")]
        [SerializeField] private Transform mobContainer;
        [SerializeField] private Transform towerContainer;
        
        public static GameController Instance { get; private set; }

        public int Gold { get; private set; }
        public List<(MobData mob, int amount)> MobWave { get; private set; }
        public List<Mob> ActiveMobs { get; private set; }
        
        public Action GoldAmountChanged;
        public Action MobWaveUpdated;
        
        private void Awake()
        {
            if (Instance != null)
                return;
            
            Instance = this;
        }

        private void Start()
        {
            Gold = startingGold;
            GoldAmountChanged?.Invoke();
        }

        public void AddMob(MobData mobData, int amount)
        {
            MobWave ??= new List<(MobData mob, int amount)>();
            MobWave.Add(new (mobData, amount));
            MobWaveUpdated?.Invoke();
        }

        public void LaunchWave()
        {
            foreach (Transform tower in towerContainer)
                tower.GetComponent<Tower>().Acitvate();
            
            StartCoroutine(SpawnMobs());
        }
        
        private IEnumerator SpawnMobs()
        {
            ActiveMobs = new List<Mob>();
            
            var path = level.PathCoords;
            
            foreach (var m in MobWave)
            {
                for (int i = 0; i < m.amount; i++)
                {
                    var mob = Instantiate(m.mob.Prefab, mobContainer);
                    mob.Spawn(m.mob, level.MobSpawnPoint, path);
                    ActiveMobs.Add(mob);
                    yield return new WaitForSeconds(0.25f);
                }

                yield return new WaitForSeconds(1f);
            }
        }

        public void RemoveMob(Mob mob)
        {
            ActiveMobs.Remove(mob);
        }
        
        //---- Gold

        public bool SpendGold(int amount)
        {
            if (amount <= 0)
                return false;
            if (Gold < amount)
                return false;
            Gold -= amount;
            GoldAmountChanged?.Invoke();
            return true;
        }

        public void AddGold(int amount)
        {
            if (amount <= 0)
                return;
            Gold += amount;
            GoldAmountChanged?.Invoke();
        }
    }
}