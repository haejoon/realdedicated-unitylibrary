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
		 public static float rotation = 15;
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
				GUILayout.Label("Move X: " + SnapToGrid.gridX);
				GUILayout.Label("Move Y: " + SnapToGrid.gridY);
				GUILayout.Label("Move Z: " + SnapToGrid.gridZ);
				GUILayout.Label("Rotate: " + SnapToGrid.rotation);
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
			Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
			
			foreach (Transform transform in transforms)
	        {
	            Vector3 newPosition = transform.position;
	            newPosition.x = Mathf.Round(newPosition.x / gridX) * gridX;
	            newPosition.y = Mathf.Round(newPosition.y / gridY) * gridY;
	            newPosition.z = Mathf.Round(newPosition.z / gridZ) * gridZ;
	            transform.position = newPosition;
				
				Quaternion newRotation = transform.rotation;
				newRotation.x = Mathf.Round(newRotation.x / rotation) * rotation;
				newRotation.y = Mathf.Round(newRotation.y / rotation) * rotation;
				newRotation.z = Mathf.Round(newRotation.z / rotation) * rotation;
				newRotation.w = Mathf.Round(newRotation.w / rotation) * rotation;
				transform.rotation = newRotation;
	        }
		}
	    
	}
}

