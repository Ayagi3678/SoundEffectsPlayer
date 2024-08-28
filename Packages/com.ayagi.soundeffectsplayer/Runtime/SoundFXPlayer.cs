using SoundEffectsPlayer.Internal;
using UnityEngine.Audio;

namespace SoundEffectsPlayer
{
    public static class SoundFXPlayer
    {
        public static void Play(ResourcesAudioFile audioFile)
        {
            AudioSourcePlayer.Play(audioFile);
        }
        public static void SetAudioMixerGroup(AudioMixerGroup audioMixerGroup)
        {
            AudioSourcePlayer.SetAudioMixerGroup(audioMixerGroup);
        }
    }
}