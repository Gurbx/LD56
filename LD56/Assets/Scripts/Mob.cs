using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class Mob : MonoBehaviour
    { 
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
            if (_health <= 0)
            {
                _health = 0;
                GameController.Instance.RemoveMob(this);
                transform.DOKill();
                transform.DOShakeScale(0.5f);
                Destroy(gameObject, 0.6f);
            }
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
