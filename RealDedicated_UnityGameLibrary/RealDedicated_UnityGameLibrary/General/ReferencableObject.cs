using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    [System.Serializable]
    public class ReferencableObject : MonoBehaviour
    {
        #region Members
        [UnityEngine.SerializeField]
        private string objectName;
        [UnityEngine.SerializeField]
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
