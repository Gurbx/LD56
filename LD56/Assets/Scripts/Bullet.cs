using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject sprite;

        public void Spawn(float duration)
        {
            /*
            var sequence = DOTween.Sequence();
            sequence.Append(sprite.transform.DOLocalMove(new Vector3(0, 2f, 0), duration*0.5f)).SetEase(Ease.InQuad);
            sequence.Append(sprite.transform.DOLocalMove(new Vector3(0, 0, 0), duration*0.5f)).SetEase(Ease.OutQuad);
            sequence.Play();
            */
        }
    }
}