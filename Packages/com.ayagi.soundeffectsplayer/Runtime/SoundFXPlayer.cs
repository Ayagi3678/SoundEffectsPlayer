using SoundEffectsPlayer.Internal;
using UnityEngine.Audio;

namespace SoundEffectsPlayer
{
    public static class SoundFXPlayer
    {
        public static bool PitchTimeScaling
        {
            get => AudioSourcePlayer.PitchTimeScaling;
            set => AudioSourcePlayer.SetPitchTimeScaling(value);
        }
        public static void Play(ResourcesAudioFile audioFile, float volume = 1)
        {
            AudioSourcePlayer.Play(audioFile, volume);
        }
        public static void SetAudioMixerGroup(AudioMixerGroup audioMixerGroup)
        {
            AudioSourcePlayer.SetAudioMixerGroup(audioMixerGroup);
        }
    }
}