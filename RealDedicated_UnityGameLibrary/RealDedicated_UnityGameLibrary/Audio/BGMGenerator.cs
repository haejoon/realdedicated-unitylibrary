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

        //[UnityEngine.SerializeField]
        //private int startingTrack = 0;

        private int currentTrack = 0;

        //[UnityEngine.SerializeField]
        //private GameObject gM;

        private AudioSource audioSource;

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

        GameObject parent;

        void Awake() 
        {
            DontDestroyOnLoad(this);
            this.audioSource = this.gameObject.GetComponent<AudioSource>();
            #warning "not intelligent object assignment"
            parent = GameObject.Find("GameCamera");


            if (this.audioSource == null)
            {
                this.audioSource.gameObject.AddComponent<AudioSource>();
                this.audioSource = this.audioSource.gameObject.GetComponent<AudioSource>();
                this.audioSource.playOnAwake = false;

                audioSource.dopplerLevel = 0.0f;
                audioSource.volume = soundtrackVolume;
                audioSource.loop = false;
                audioSource.playOnAwake = false;
                
            }
            audioSource.clip = soundTrack[0];
            audioSource.Play();
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
                    //jukeBoxInstance = newObj.AddComponent(typeof(BGMGenerator)) as BGMGenerator;
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
            this.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y,parent.transform.position.z);
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
