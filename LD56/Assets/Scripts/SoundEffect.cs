using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private AudioSource source;
        [SerializeField] private bool playOnAwake;
        [SerializeField] private float minPitch;
        [SerializeField] private float maxPitch;

        private void Awake()
        {
            if (!playOnAwake)
                return;
            
            Play();
        }

        public void Play()
        {
            var clip = clips[Random.Range(0, clips.Length)];
            source.clip = clip;
            source.pitch = Random.Range(minPitch, maxPitch);
            source.Play();
        }
    }
}
