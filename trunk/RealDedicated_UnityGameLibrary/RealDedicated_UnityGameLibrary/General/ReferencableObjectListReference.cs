using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ReferencableObjectListReference : MonoBehaviour
    {
        #region Members
        #region Static Instance
        private static ReferencableObjectListReference objectListInstance = null;

        public static ReferencableObjectListReference instance
        {
            get
            {
                if (objectListInstance == null)
                {
                    objectListInstance = FindObjectOfType(typeof(ReferencableObjectListReference)) as ReferencableObjectListReference;
                } 

                if (objectListInstance == null)
                {
                    GameObject newObj = new GameObject("ReferencableObjectListReference");
                    objectListInstance = newObj.AddComponent(typeof(ReferencableObjectListReference)) as ReferencableObjectListReference;
                    Debug.Log("Could not find ReferencableObjectListReference, so I made one");
                }

                return objectListInstance;
            }
        }
        #endregion

        private ReferencableObjectList[] activeObjectLists;
        #endregion

        #region Properties
        public ReferencableObjectList[] ActiveObjectLists
        {
            get { return this.activeObjectLists; }
            set { this.activeObjectLists = value; }
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
            this.activeObjectLists = FindObjectsOfType(typeof(ReferencableObjectList)) as ReferencableObjectList[];
        }

        protected virtual void NameStyleSheets()
        {
            for (int i = 0; i < this.activeObjectLists.Length; i++)
            {
                if (this.activeObjectLists[i].ObjectListName == "")
                {
                    this.activeObjectLists[i].ObjectListName = "Object List #" + i;
                }
            }
        }

        /// <summary>
        /// Retrieve ObjectList by name 
        /// </summary>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual ReferencableObjectList RetrieveObjectList(string nameOfObjectList)
        {
            ReferencableObjectList tempObjectList = null;

            foreach (ReferencableObjectList childObjectList in this.activeObjectLists)
            {
                if (childObjectList.ObjectListName == nameOfObjectList)
                {
                    tempObjectList = childObjectList;
                    break;
                }
            }

            return tempObjectList;
        }

        /// <summary>
        /// Retrieve Object By Name. NOTE: Will return FIRST object of that name
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <returns></returns>
        public virtual ReferencableObject RetrieveObject(string nameOfObject)
        {
            ReferencableObject tempObject = null;

            foreach (ReferencableObjectList childObjectList in this.activeObjectLists)
            {
                foreach (ReferencableObject childObject in childObjectList.Objects)
                {
                    if (childObject.ObjectName == nameOfObject)
                    {
                        tempObject = childObject;
                        break;
                    }
                }
            }

            return tempObject;
        }

        /// <summary>
        /// Retrieve Object By Name from List by Name.
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual ReferencableObject RetrieveObject(string nameOfObject, string nameOfObjectList)
        {
            ReferencableObject tempObject = null;

            foreach (ReferencableObjectList childObjectList in this.activeObjectLists)
            {
                if (childObjectList.ObjectListName == nameOfObjectList)
                {
                    tempObject = childObjectList.RetrieveObject(nameOfObject);
                }
            }

            return tempObject;
        }
        #endregion

    }
}
