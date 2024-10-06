using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        //[SerializeField] private int startingGold;
        [SerializeField] private Level[] levels;
        
        [Header("Statics")]
        [SerializeField] private Transform mobContainer;
        [SerializeField] private GameOver gameOver;
        [SerializeField] private LevelTransition levelTransition;
        [SerializeField] private WaveUI waveUi;
        
        public static GameController Instance { get; private set; }

        public int Gold { get; private set; }
        public int Hearts { get; private set; }
        public List<(MobData mob, int amount)> MobWave { get; private set; }
        public List<Mob> ActiveMobs { get; private set; }
        public List<MobData> AvailableMobs { get; private set; }
        
        public Action GoldAmountChanged;
        public Action MobWaveUpdated;
        public Action HeartsUpdated;

        public static int CurrentLevelIndex;
        private Level _level;
        
        private void Awake()
        {
            if (Instance != null)
                return;
            
            Instance = this;
        }

        private void Start()
        {
            ResetLevel();
        }

        public void ResetLevel()
        {
            if (_level != null)
                Destroy(_level.gameObject);
            
            _level = Instantiate(levels[CurrentLevelIndex]);
            Gold = _level.Gold;
            Hearts = _level.Hearts;
            MobWave?.Clear();
            MobWave = new List<(MobData mob, int amount)>();
            MobWaveUpdated?.Invoke();
            GoldAmountChanged?.Invoke();
            HeartsUpdated?.Invoke();
            waveUi.Show();
            _isGameOver = false;
            AvailableMobs = _level.AvailableMobs;
            
            foreach (Transform child in mobContainer)
            {
                child.DOKill(child);
                Destroy(child.gameObject);
            }
        }

        public void AddMob(MobData mobData, int amount)
        {
            MobWave ??= new List<(MobData mob, int amount)>();
            MobWave.Add(new (mobData, amount));
            MobWaveUpdated?.Invoke();
        }

        public void LaunchWave()
        {
            foreach (Transform tower in _level.TowerContainer)
                tower.GetComponent<Tower>().Acitvate();
            
            StartCoroutine(SpawnMobs());
        }
        
        private IEnumerator SpawnMobs()
        {
            ActiveMobs = new List<Mob>();
            
            var path = _level.GetPathCoords();
            
            foreach (var m in MobWave)
            {
                for (int i = 0; i < m.amount; i++)
                {
                    var mob = Instantiate(m.mob.Prefab, mobContainer);
                    mob.Spawn(m.mob, path[0], path);
                    ActiveMobs.Add(mob);
                    yield return new WaitForSeconds(0.25f);
                }

                yield return new WaitForSeconds(0.75f);
            }
        }

        public void RemoveMob(Mob mob)
        {
            ActiveMobs.Remove(mob);
            if (ActiveMobs.Count <= 0 && !_isGameOver)
            {
                _isGameOver = true;
                Invoke("GameOver", 1f);
            }
        }

        public void MobReachedEnd(int heartLoss, Mob mob)
        {
            Hearts -= heartLoss;
            if (Hearts <= 0)
                Hearts = 0;
            
            HeartsUpdated?.Invoke();
            RemoveMob(mob);
        }

        private bool _isGameOver;
        private void GameOver()
        {
            if (Hearts > 0)
            {
                gameOver.TriggerGameOver();
                return;
            }
            if (CurrentLevelIndex+1 < levels.Length)
            {
                CurrentLevelIndex++;

                bool showMobUnlock = false || AvailableMobs.Count < levels[CurrentLevelIndex].AvailableMobs.Count;
                if (showMobUnlock)
                {
                    UnlockMenu.MobData = levels[CurrentLevelIndex].AvailableMobs[^1];
                }
                levelTransition.TransitionLevel(false, showMobUnlock);
            }
            else
            {
                levelTransition.TransitionLevel(true, false);
            }
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