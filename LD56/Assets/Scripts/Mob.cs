using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private int health = 10;
        [SerializeField] private float speed = 1f;
        [SerializeField] private List<Vector3> _pathCoords;
        
        private int _currentPathIndex;
        private int _health;

        private void Start()
        {
            Spawn(transform.position);
        }

        public void Damage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
                _health = 0;
        }
        
        public void Spawn(Vector3 spawnCoords)
        {
            _currentPathIndex = 0;
            transform.position = new Vector2(spawnCoords.x, spawnCoords.y);
            _health = health;
            CheckPointReached();
        }

        private void CheckPointReached()
        {
            if (_currentPathIndex >= _pathCoords.Count)
            {
                //End reached
                return;
            }
            
            var distanceToNext = Vector3.Distance(transform.position, _pathCoords[_currentPathIndex]);
            float durationToNext = distanceToNext / speed;
            
            transform.DOMove(_pathCoords[_currentPathIndex], durationToNext).SetEase(Ease.Linear)
                .OnComplete(() => CheckPointReached());
            _currentPathIndex++;
        }
        
    }
}
