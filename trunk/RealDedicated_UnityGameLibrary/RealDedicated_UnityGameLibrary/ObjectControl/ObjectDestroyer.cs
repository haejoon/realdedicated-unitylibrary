using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ObjectDestroyer : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private float timeUntilDestruction = .1f;

        public void Awake()
        {
            Invoke("DestroyObject", this.timeUntilDestruction);
        }

        private void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }
}
