using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class MouseClick_QuitApplication : MonoBehaviour
    {
        public void OnMouseDown()
        {
            this.Quit();
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}
