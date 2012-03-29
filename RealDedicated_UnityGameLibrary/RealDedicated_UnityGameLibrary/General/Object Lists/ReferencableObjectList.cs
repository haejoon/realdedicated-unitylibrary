using UnityEngine;

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

        public Object[] ObjectsActual
        {
            get
            {
                Object[] tempObjects = new Object[this.Objects.Length];

                for (int i = 0; i < this.Objects.Length; i++)
                {
                    tempObjects[i] = this.Objects[i].ObjectToReference;
                }

                return tempObjects;
            }
        }
        #endregion

        #region Methods
        public void Start()
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
        /// Retrieve Object by name 
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
        #endregion
    }
}
