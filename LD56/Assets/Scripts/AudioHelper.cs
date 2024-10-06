using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class AudioHelper : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip[] buttonSounds;
        [SerializeField] private AudioClip[] buttonSounds2;
        [SerializeField] private AudioClip[] buttonSounds3;
        
        public static AudioHelper Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void PlayButtonSound()
        {
            var clip = buttonSounds[Random.Range(0, buttonSounds.Length)];
            source.clip = clip;
            source.Play();
        }
        
        public void PlayButtonSound2()
        {
            var clip = buttonSounds2[Random.Range(0, buttonSounds2.Length)];
            source.clip = clip;
            source.Play();
        }

        
        public void PlayButtonSound3()
        {
            var clip = buttonSounds3[Random.Range(0, buttonSounds3.Length)];
            source.clip = clip;
            source.Play();
        }
    }
}