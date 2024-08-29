using System;
using SoundEffectsPlayer;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup soundFXAudioMixerGroup;
        private void Start()
        {
            SoundFXPlayer.SetAudioMixerGroup(soundFXAudioMixerGroup);
        }
    }
}