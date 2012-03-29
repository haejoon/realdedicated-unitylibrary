using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class ReferencableObjectList : MonoBehaviour
    {
        #region Members
        [UnityEngine.SerializeField]
        private string objectListName;

        [UnityEngine.SerializeField]
        private ReferencableObject[] objects;
        #endregion

        #region Properties
        public string ObjectListName
        {
            get { return this.objectListName; }
            set { this.objectListName = value; }
        }

        public ReferencableObject[] Objects
        {
            get { return this.objects; }
            set { this.objects = value; }
        }

        public List<Object> ObjectsActual
        {
            get
            {
                List<Object> tempObjects = new List<Object>();

                for (int i = 0; i < this.Objects.Length; i++)
                {
                    tempObjects.Add(this.Objects[i].ObjectToReference);
                }

                return tempObjects;
            }
        }
        #endregion

        #region Methods
        public void Awake()
        {
            this.GetObjects();
            this.NameObjects();
        }

        protected virtual void GetObjects()
        {
            
        }

        protected virtual void NameObjects()
        {
            for (int i = 0; i < this.objects.Length; i++)
            {
                if (this.objects[i].ObjectName == "")
                {
                    this.objects[i].ObjectName = "Object #" + i;
                }
            }
        }

        /// <summary>
        /// Retrieve ReferenceableObject by name 
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <returns></returns>
        public virtual ReferencableObject RetrieveObject(string nameOfObject)
        {
            ReferencableObject tempObject = new ReferencableObject();

            foreach (ReferencableObject childObject in this.objects)
            {
                if (childObject.ObjectName == nameOfObject)
                {
                    tempObject = childObject;
                    break;
                }
            }

            return tempObject;
        }

        /// <summary>
        /// Retrieve Object by name 
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <returns></returns>
        public virtual Object RetrieveObjectActual(string nameOfObject)
        {
            return this.RetrieveObject(nameOfObject).ObjectToReference;
        }
        #endregion
    }
}
