using UnityEngine;
using UnityEditor;
using System.Collections;

namespace RealDedicated_UnityGameLibrary
{
	public class SnapToGrid : EditorWindow
	{
		 #region Members
		 public static float gridX = 1.0f;
		 public static float gridY = 1.0f;
		 public static float gridZ = 1.0f;
		 #endregion
		
	    [MenuItem ("Window/Snap to Grid %t")]
		static void Init () 
		{
			// Get existing open window or if none, make a new one:
	        SnapToGrid window = ( SnapToGrid )EditorWindow.GetWindow( typeof( SnapToGrid ) );
			window.Show ();
			
			SnapToGrid.SnapObjects();
		}
		
		void OnGUI()
        {
			GUILayout.BeginVertical();
				SnapToGrid.gridX =  float.Parse(GUILayout.TextField(SnapToGrid.gridX.ToString()));
				SnapToGrid.gridY =  float.Parse(GUILayout.TextField(SnapToGrid.gridY.ToString()));
				SnapToGrid.gridZ =  float.Parse(GUILayout.TextField(SnapToGrid.gridZ.ToString()));
				this.DrawSnapButton();
			GUILayout.EndVertical();
		}
		
		private void DrawSnapButton()
		{
			if(GUILayout.Button("Snap"))
			{
				SnapToGrid.SnapObjects();
			}
		}
		
		private static void SnapObjects()
		{
			Undo.RegisterSceneUndo("GridSnap");
			
			Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
			
			foreach (Transform transform in transforms)
	        {
	            Vector3 newPosition = transform.position;
	            newPosition.x = Mathf.Round(newPosition.x / gridX) * gridX;
	            newPosition.y = Mathf.Round(newPosition.y / gridY) * gridY;
	            newPosition.z = Mathf.Round(newPosition.z / gridZ) * gridZ;
	            transform.position = newPosition;
	        }
		}
	    
	}
}

