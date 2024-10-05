using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cam;

        private static CinemachineBasicMultiChannelPerlin _noise;
        private static float _timer;
        
        private void Awake()
        {
            _noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = 0;
                _noise.m_AmplitudeGain = 0;
                _noise.m_FrequencyGain = 0;
            }
        }

        public static void ScreenShake(float amplitude, float frequency, float duration)
        {
            if (amplitude < _noise.m_AmplitudeGain || frequency < _noise.m_FrequencyGain) return;
            
            _noise.m_AmplitudeGain = amplitude;
            _noise.m_FrequencyGain = frequency;
            _timer = duration;
        }
    }
}