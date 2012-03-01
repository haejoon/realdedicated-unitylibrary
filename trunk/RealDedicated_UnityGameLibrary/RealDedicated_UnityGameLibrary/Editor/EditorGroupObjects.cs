using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class EditorGroupObjects : MonoBehaviour
    {
        [MenuItem("Real Dedicated Controls/GroupObjects %g")]
        static void GroupObjects()
        {
            EditorGroupObjects.GroupSelectedObjects();
        }

        static void GroupSelectedObjects()
        {
            Undo.RegisterSceneUndo("Grouped objects together");

            if (Selection.gameObjects.Length >= 1)
            {
                GameObject parentObject = new GameObject("Group - " + Selection.gameObjects[0].name);
                parentObject.transform.position = Selection.gameObjects[0].transform.position;
                parentObject.transform.rotation = Selection.gameObjects[0].transform.rotation;

                parentObject.transform.parent = Selection.gameObjects[0].transform.parent;

                foreach (GameObject obj in Selection.gameObjects)
                {
                    obj.transform.parent = parentObject.transform;
                }
            }
        }
    }
}
