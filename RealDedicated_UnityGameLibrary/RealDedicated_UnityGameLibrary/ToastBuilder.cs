using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ToastBuilder
    {
        string defaultText = "Hello World";
        Vector2 defaultPosition = new Vector2(0, 0);
        Vector2 defaultDirection = new Vector2(0, 1);
        float defaultSpeed = 1f;
        float defaultLifetime = 3f;

        #region Constructors
        public void CreateToast()
        {
            this.BuildToast(this.defaultText, this.defaultPosition, this.defaultDirection, this.defaultSpeed, this.GetDefaultGUIStyle(), this.defaultLifetime);
        }        
        #endregion

        #region Methods
        private GUIStyle GetDefaultGUIStyle()
        {
            GUIStyle tempStyle = new GUIStyle();

            GameObject defaultStyleObject = (GameObject)GameObject.FindObjectOfType(typeof(DefaultToastGUIStyle));

            if (defaultStyleObject != null)
            {
                tempStyle = defaultStyleObject.GetComponent<DefaultToastGUIStyle>().defaultToastGUIStyle;
            }

            return tempStyle;
        }

        private void BuildToast(string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, GUIStyle toastStyle, float toastLifetime)
        {
            GameObject tempToastObject = new GameObject();

            tempToastObject.AddComponent<Toast>();

            this.SetToastProperties(tempToastObject, toastText, toastPosition, toastDirection, toastSpeed, toastStyle);

            tempToastObject.GetComponent<Toast>().BeginDisplayingToast();

            MonoBehaviour.DestroyObject(tempToastObject, toastLifetime);
        }

        private void SetToastProperties(GameObject tempToastObject, string toastText, Vector2 toastPosition, Vector2 toastDirection, float toastSpeed, GUIStyle toastStyle)
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
