using System;
using Editor;
using SoundEffectsPlayer;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup soundFXAudioMixerGroup;
        private void Start()
        {
            SoundFXPlayer.SetAudioMixerGroup(soundFXAudioMixerGroup);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}