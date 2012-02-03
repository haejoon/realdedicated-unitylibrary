using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ToastBuilder
    {
        static string defaultText = "Hello World";
        static Vector2 defaultPosition = new Vector2(0, 0);
        static Vector2 defaultDirection = new Vector2(0, 1);
        static float defaultSpeed = 1f;
        static float defaultLifetime = 1.5f;
        static GUIStyle defaultStyle = new GUIStyle();

        public static GUIStyle DefaultGUIStyle
        {
            get { return defaultStyle; }
            set { defaultStyle = value; }
        }

        #region Constructors
        public static void CreateToast()
        {
            BuildToast(defaultText, defaultPosition, defaultDirection, defaultSpeed, defaultStyle, defaultLifetime);
        }

        public static void CreateToast(string toastText)
        {
            BuildToast(toastText, defaultPosition, defaultDirection, defaultSpeed, defaultStyle, defaultLifetime);
        }

        public static void CreateToast(string toastText, float toastLifetime)
        {
            BuildToast(toastText, defaultPosition, defaultDirection, defaultSpeed, defaultStyle, toastLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition)
        {
            BuildToast(toastText, toastPosition, defaultDirection, defaultSpeed, defaultStyle, defaultLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, float toastLifetime)
        {
            BuildToast(toastText, toastPosition, defaultDirection, defaultSpeed, defaultStyle, toastLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, Vector2 toastDirection)
        {
            BuildToast(toastText, toastPosition, toastDirection, defaultSpeed, defaultStyle, defaultLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastLifetime)
        {
            BuildToast(toastText, toastPosition, toastDirection, defaultSpeed, defaultStyle, toastLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, double toastSpeed)
        {
            BuildToast(toastText, toastPosition, toastDirection, (float)toastSpeed, defaultStyle, defaultLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, float toastLifetime)
        {
            BuildToast(toastText, toastPosition, toastDirection, toastSpeed, defaultStyle, toastLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, GUIStyle toastStyle)
        {
            BuildToast(toastText, toastPosition, toastDirection, toastSpeed, toastStyle, defaultLifetime);
        }

        public static void CreateToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, GUIStyle toastStyle, float toastLifetime)
        {
            BuildToast(toastText, toastPosition, toastDirection, toastSpeed, toastStyle, toastLifetime);
        }
        #endregion

        #region Methods      
        private static void BuildToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, GUIStyle toastStyle, float toastLifetime)
        {
            GameObject tempToastObject = new GameObject();

            tempToastObject.AddComponent<Toast>();

            SetToastProperties(tempToastObject, toastText, toastPosition, toastDirection, toastSpeed, toastStyle);            

            tempToastObject.GetComponent<Toast>().BeginDisplayingToast();

            MonoBehaviour.DestroyObject(tempToastObject, toastLifetime);
        }

        private static void SetToastProperties(GameObject tempToastObject, string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, GUIStyle toastStyle)
        {
            tempToastObject.GetComponent<Toast>().TextToDisplay = toastText;
            tempToastObject.GetComponent<Toast>().TextPosition = toastPosition;
            tempToastObject.GetComponent<Toast>().TextDirection = toastDirection;
            tempToastObject.GetComponent<Toast>().TextSpeed = toastSpeed;
            tempToastObject.GetComponent<Toast>().TextGUIStyle = toastStyle;           
        }
        #endregion

    }
}
