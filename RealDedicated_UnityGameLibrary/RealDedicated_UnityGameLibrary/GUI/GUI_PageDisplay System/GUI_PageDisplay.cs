using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class GUI_PageDisplay : MonoBehaviour
    {
        #region Members
        [UnityEngine.SerializeField]
        private string pageDisplayToggleButton = "Escape";
        
        [UnityEngine.SerializeField]
        private List<GUI_Page> pagesToDisplay = new List<GUI_Page>();
        [UnityEngine.SerializeField]
        private GUI_Page currentPage;

        [UnityEngine.SerializeField]
        private int guiDepth = 1;

        private bool displayingPages = false;
        #endregion

        #region Properties
        public bool DisplayingPages
        {
            get { return this.displayingPages; }
            set { this.displayingPages = value; }
        }

        public int GUIDepth
        {
            get { return this.guiDepth; }
            set { this.guiDepth = value; }
        }

        /// <summary>
        /// List of pages to display when active; the first item in the list will always be displayed first. 
        /// </summary>
        public List<GUI_Page> PagesToDisplay
        {
            get { return this.pagesToDisplay; }
            set { this.pagesToDisplay = value; }
        }

        /// <summary>
        /// Current Page the display system is displaying
        /// </summary>
        public GUI_Page CurrentPage
        {
            get { return this.currentPage; }
            set { this.currentPage = value; }
        }

        public string PageDisplayToggleButton
        {
            get { return this.pageDisplayToggleButton; }
            set { this.pageDisplayToggleButton = value; }
        }
        #endregion

        #region Methods
        public void Awake()
        {
            if (this.PagesToDisplay.Count > 1)
            {
                this.CurrentPage = this.PagesToDisplay[0];
            }
        }

        private void SetPageNames()
        {
            for(int i = 0; i < this.PagesToDisplay.Count; i++)
            {
                if (this.PagesToDisplay[i].PageName == "")
                {
                    this.PagesToDisplay[i].PageName = "Page #: " + i.ToString();
                }
            }
        }

        public void Update()
        {
            this.CheckForInput();
        }

        private void CheckForInput()
        {
            if (Input.GetButtonDown(this.PageDisplayToggleButton))
            {
                this.DisplayingPages = !this.DisplayingPages;

            }
        }

        public void OnGUI()
        {
            UnityEngine.GUI.depth = this.GUIDepth;

            if (this.DisplayingPages)
            {
                this.DisplayCurrentPage();
            }
        }

        private void DisplayCurrentPage()
        {
            if (this.CurrentPage != null)
            {
                if (!this.CurrentPage.IsVisible)
                {
                    this.CurrentPage.ToggleVisibilty();
                }
                //Seriously, that's it... The page should handle itself. You just have to make sure it's visible!
            }
        }


        public void TogglePageVisibility(GUI_Page pageToToggle)
        {
            pageToToggle.ToggleVisibilty();
        }
        #endregion

        #region Events
        /// <summary>
        /// Manually set a current page by providing a GUIPage, does not have to be in the list of pages
        /// </summary>
        /// <param name="newCurrentPage"></param>
        public void SetCurrentPage(GUI_Page newCurrentPage)
        {
            if (newCurrentPage != null)
            {
                //Turn the old page off
                this.TogglePageVisibility(this.currentPage);
                this.currentPage = newCurrentPage;
                //Turn the new page on
                this.TogglePageVisibility(newCurrentPage);
            }
        }

        public void SetCurrentPage(string pageName)
        {
            foreach (GUI_Page childGUIPage in this.PagesToDisplay)
            {
                if (childGUIPage.PageName == pageName)
                {
                    this.SetCurrentPage(childGUIPage);
                    break;
                }
            }
        }
        #endregion
    }
}
