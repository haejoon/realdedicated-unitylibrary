using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace RealDedicated_UnityGameLibrary.Audio
{
    [RequireComponent(typeof(AudioSource))]
    class BGMGenerator : MonoBehaviour
    {
        #region Declarations
        [UnityEngine.SerializeField]
        private float soundtrackVolume = 0.5f;

        [UnityEngine.SerializeField]
        private AudioClip[] soundTrack= new AudioClip[songCount];

        [UnityEngine.SerializeField]
        private static int songCount = 0;

        [UnityEngine.SerializeField]
        private int startingTrack = 0;

        private int currentTrack = 0;

        [UnityEngine.SerializeField]
        private GameObject gM;

        [UnityEngine.SerializeField]
        private Transform cameratransform;

        [UnityEngine.SerializeField]
        private float mytime;

        private bool paused = false;
        public bool Paused
        {
            get { return paused; }
            set { paused = value; }
        }
                
        private bool fadingIn = false;
        public bool FadingIn
        {
            get { return fadingIn; }
            set { fadingIn = value; }
        }

        private bool fadingOut = false;
        public bool FadingOut
        {
            get { return fadingOut; }
            set { fadingOut = value; }
        }
        #endregion

        void Awake() 
        {
            DontDestroyOnLoad(this);

            //paused=false;
            //fadingIn=false;
            //fadingOut=false;

            audio.dopplerLevel = 0.0f;
            audio.volume = soundtrackVolume;
            audio.loop = false;
            audio.playOnAwake = false;
            audio.Play();
        }

        void Start() { }

        public static BGMGenerator jukeBoxInstance = null;

        public static BGMGenerator instance
        {
            get
            {
                if (jukeBoxInstance == null)
                {
                    jukeBoxInstance = FindObjectOfType(typeof(BGMGenerator)) as BGMGenerator;
                }

                if (jukeBoxInstance == null)
                {
                    // check relevancy of this
                    GameObject newObj = new GameObject("AudioMaster");
                    jukeBoxInstance = newObj.AddComponent(typeof(BGMGenerator)) as BGMGenerator;
                    Debug.Log("Could not find AudioMaster, so I made one");
                }

                return instance;
            }
        }

        void Update()
        {

            if (!audio.isPlaying && !paused)
            {
                audio.Play();
            }

            if (Application.isLoadingLevel)
            {
                //audio.Pause();
            }

            mytime += Time.deltaTime;

            if (fadingIn)
            {
                fadingOut = false;
                audio.volume += 0.002f;
                if (audio.volume >= 0.5f)
                {
                    fadingIn = false;
                    audio.volume = 0.5f;
                }
            }

            if (fadingOut)
            {
                fadingIn = false;
                audio.volume -= 0.002f;
                if (audio.volume <= 0.0f)
                {
                    fadingOut = false;
                    audio.volume = 0.0f;
                }
            }
        }

        private void Playing()
        {
            if (soundTrack[currentTrack].length != 0)
                return;

            if (!audio.isPlaying)
            {
                currentTrack = (int)((currentTrack + 1) % soundTrack[currentTrack].length);
                audio.clip = soundTrack[currentTrack];
                print("Now playing: " + soundTrack[currentTrack].name);
            }
        }

        public void RemotePause()
        {
            audio.Pause();
            paused = true;
        }

        public void RemotePlay()
        {
            audio.Play();
            paused = false;
        }

        public void ChangeVolume(float level)
        {
            audio.volume = level;
            if (audio.volume > 0.5f)
            {
                audio.volume = 0.5f;
            }
            else if (audio.volume < 0.0f)
            {
                audio.volume = 0.0f;
            }
        }

        public void NextSong()
        {
            currentTrack = currentTrack + 1;
            
            if (currentTrack > soundTrack.Length)
            {
                currentTrack = 0;
            }
            audio.clip = soundTrack[currentTrack];
        }

        public void LastSong()
        {
            currentTrack = currentTrack - 1;

            if (currentTrack < 0)
            {
                currentTrack = 0;
            }
            audio.clip = soundTrack[currentTrack];
        }

        public void ChangeSong(int change)
        {            
            currentTrack += change;
            if (currentTrack > soundTrack.Length)
            {
                audio.clip = soundTrack[0];
            }
            else
            {
                audio.clip = soundTrack[currentTrack];
            }
        }
    }
}
