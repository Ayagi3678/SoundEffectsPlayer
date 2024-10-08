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
            if(_instance != null) return;
            _instance = new GameObject(nameof(AudioSourcePlayer)).AddComponent<AudioSourcePlayer>();
            _defaultAudioSource = _instance.gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(_instance.gameObject);
        }
        static AudioSourcePlayer _instance;
        private static AudioSource _defaultAudioSource;
        private readonly Dictionary<ResourcesAudioFile, AudioClip> _cache = new Dictionary<ResourcesAudioFile, AudioClip>();
        private bool _pitchTimeScaling;
        public static void Play(ResourcesAudioFile audioFile,float volume)
        {
            if(_instance._cache.ContainsKey(audioFile))
            {
                _defaultAudioSource.PlayOneShot(_instance._cache[audioFile],volume);
                return;
            }
            var resource= Resources.Load<AudioClip>($"Sounds/{audioFile}");
            _instance._cache.Add(audioFile, resource);
            _defaultAudioSource.PlayOneShot(resource,volume);
        }
        public static void SetAudioMixerGroup(AudioMixerGroup audioMixerGroup)
        {
            _defaultAudioSource.outputAudioMixerGroup = audioMixerGroup;
        }
        public static void SetPitchTimeScaling(bool pitchTimeScaling)
        {
            _instance._pitchTimeScaling = pitchTimeScaling;
        }
        public static bool PitchTimeScaling => _instance._pitchTimeScaling;
        private void Update()
        {
            if(_pitchTimeScaling)
            {
                _defaultAudioSource.pitch = Time.timeScale;
            }
        }
    }
}