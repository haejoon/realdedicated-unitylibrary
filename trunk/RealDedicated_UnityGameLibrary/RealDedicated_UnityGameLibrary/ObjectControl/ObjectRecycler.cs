/* Courtesy of Prime31 Tutorial:
 * http://www.youtube.com/watch?v=d9078u8ft58&feature=plcp&context=C4481361VDvjVQa1PpcFPgVcb84uFoxTiWr31my2auv_f_73XFfcE= */

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace RealDedicated_UnityGameLibrary
{
    public class ObjectRecycler
    {
        public delegate void ObjectRecyclerChangedEventHandler(int availableObjects, int totalObjects);
        public event ObjectRecyclerChangedEventHandler onObjectRecyclerChanged;

        private List<GameObject> objectList;
        private GameObject objectToRecycle;

        public ObjectRecycler(GameObject go, int totalObjectsAtStart)
        {
            this.objectList = new List<GameObject>(totalObjectsAtStart);
            
            this.objectToRecycle = go;

            for (int i = 0; i < totalObjectsAtStart; i++)
            {				
                //Create a new instance
                GameObject newObject = Object.Instantiate(go) as GameObject;
                //Deactivate the object
				newObject.SetActive(false);				
				
                //Store the object for later use
                this.objectList.Add(newObject);
            }
        }

        private void fireRecycledEvent()
        {
            if (onObjectRecyclerChanged != null)
            {
                var allFreeObjects = from item in this.objectList
                                     where item.activeSelf == false
                                     select item;

                onObjectRecyclerChanged(allFreeObjects.Count(), this.objectList.Count);
            }
        }

        /// <summary>
        /// Gets the next available free object or null, will create new object if none exist
        /// </summary>
        public GameObject nextFreeObject
        {
            get
            {
                var freeObject = (from item in this.objectList
                                  where item.activeSelf == false
                                  select item).FirstOrDefault();

                if (freeObject == null)
                {
                    freeObject = Object.Instantiate(this.objectToRecycle) as GameObject;
                    objectList.Add(freeObject);
                }

				freeObject.SetActive(true);

                fireRecycledEvent();

                return freeObject;
            }
        }

        //Must be called by any object that wants to be reused
        public void freeObject(GameObject objectToFree)
        {
            objectToFree.gameObject.SetActive(false);

            fireRecycledEvent();
        }
    }
}
