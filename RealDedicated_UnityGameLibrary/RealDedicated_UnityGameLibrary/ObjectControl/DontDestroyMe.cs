using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class DontDestroyMe : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
