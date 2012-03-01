using UnityEngine;


namespace RealDedicated_UnityGameLibrary
{
    public class MouseClick_LoadScene : MonoBehaviour
    {
        public string sceneToLoad = "MainMenu";

        public void OnMouseDown()
        {
            this.OpenURL();
        }

        private void OpenURL()
        {
            Application.LoadLevel(this.sceneToLoad);
        }
    }
}
