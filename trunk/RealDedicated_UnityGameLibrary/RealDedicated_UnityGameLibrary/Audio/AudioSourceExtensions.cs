using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace RealDedicated_UnityGameLibrary
{
    public static class AudioSourceExtensions
    {
        public static void playClip(this AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public static IEnumerator playClip(this AudioSource audioSource, AudioClip audioClip, Action onComplete)
        {
            audioSource.playClip(audioClip);

            while (audioSource.isPlaying)
                yield return null;

            onComplete();
        }

        public static void playRandomClip(this AudioSource audioSource, AudioClip[] audioClips)
        {
            int clipIndex = UnityEngine.Random.Range(0, audioClips.Length);
            audioSource.playClip(audioClips[clipIndex]);
        }

        public static IEnumerator playRandomClip(this AudioSource audioSource, AudioClip[] audioClips, Action onComplete)
        {
            int clipIndex = UnityEngine.Random.Range(0, audioClips.Length);
            audioSource.playClip(audioClips[clipIndex]);

            while (audioSource.isPlaying)
                yield return null;

            onComplete();
        }
    }
}
