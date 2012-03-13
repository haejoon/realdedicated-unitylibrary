using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RealDedicated_UnityEditorLibrary
{
    public class EditorRemoveParents : MonoBehaviour
    {

        [MenuItem("Real Dedicated Controls/RemoveParents %#g")]
        static void RemoveParents()
        {
            EditorRemoveParents.RemoveParentsOfSelectedObjects();
        }

        static void RemoveParentsOfSelectedObjects()
        {
            Undo.RegisterSceneUndo("Removed parents from objects");

            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.parent = null;

                Transform[] childrenOfObj = obj.transform.GetComponentsInChildren<Transform>();

                foreach (Transform child in childrenOfObj)
                {
                    child.parent = null;
                }
            }
        }
    }
}
