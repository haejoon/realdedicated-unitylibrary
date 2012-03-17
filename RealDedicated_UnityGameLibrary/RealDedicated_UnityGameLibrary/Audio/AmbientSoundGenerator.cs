
using System.Collections.Generic;
using UnityEngine;


namespace RealDedicated_UnityGameLibrary.Audio
{
    [RequireComponent(typeof(AudioSource))]
    class AmbientSoundGenerator : MonoBehaviour
    {
        // Set true if the GO has a collider being used as a trigger
        [UnityEngine.SerializeField]
        private bool isUsingTrigger { get; set; }
        
        [UnityEngine.SerializeField]
        private bool oneShotOnTimer { get; set; }

        [UnityEngine.SerializeField]
        private bool oneShotRepeat { get; set; }

        [UnityEngine.SerializeField]
        private float oneShotTime = 0.0f;

        [UnityEngine.SerializeField]
        private AudioClip oneShotSound = null;

        // Not sure what im doing with this.
        //[UnityEngine.SerializeField]
        //private Collider triggerArea = null;

        [UnityEngine.SerializeField]
        private static int onEnterSoundCount = 0;
        
        [UnityEngine.SerializeField]
        private AudioClip[] onEnterSoundList = new AudioClip[onEnterSoundCount];

        [UnityEngine.SerializeField]
        private static int onStaySoundCount = 0;

        [UnityEngine.SerializeField]
        private AudioClip[] onStaySoundList = new AudioClip[onStaySoundCount];

        [UnityEngine.SerializeField]
        private static int onExitSoundCount = 0;

        [UnityEngine.SerializeField]
        private AudioClip[] onExitSoundList = new AudioClip[onExitSoundCount];

        // Property governing additional logic for situations where the OnTriggerStay functionality is wanted.
        [UnityEngine.SerializeField]
        private bool hasOnStay { get; set; }

        [UnityEngine.SerializeField]
        private bool useTriggerDelay { get; set; }

        [UnityEngine.SerializeField]
        private float triggerDelay = 0.0f;
              
        // Not sure what im doing with this.
        //[UnityEngine.SerializeField]
        //private float actionTimer = 0.0f;

        [UnityEngine.SerializeField]
        private bool actionPlay { get; set; }        

        [UnityEngine.SerializeField]
        private bool actionReverse { get; set; }

        [UnityEngine.SerializeField]
        private bool actionRepeat { get; set; }

        [UnityEngine.SerializeField]
        private bool randomSound { get; set; }

        private float startTime = 0.0f;

        private float triggerTime = 0.0f;

        private bool triggerCalled = false;

        private AudioSource audio;

        private AudioClip[] current;

        private void Create() { }

        private void Start() { }

        private void Awake() 
        {
            audio = this.gameObject.GetComponent<AudioSource>();
            startTime = Time.time;
        }

        private void Update()
        {
            if (oneShotOnTimer)
            {
                if (Time.time - startTime < oneShotTime)
                {
                    if (oneShotSound != null)
                    {
                        audio.clip = oneShotSound;
                        audio.Play();
                        if (oneShotRepeat)
                        {
                            startTime = Time.time;
                        }
                    }
                }
            }

            UpdateDelay();
        }

        #region Triggers
        private void OnTriggerEnter(Collider other)
        {
            if (!oneShotOnTimer)
            {
                if (isUsingTrigger)
                {
                    if (useTriggerDelay)
                    {
                        if (onEnterSoundCount > 0)
                            TriggerDelay(onEnterSoundList);
                    }
                    else
                    {
                        if (randomSound)
                        {
                            if (onEnterSoundCount > 0)
                            {
                                PlayRandomSound(onEnterSoundList);
                            }
                        }
                        else
                        {
                            if (onEnterSoundCount > 0)
                            {
                                PlayNextSound(onEnterSoundList);
                            }
                        }
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!oneShotOnTimer)
            {
                if (isUsingTrigger)
                {
                    if (useTriggerDelay)
                    {
                        if (onExitSoundCount > 0)
                            TriggerDelay(onExitSoundList);
                    }
                    else
                    {
                        if (randomSound)
                        {
                            if (onExitSoundCount > 0)
                                PlayRandomSound(onExitSoundList);
                        }
                        else
                        {
                            if (onExitSoundCount > 0)
                                PlayNextSound(onExitSoundList);
                        }
                    }
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!oneShotOnTimer)
            {
                if (isUsingTrigger)
                {
                    if (hasOnStay)
                    {
                        if (useTriggerDelay)
                        {
                            if (onStaySoundCount > 0)
                                TriggerDelay(onStaySoundList);
                        }
                        else
                        {
                            if (randomSound)
                            {
                                if (onStaySoundCount > 0)
                                    PlayRandomSound(onStaySoundList);
                            }
                            else
                            {
                                if (onStaySoundCount > 0)
                                    PlayNextSound(onStaySoundList);
                            }
                            
                        }
                    }
                    
                }
            }
        }
        #endregion


        private void PlayRandomSound(AudioClip[] set)
        {
            int rand = Random.Range(0, set.Length);
            audio.clip = set[rand];
            audio.Play();
        }

        private void PlayNextSound(AudioClip[] set)
        {
            int next=0;
            int point=0;
            for (point = 0; point < set.Length; point++ )
            {
                if (set[point] == audio.clip)
                {
                    next = point++;
                }
            }
            audio.clip = set[next];
            audio.Play();
        }

        private void TriggerDelay(AudioClip[] set)
        {
            triggerCalled = true;
            current = set;
            triggerTime = Time.time;
        }
        
        private void UpdateDelay()
        {
            if (triggerCalled)
            {
                if (Time.time - triggerTime < triggerDelay)
                {
                    if (randomSound)
                    {
                        if (current.Length > 0)
                            PlayRandomSound(current);
                    }
                    else
                    {
                        if (current.Length > 0)
                            PlayNextSound(current);
                    }
                }
            }
        }
    }
}
