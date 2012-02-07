using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    class GUI_Page : MonoBehaviour
    {
        #region Members
        public enum VisibleState { Hidden, Visible }
        private VisibleState visibleState;

        #endregion

        #region Properties
        public VisibleState CurrentVisibleState
        {
            get { return this.visibleState; }
            set { this.visibleState = value; }
        }

        public bool IsVisible
        {
            get
            {
                if (this.visibleState == VisibleState.Visible)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == false)
                    this.visibleState = VisibleState.Hidden;
                else
                    this.visibleState = VisibleState.Visible;
            }
        }
        #endregion

        #region Methods
        public void Awake()
        {
            this.GUI_PageAwake();
        }

        public virtual void GUI_PageAwake()
        {

        }

        public void OnGUI()
        {
            if (this.IsVisible)
            {
                this.DisplayGUI();
            }
        }

        protected virtual void DisplayGUI()
        {

        }
        #endregion

        #region Events
        public virtual void ToggleVisibilty()
        {
            if (this.IsVisible)
            {
                this.visibleState = VisibleState.Hidden;
            }
            else
                this.visibleState = VisibleState.Visible;
        }
        #endregion
    }
}
