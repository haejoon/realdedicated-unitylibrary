using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class StyleSheetReference : MonoBehaviour
    {
        #region Members
        #region Static Instance
        private static StyleSheetReference styleSheetInstance = null;

        public static StyleSheetReference instance
        {
            get
            {
                if (styleSheetInstance == null)
                {
                    styleSheetInstance = FindObjectOfType(typeof(StyleSheetReference)) as StyleSheetReference;
                }

                if (styleSheetInstance == null)
                {
                    GameObject newObj = new GameObject("StyleSheetReference");
                    styleSheetInstance = newObj.AddComponent(typeof(StyleSheetReference)) as StyleSheetReference;
                    Debug.Log("Could not find StyleSheetReference, so I made one");
                }

                return styleSheetInstance;
            }
        }
        #endregion

        private StyleSheet[] activeStyleSheets;
        #endregion

        #region Properties
        public StyleSheet[] ActiveStyleSheets
        {
            get { return this.activeStyleSheets; }
            set { this.activeStyleSheets = value; }
        }
        #endregion

        #region Methods
        public void Awake()
        {
            this.GetStyleSheets();
            this.NameStyleSheets();
        }

        protected virtual void GetStyleSheets()
        {
            this.activeStyleSheets = FindObjectsOfType(typeof(StyleSheet)) as StyleSheet[];
        }

        protected virtual void NameStyleSheets()
        {
            for (int i = 0; i < this.activeStyleSheets.Length; i++)
            {
                if (this.activeStyleSheets[i].StyleSheetName == "")
                {
                    this.activeStyleSheets[i].StyleSheetName = "StyleSheet #" + i;
                }
            }
        }

        /// <summary>
        /// Retrieve StyleSheet by name 
        /// </summary>
        /// <param name="nameOfStyle">Name of GUIStyle</param>
        /// <returns></returns>
        public virtual StyleSheet RetrieveStyleSheet(string nameOfStyleSheet)
        {
            StyleSheet tempStyleSheet = null;

            foreach (StyleSheet childStyleSheet in this.activeStyleSheets)
            {
                if (childStyleSheet.StyleSheetName == nameOfStyleSheet)
                {
                    tempStyleSheet = childStyleSheet;
                    break;
                }
            }

            return tempStyleSheet;
        }
        #endregion
    }
}
