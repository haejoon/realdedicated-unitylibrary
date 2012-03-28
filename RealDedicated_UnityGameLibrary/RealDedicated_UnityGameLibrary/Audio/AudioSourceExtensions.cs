using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public static class AudioSourceExtensions
    {
        public static void playClip(this AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public static void playRandomClip(this AudioSource audioSource, AudioClip[] audioClips)
        {
            int clipIndex = UnityEngine.Random.Range(0, audioClips.Length);
            audioSource.playClip(audioClips[clipIndex]);
        }
    }
}
