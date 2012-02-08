using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class StyleSheet : MonoBehaviour
    {
        #region Members
        [UnityEngine.SerializeField]
        private string styleSheetName;

        [UnityEngine.SerializeField]
        private GUIStyle[] guiStyles;

        #endregion

        #region Properties
        public string StyleSheetName
        {
            get { return this.styleSheetName; }
            set { this.styleSheetName = value; }
        }

        public GUIStyle[] GuiStyles
        {
            get { return this.guiStyles; }
            set { this.guiStyles = value; }
        }
        #endregion

        #region Methods
        public void Awake()
        {
            this.NameStyles();
        }

        protected virtual void NameStyles()
        {
            for(int i = 0; i < this.guiStyles.Length; i++)
            {
                if (this.guiStyles[i].name == "")
                {
                    this.guiStyles[i].name = "GUIStyle #" + i;
                }
            }
        }


        /// <summary>
        /// Retrieve GUIStyle by name 
        /// </summary>
        /// <param name="nameOfStyle">Name of GUIStyle</param>
        /// <returns></returns>
        public virtual GUIStyle RetrieveGUIStyle(string nameOfStyle)
        {
            GUIStyle tempStyle = new GUIStyle();

            foreach (GUIStyle childStyle in this.guiStyles)
            {
                if (childStyle.name == nameOfStyle)
                {
                    tempStyle = childStyle;
                    break;
                }
            }

            return tempStyle;
        }
        #endregion

        #region Events

        #endregion
    }
}
