using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

namespace SoundEffectsPlayer.Internal
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    public class AudioSourcePlayer : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            _instance = new GameObject(nameof(AudioSourcePlayer)).AddComponent<AudioSourcePlayer>();
            _instance._defaultAudioSource = _instance.gameObject.AddComponent<AudioSource>();
        }
        static AudioSourcePlayer _instance;
        private AudioSource _defaultAudioSource;
        private readonly Dictionary<ResourcesAudioFile, AudioClip> _cache = new Dictionary<ResourcesAudioFile, AudioClip>();

        public static void Play(ResourcesAudioFile audioFile)
        {
            if(_instance._cache.ContainsKey(audioFile))
            {
                _instance._defaultAudioSource.PlayOneShot(_instance._cache[audioFile]);
                return;
            }
            var resource= Resources.Load<AudioClip>($"Sounds/{audioFile}");
            _instance._cache.Add(audioFile, resource);
            _instance._defaultAudioSource.PlayOneShot(resource);
        }
        public static void SetAudioMixerGroup(AudioMixerGroup audioMixerGroup)
        {
            _instance._defaultAudioSource.outputAudioMixerGroup = audioMixerGroup;
        }
    }
}