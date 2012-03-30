using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class OneShotAudioPlayer : MonoBehaviour
    {
        #region Static Instance
        private static OneShotAudioPlayer classInstance = null;

        public static OneShotAudioPlayer instance
        {
            get
            {
                if (classInstance == null)
                {
                    classInstance = FindObjectOfType(typeof(OneShotAudioPlayer)) as OneShotAudioPlayer;
                }

                if (classInstance == null)
                {
                    GameObject newObj = new GameObject("OneShotAudioPlayer");
                    classInstance = newObj.AddComponent(typeof(OneShotAudioPlayer)) as OneShotAudioPlayer;
                    Debug.Log("Could not find OneShotAudioPlayer, so I made one");
                }

                return classInstance;
            }
        }
        #endregion

        private ObjectRecycler oneshotAudioRecycler;

        #region Constructors
        public void CreateOneShotAudioPlayer(AudioClip clipToPlay)
        {
            GameObject go = this.oneshotAudioRecycler.nextFreeObject;

            StartCoroutine
            (
                go.audio.playClip(clipToPlay, () =>
                {
                    this.RecycleObject(go);
                })
            );
        }

        public void CreateOneShotAudioPlayer(AudioClip clipToPlay, Vector3 spawnLocation)
        {
            GameObject go = this.oneshotAudioRecycler.nextFreeObject;
            go.transform.position = spawnLocation;

            StartCoroutine
            (
                go.audio.playClip(clipToPlay, () =>
                {
                    this.RecycleObject(go);
                })
            );
        }

        public void CreateOneShotAudioPlayer(AudioClip[] randomClipsToPlay)
        {
            GameObject go = this.oneshotAudioRecycler.nextFreeObject;

            StartCoroutine
            (
                go.audio.playRandomClip(randomClipsToPlay, () =>
                {
                    this.RecycleObject(go);
                })
            );
        }

        public void CreateOneShotAudioPlayer(AudioClip[] randomClipsToPlay, Vector3 spawnLocation)
        {
            GameObject go = this.oneshotAudioRecycler.nextFreeObject;
            go.transform.position = spawnLocation;

            StartCoroutine
            (
                go.audio.playRandomClip(randomClipsToPlay, () =>
                {
                    this.RecycleObject(go);
                })
            );
        }
        #endregion

        #region Methods 
        public void Awake()
        {
            this.InstantiateRecycler();
        }

        //Instantiate the ObjectRecyler that will control my OneShotAudioSources
        private void InstantiateRecycler()
        {
            GameObject go = new GameObject();
            go.AddComponent<AudioSource>();
            go.name = "OneShotAudioSource";

            this.oneshotAudioRecycler = new ObjectRecycler(go, 2);

            Destroy(go);
        }

        private void RecycleObject(GameObject go)
        {
            this.oneshotAudioRecycler.freeObject(go);
        }
        #endregion
    }
}
