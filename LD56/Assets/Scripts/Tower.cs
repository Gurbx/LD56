using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float range;
        [SerializeField] private int damage;
        [SerializeField] private float cooldown;
        [SerializeField] private Bullet projectilePrefab;
        
        private bool _isActive;
        private float _timer;

        public void Acitvate()
        {
            _isActive = true;
        }

        private void Update()
        {
            if (!_isActive)
                return;

            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Fire();
            }
        }

        private void Fire()
        {
            var mobs = GameController.Instance.ActiveMobs;

            if (mobs == null)
            {
                _timer = cooldown;
                return;
            }

            if (mobs.Count <= 0)
            {
                _timer = cooldown;
                return;
            }
            
            (Mob mob, float distance) closestMob = new(null, float.MaxValue);
            
            foreach (var mob in mobs)
            {
                var distance = Vector3.Distance(transform.position, mob.transform.position);
                if (distance < closestMob.distance)
                {
                    closestMob.mob = mob;
                    closestMob.distance = distance;
                }
            }

            if (closestMob.distance > range)
            {
                _timer = 0.1f;
                return;
            }

            if (closestMob.mob != null)
            {
                var bullet = Instantiate(projectilePrefab, transform);
                bullet.gameObject.SetActive(true);
                float duration = closestMob.distance / 20f;
                bullet.Spawn(duration);
                
                bullet.transform.DOMove(closestMob.mob.transform.position, duration).SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        closestMob.mob.Damage(damage);
                        Destroy(bullet.gameObject);
                    });
                
                animator.SetTrigger($"Fire");
            }

            _timer = cooldown;
        }
    }
}