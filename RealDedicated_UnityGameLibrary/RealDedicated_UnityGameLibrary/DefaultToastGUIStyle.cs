using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    class DefaultToastGUIStyle : MonoBehaviour
    {
        public bool destroyOnLoadLevel = false;

        /// <summary>
        /// This style is used by the toast builder when no style is prodivided
        /// </summary>
        public GUIStyle defaultToastGUIStyle;

        public void Start()
        {
            if(!this.destroyOnLoadLevel)
                DontDestroyOnLoad(this.gameObject);

            ToastBuilder.DefaultGUIStyle = this.defaultToastGUIStyle;
        }

    }
}
