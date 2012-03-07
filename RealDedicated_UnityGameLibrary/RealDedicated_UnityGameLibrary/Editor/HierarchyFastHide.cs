/* --------------------------------------------
 * 
 *  Hierachy Fast Hide - (c)2010 - Rouhee Games
 * 
 *  v.0.1
 * 
 *  Description:
 *  Lists all GameObjects in a window that have
 *  MeshRenderer component and adds toggle where
 *  user can turn it on/off.
 *  
 *  ToDo:
 *  - Scroll Bars to longer list ;-D
 *  - Real Hierarchy for Childs etc.
 *  
 * 
 *  Author:
 *  timo.anttila{at}rouheegames.com
 *  
 *  http://www.rouheegames.com
 * 
 *  Licence:
 *  Provided as is! Do what you want, but don't
 *  blame me if your computer broke! ;-)
 * 
 * ------------------------------------------- */

using UnityEngine;
using UnityEditor;

public class HierarchyFastHide : EditorWindow {

    private MeshRenderer[] mr;

    // Add menu named "Hierarchy Plus" to the Window menu
    [MenuItem( "Window/Hierarchy Fast Hide %H" )]
	static void Init () 
	{
		// Get existing open window or if none, make a new one:
        HierarchyFastHide window = ( HierarchyFastHide )EditorWindow.GetWindow( typeof( HierarchyFastHide ) );
		window.Show ();
	}

    // If Window Got Focus
    void OnFocus()
    {
        UpdateMR();
    }

    // Called whenever the scene hierarchy has changed.
    void OnHierarchyChange()
    {
        UpdateMR();
    }

    // Implement your own GUI here.
	void OnGUI()
    {
        if( mr.Length != 0 )
        {
            for( int x = 0; x < mr.Length; x++ )
            {
                mr[ x ].enabled = GUI.Toggle( new Rect( 2.0f, ( x * 16.0f ) + 2.0f, 126.0f, 16.0f ), mr[ x ].enabled, mr[ x ].name );
            }
        }
	}

    // Update MeshRenderers List
    void UpdateMR()
    {
        mr = MeshRenderer.FindObjectsOfType( typeof( MeshRenderer ) ) as MeshRenderer[];
    }
}
