using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class MouseClickObjectDestroyer : MonoBehaviour
    {
        public void OnMouseDown()
        {
            this.KillObject();
        }

        private void KillObject()
        {
            Destroy(this.gameObject);
        }
    }
}
