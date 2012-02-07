using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class GUI_Page : MonoBehaviour
    {
        #region Members
        public enum VisibleState { Hidden, Visible }
        private VisibleState visibleState;

        [UnityEngine.SerializeField]
        private string pageName = "";

        private GUI_PageDisplay pageDisplayController;
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

        public string PageName
        {
            get { return this.pageName; }
            set { this.pageName = value; }
        }
        #endregion

        #region Methods
        public void Awake()
        {
            
            this.GUI_PageAwake();
            this.GetPageDisplayController();
        }

        public virtual void GUI_PageAwake()
        {

        }

        public virtual void GetPageDisplayController()
        {
            GUI_PageDisplay tempPageDisplayer = GameObject.FindObjectOfType(typeof(GUI_PageDisplay)) as GUI_PageDisplay;

            if (tempPageDisplayer != null)
            {
                this.pageDisplayController = tempPageDisplayer;
            }
            else
            {
                Debug.Log("Could not find GUI_PageDisplay, GUI_Pages will not be able to be displayed");
            }
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
