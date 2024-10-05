using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private GameObject sprite;
        [SerializeField] private GameObject hitEffectPrefab;
        [SerializeField] private GameObject deathEffectPrefab;
        [SerializeField] private GameObject hpBar;
        [SerializeField] private GameObject hpBarFill;
        
        private List<Vector3> _pathCoords;
        private MobData _mobData;
        private int _currentPathIndex;
        private int _health;
        private float _speed;
        
        public void Spawn(MobData mobData, Vector3 spawnCoords, List<Vector3> path)
        {
            _mobData = mobData;
            _pathCoords = path;
            _currentPathIndex = 0;
            transform.position = new Vector2(spawnCoords.x, spawnCoords.y);
            _health = _mobData.Health;
            _speed = _mobData.Speed;
            CheckPointReached();
        }

        public void Damage(int damage)
        {
            _health -= damage;

            if (damage > 0)
            {
                hpBar.SetActive(true);
            }
            
            if (_health <= 0)
            {
                _health = 0;
                GameController.Instance.RemoveMob(this);
                transform.DOKill();
                sprite.transform.DOScale(0f, 0.3f).SetEase(Ease.InBounce);
                Destroy(gameObject, 0.6f);
                var deathEffect = Instantiate(deathEffectPrefab, transform.parent);
                deathEffect.transform.position = transform.position;
                deathEffect.SetActive(true);
                Destroy(deathEffect, 15f);
                CameraHandler.ScreenShake(3f, 1f, 0.15f);
            }
            else
            {
                CameraHandler.ScreenShake(1.5f, 0.5f, 0.1f);
                var hitEffect = Instantiate(hitEffectPrefab, transform.parent);
                hitEffect.transform.position = transform.position;
                hitEffect.SetActive(true);
                Destroy(hitEffect, 15f);
            }

            hpBarFill.transform.localScale = new Vector3(( _health/(float)_mobData.Health), 1f, 1f);
        }
        
        private void CheckPointReached()
        {
            if (_currentPathIndex >= _pathCoords.Count)
            {
                //End reached
                return;
            }
            
            var distanceToNext = Vector3.Distance(transform.position, _pathCoords[_currentPathIndex]);
            float durationToNext = distanceToNext / _speed;
            
            transform.DOMove(_pathCoords[_currentPathIndex], durationToNext).SetEase(Ease.Linear)
                .OnComplete(() => CheckPointReached());
            _currentPathIndex++;
        }
        
    }
}
