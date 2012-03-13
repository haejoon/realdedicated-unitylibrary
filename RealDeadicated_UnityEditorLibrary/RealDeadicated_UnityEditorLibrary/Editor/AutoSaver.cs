using UnityEngine;
using UnityEditor;
using System;

namespace RealDedicated_UnityEditorLibrary
{
	public class AutoSaver : EditorWindow 
	{
	    private bool autoSaveScene = true;
	    private bool showMessage = true;
	    private bool isStarted = false;
	    private int intervalScene;  
	    private DateTime lastSaveTimeScene = DateTime.Now;
	    
	    private string projectPath = Application.dataPath;
	    private string scenePath;
	    
	    [MenuItem ("Window/AutoSave")]
	    static void Init () {
	        AutoSaver saveWindow = (AutoSaver)EditorWindow.GetWindow (typeof (AutoSaver));
	        saveWindow.Show();
	    }
	    
	    void OnGUI () { 
	        GUILayout.Label ("Info:", EditorStyles.boldLabel);
	        EditorGUILayout.LabelField ("Saving to:", ""+projectPath);
	        EditorGUILayout.LabelField ("Saving scene:", ""+scenePath);
	        GUILayout.Label ("Options:", EditorStyles.boldLabel);
	        autoSaveScene = EditorGUILayout.BeginToggleGroup ("Auto save", autoSaveScene);
	        intervalScene = EditorGUILayout.IntSlider ("Interval (minutes)", intervalScene, 1, 10);
	        if(isStarted) {
	            EditorGUILayout.LabelField ("Last save:", ""+lastSaveTimeScene);
	        }
	        EditorGUILayout.EndToggleGroup();
	        showMessage = EditorGUILayout.BeginToggleGroup ("Show Message", showMessage);
	        EditorGUILayout.EndToggleGroup ();
	    }
	    
	    
	    void Update(){
	        scenePath = EditorApplication.currentScene;
	        if(autoSaveScene) {
	            if(DateTime.Now.Minute >= (lastSaveTimeScene.Minute+intervalScene) || DateTime.Now.Minute == 59 && DateTime.Now.Second == 59){
	                saveScene();
	            }
	        } else {
	            isStarted = false;
	        }
	        
	    }
	    
	    void saveScene() {
	        EditorApplication.SaveScene(scenePath);
	        lastSaveTimeScene = DateTime.Now;
	        isStarted = true;
	        if(showMessage){
	            Debug.Log("AutoSave saved: "+scenePath+" on "+lastSaveTimeScene);
	        }
	        AutoSaver repaintSaveWindow = (AutoSaver)EditorWindow.GetWindow (typeof (AutoSaver));
	        repaintSaveWindow.Repaint();
	    }
	}
}