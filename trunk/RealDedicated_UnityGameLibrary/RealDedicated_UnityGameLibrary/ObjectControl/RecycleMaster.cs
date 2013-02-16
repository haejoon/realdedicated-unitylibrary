using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
	public class RecycleMaster : MonoBehaviour 
{
	#region Members
	#region Static Instance
    private static RecycleMaster recycleMasterInstance = null;

    public static RecycleMaster instance
    {
        get
        {
            if (recycleMasterInstance == null)
            {
                recycleMasterInstance = FindObjectOfType(typeof(RecycleMaster)) as RecycleMaster;
            }

            if (recycleMasterInstance == null)
            {
                GameObject newObj = new GameObject("RecycleMaster");
                recycleMasterInstance = newObj.AddComponent(typeof(RecycleMaster)) as RecycleMaster;
                Debug.Log("Could not find RecycleMaster, so I made one");
            }

            return recycleMasterInstance;
        }
    }
    #endregion
	
	private Dictionary<int,ObjectRecycler> recyclerDictionary = new Dictionary<int, ObjectRecycler>();
	
	/// <summary>
	/// The recyclable object dictionary, used when this is passed a non-recycleable Object (bad people...)
	/// </summary>
	private Dictionary<GameObject, int> recyclableObjectDictionary = new Dictionary<GameObject, int>();
    #endregion
	
	#region Methods
	private bool IsRecycleable(GameObject goToCheck)
	{
		RecyclableObject ro = goToCheck.GetComponent<RecyclableObject>();
				
		if(ro == null)
			return false;
		else
			return true;
	}
	
	private GameObject GetNextFreeObject(GameObject goToGet)
	{		
		if(!IsRecycleable(goToGet))//Make sure it has an ID
			this.MakeRecycleable(goToGet);
		
		int id = this.GetRecyclerID(goToGet);//Get the ID so we can get the corresponding Recycler
						
		ObjectRecycler oR = this.GetRecycler(id, goToGet);//Get the Recycler, send GO incase we need to make a new one
				
		GameObject tempGO = oR.nextFreeObject;
				
		this.AttachRO(tempGO, id);
		
		return tempGO;//Return nextFree!
	}
	
	private void MakeRecycleable(GameObject goToRecycle)
	{	
		if(!this.recyclableObjectDictionary.ContainsKey(goToRecycle))
			this.recyclableObjectDictionary.Add(goToRecycle, this.GetUniqueRecyleID());
	}
	
	private int GetRecyclerID(GameObject goToGet)
	{
		if(this.recyclableObjectDictionary.ContainsKey(goToGet))
		{
			return this.recyclableObjectDictionary[goToGet];			
		}
		else
		{
			RecyclableObject ro = goToGet.GetComponent<RecyclableObject>();
			
			return ro.recycleID;
		}	
	}
	
	//Gets a Recycler. If there isn't one, make it!
	private ObjectRecycler GetRecycler(int recyclerID, GameObject goToMake)
	{
		if(this.recyclerDictionary.ContainsKey(recyclerID))
			return this.recyclerDictionary[recyclerID];
		else
		{			
			ObjectRecycler newOR = new ObjectRecycler(goToMake,0);
			
			this.recyclerDictionary.Add(recyclerID, newOR);
			
			return newOR;
		}
	}
	
	private void AttachRO(GameObject goToAttachTo, int idToUse)
	{
		if(goToAttachTo.GetComponentInChildren<RecyclableObject>() == null)
		{
			RecyclableObject rO = goToAttachTo.AddComponent<RecyclableObject>();
			rO.recycleID = idToUse;			
		}
	}
	#endregion
	
	#region Events
	public GameObject GetFreeObject(GameObject objectPrefab)
	{			
		return	this.GetNextFreeObject(objectPrefab);
	}
	
	public void FreeObject(RecyclableObject objectToFree)
	{
		if(this.recyclerDictionary.ContainsKey(objectToFree.recycleID))
			this.recyclerDictionary[objectToFree.recycleID].freeObject(objectToFree.gameObject);
		else
			Debug.Log("You are trying to free an object w/o a recycler. You are looking for id: " + objectToFree.recycleID);
	}	
	#endregion
	
	#region Helpers
	public int GetUniqueRecyleID()
	{	
		return System.DateTime.Now.Millisecond + System.DateTime.Now.Second  + (int)System.DateTime.Now.Ticks + (int)Time.timeSinceLevelLoad;
	}
	#endregion
}

}

