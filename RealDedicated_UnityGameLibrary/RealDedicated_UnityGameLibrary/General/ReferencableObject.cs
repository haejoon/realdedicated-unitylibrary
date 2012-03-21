using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ReferencableObject
    {
        #region Members
        private string objectName;
        private Object objectToReference;
        #endregion

        #region Properties
        public string ObjectName
        {
            get { return this.objectName; }
            set { this.objectName = value; }
        }

        public Object ObjectToReference
        {
            get { return this.objectToReference; }
            set { this.objectToReference = value; }
        }
        #endregion
    }
}
