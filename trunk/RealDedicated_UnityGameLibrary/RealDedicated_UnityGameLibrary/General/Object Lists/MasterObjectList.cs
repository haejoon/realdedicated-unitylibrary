using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    /// <summary>
    /// This class contains all of there RefrenceableObjectLists found in a Scene. 
    /// </summary>
    public class MasterObjectList : ReferencableObjectList
    {
        #region Static Instance
        private static MasterObjectList classInstance = null;

        public static MasterObjectList instance
        {
            get
            {
                if (classInstance == null)
                {
                    classInstance = FindObjectOfType(typeof(MasterObjectList)) as MasterObjectList;
                }

                if (classInstance == null)
                {
                    GameObject newObj = new GameObject("MasterObjectList");
                    classInstance = newObj.AddComponent(typeof(MasterObjectList)) as MasterObjectList;
                    Debug.Log("Could not find MasterObjectList, so I made one");
                }

                return classInstance;
            }
        }
        #endregion

        public void Awake()
        {
            this.GetObjectLists();
        }

        private void GetObjectLists()
        {
            ReferencableObjectList[] tempObjectLists = FindObjectsOfType(typeof(ReferencableObjectList)) as ReferencableObjectList[];
            List<ReferencableObject> tempRefObjects = new List<ReferencableObject>();

            for (int i = 0; i < tempObjectLists.Length; i++)
            {
                if (tempObjectLists[i] != this as ReferencableObjectList && tempObjectLists[i] != null)
                {
                    tempRefObjects.Add(new ReferencableObject());
                    tempRefObjects[tempRefObjects.Count - 1].ObjectName = tempObjectLists[i].ObjectListName;
                    tempRefObjects[tempRefObjects.Count - 1].ObjectToReference = tempObjectLists[i];
                }
            }

            this.Objects = new ReferencableObject[tempRefObjects.Count];
            this.Objects = tempRefObjects.ToArray();

        }

        #region Events
        /// <summary>
        /// Retrieve ObjectList by name 
        /// </summary>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual ReferencableObjectList RetrieveObjectList(string nameOfObjectList)
        {
            ReferencableObjectList tempObjectList = null;

            foreach (ReferencableObject childObject in this.Objects)
            {
                if (childObject.ObjectName == nameOfObjectList)
                {                
                    tempObjectList = childObject.ObjectToReference as ReferencableObjectList;

                    break;
                }
            }

            return tempObjectList;
        }

        /// <summary>
        /// Retrieve ReferenceableObject By Name from List by Name.
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual ReferencableObject RetrieveObject(string nameOfObject, string nameOfObjectList)
        {
            ReferencableObject tempObject = null;

            tempObject = this.RetrieveObjectList(nameOfObjectList).RetrieveObject(nameOfObject);

            return tempObject;
        }

        /// <summary>
        /// Retrieve Actual Object By Name from List by Name.
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual Object RetrieveObjectActual(string nameOfObject, string nameOfObjectList)
        {
            Object tempObject = this.RetrieveObject(nameOfObject,nameOfObjectList).ObjectToReference;

            if(tempObject != null)
                return tempObject;

            return null;
        }

        #endregion
    }
}
