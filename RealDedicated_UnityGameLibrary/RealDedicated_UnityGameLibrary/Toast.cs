using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    /// <summary>
    /// A toast is a message displayed through the GUI that eventually dies.
    /// </summary>
    public class Toast : MonoBehaviour
    {
        #region Members
        protected string textToDisplay;
        protected Vector2 textPosition;
        protected Vector2 textDirection;
        protected float textSpeed;
        protected GUIStyle textGUIStyle;

        protected bool displayed = false;
        protected Vector2 textSize;
        #endregion

        #region Properties
        public string TextToDisplay
        {
            get { return this.textToDisplay; }
            set { this.textToDisplay = value; }
        }

        public Vector2 TextPosition
        {
            get { return this.textPosition; }
            set { this.textPosition = value; }
        }

        public Vector2 TextDirection
        {
            get { return this.textDirection; }
            set { this.textDirection = value; }
        }

        public float TextSpeed
        {
            get { return this.textSpeed; }
            set { this.textSpeed = value; }
        }

        public GUIStyle TextGUIStyle
        {
            get { return this.textGUIStyle; }
            set { this.textGUIStyle = value; }
        }

        public Rect TextRect
        {
            get
            {
                Rect tempRect = new Rect();

                tempRect.x = this.TextPosition.x;
                tempRect.y = this.TextPosition.y;

                Vector2 tempSize = this.TextGUIStyle.CalcSize(new GUIContent(this.TextToDisplay));

                tempRect.width = tempSize.x;
                tempRect.height = tempSize.y;

                return tempRect;
            }
        }
        #endregion

        #region Methods
        public void BeginDisplayingToast()
        {
            this.displayed = true;
        }

        public void OnGUI()
        {
            if (this.displayed)
            {
                this.DisplayToast();
            }
        }

        public void FixedUpdate()
        {
            if (this.displayed)
            {
                this.MoveToast();
            }
        }

        protected void DisplayToast()
        {
            GUI.Label(this.TextRect, new GUIContent(this.TextToDisplay), this.TextGUIStyle);
        }

        protected void MoveToast()
        {
            Vector2 textMoveVector = this.TextDirection * this.TextSpeed;

            this.TextPosition += textMoveVector;
        }
        #endregion
    }
}
