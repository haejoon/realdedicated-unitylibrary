using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RealDedicated_UnityEditorLibrary
{
    public class EditorZeroObjects : MonoBehaviour
    {
        [MenuItem("Real Dedicated Controls/ZeroObjectsRotation %j")]
        static void ZeroObjectsRotation()
        {
            EditorZeroObjects.ZeroSelectedObjectsRotation();
        }

        [MenuItem("Real Dedicated Controls/ZeroObjectsPosition %h")]
        static void ZeroObjectsPosition()
        {
            EditorZeroObjects.ZeroSelectedObjectsPosition();
        }

        static void ZeroSelectedObjectsPosition()
        {
            Undo.RegisterSceneUndo("Zero'd selected objects position");

            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.localPosition = Vector3.zero;
            }
        }

        static void ZeroSelectedObjectsRotation()
        {
            Undo.RegisterSceneUndo("Zero'd selected objects rotation");

            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
