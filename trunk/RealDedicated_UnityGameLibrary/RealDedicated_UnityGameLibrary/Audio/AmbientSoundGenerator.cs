
using System.Collections.Generic;
using UnityEngine;


namespace RealDedicated_UnityGameLibrary.Audio
{
    [RequireComponent(typeof(AudioSource))]
    class AmbientSoundGenerator : MonoBehaviour
    {
        // Set true if the GO has a collider being used as a trigger
        [UnityEngine.SerializeField]
        private bool isUsingTrigger = false;
        
        [UnityEngine.SerializeField]
        private bool oneShotOnTimer = false;

        [UnityEngine.SerializeField]
        private bool oneShotRepeat = false;

        [UnityEngine.SerializeField]
        private float oneShotTime = 0.0f;

        [UnityEngine.SerializeField]
        private AudioClip oneShotSound = null;

        //[UnityEngine.SerializeField]
        //private Collider triggerArea = null;

        public bool inTrigger = false;
        
        [UnityEngine.SerializeField]
        private AudioClip[] onEnterSoundList = new AudioClip[0];

        [UnityEngine.SerializeField]
        private AudioClip[] onStaySoundList = new AudioClip[0];

        [UnityEngine.SerializeField]
        private AudioClip[] onExitSoundList = new AudioClip[0];

        // Property governing additional logic for situations where the OnTriggerStay functionality is wanted.
        [UnityEngine.SerializeField]
        private bool hasOnStay = false;

        [UnityEngine.SerializeField]
        private bool useTriggerDelay = false;

        [UnityEngine.SerializeField]
        private float triggerDelay = 0.0f;
              
        // Not sure what im doing with this.
        //[UnityEngine.SerializeField]
        //private float actionTimer = 0.0f;

       /* [UnityEngine.SerializeField]
        private bool actionPlay = false;       

        [UnityEngine.SerializeField]
        private bool actionReverse = false;

        [UnityEngine.SerializeField]
        private bool actionRepeat = false;*/

        [UnityEngine.SerializeField]
        private bool randomSound = false;

        private float startTime = 0.0f;

        private float triggerTime = 0.0f;

        private bool triggerCalled = false;

        public AudioSource audiosource;

        private AudioClip[] current;

        public AudioClip temp;

        private void Create() { }

        private void Start() { }

        private void Awake() 
        {
            this.audiosource = this.gameObject.GetComponent<AudioSource>();
            startTime = Time.time;
            audiosource.clip = temp;
         
            //Debug.Log(audiosource.clip);
            //Debug.Log(audiosource.isPlaying);


            if (this.audiosource == null)
            {
                this.audiosource.gameObject.AddComponent<AudioSource>();
                this.audiosource = this.audiosource.gameObject.GetComponent<AudioSource>();
                this.audiosource.playOnAwake = false;                               
            }
        }

        private void Update()
        {
           
            if (oneShotOnTimer)
            {
                if (Time.time - startTime < oneShotTime)
                {
                    if (oneShotSound != null)
                    {
                        audiosource.clip = oneShotSound;
                        audiosource.Play();
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
        void OnTriggerEnter(Collider other)
        {
            inTrigger = true;
            if (!oneShotOnTimer)
            {
                if (isUsingTrigger)
                {
                    if (useTriggerDelay)
                    {
                        if (onEnterSoundList.Length > 0)
                            TriggerDelay(onEnterSoundList);
                    }
                    else
                    {
                        if (randomSound)
                        {
                            if (onEnterSoundList.Length > 0)
                            {
                                PlayRandomSound(onEnterSoundList);
                            }
                        }
                        else
                        {
                            if (onEnterSoundList.Length > 0)
                            {
                                PlayNextSound(onEnterSoundList);
                            }
                            
                        }
                    }
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            inTrigger = false;
            if (!oneShotOnTimer)
            {
                if (isUsingTrigger)
                {
                    if (useTriggerDelay)
                    {
                        if (onExitSoundList.Length > 0)
                            TriggerDelay(onExitSoundList);
                    }
                    else
                    {
                        if (randomSound)
                        {
                            if (onExitSoundList.Length > 0)
                                PlayRandomSound(onExitSoundList);
                        }
                        else
                        {
                            if (onExitSoundList.Length > 0)
                                PlayNextSound(onExitSoundList);
                        }
                    }
                }
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (!oneShotOnTimer)
            {
                if (isUsingTrigger)
                {
                    if (hasOnStay)
                    {
                        if (useTriggerDelay)
                        {
                            if (onStaySoundList.Length > 0)
                                TriggerDelay(onStaySoundList);
                        }
                        else
                        {
                            if (randomSound)
                            {
                                if (onStaySoundList.Length > 0)
                                    PlayRandomSound(onStaySoundList);
                            }
                            else
                            {
                                if (onStaySoundList.Length > 0)
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
            Debug.Log("play random called");
            int rand = Random.Range(0, set.Length);
            rand = 0;
            audiosource.clip = set[rand];
            audiosource.Play();
        }

        private void PlayNextSound(AudioClip[] set)
        {
            Debug.Log("play next called");
            int next=0;
            int point=0;
            if (set.Length > 1)
            {
                for (point = 0; point < set.Length; point++)
                {
                    if (set[point] == audiosource.clip)
                    {
                        next = point++;
                    }
                }
            }
            audiosource.clip = set[next];
            Debug.Log(next);

            audiosource.PlayOneShot(audiosource.clip);
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
