using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class MouseClick_OpenURL : MonoBehaviour
    {
        public string urlToOpen = "http:\\www.google.com";

        public void OnMouseDown()
        {
            this.OpenURL();
        }

        private void OpenURL()
        {
            Application.OpenURL(urlToOpen);
        }
    }
}
