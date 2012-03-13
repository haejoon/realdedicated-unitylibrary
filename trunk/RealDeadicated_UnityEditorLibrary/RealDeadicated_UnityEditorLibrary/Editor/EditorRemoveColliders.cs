using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class EditorRemoveColliders : MonoBehaviour
    {
        [MenuItem("Real Dedicated Controls/Remove All Colliders/All Colliders")]
        static void RemoveAllCollider()
        {
            EditorRemoveColliders.RemoveCollidersOfType<Collider>();
        }

        [MenuItem("Real Dedicated Controls/Remove All Colliders/Box")]
        static void RemoveBoxCollider()
        {
            EditorRemoveColliders.RemoveCollidersOfType<BoxCollider>();
        }

        [MenuItem("Real Dedicated Controls/Remove All Colliders/Sphere")]
        static void RemoveSphereCollider()
        {
            EditorRemoveColliders.RemoveCollidersOfType<SphereCollider>();
        }

        [MenuItem("Real Dedicated Controls/Remove All Colliders/Mesh")]
        static void RemoveMeshCollider()
        {
            EditorRemoveColliders.RemoveCollidersOfType<MeshCollider>();
        }

        [MenuItem("Real Dedicated Controls/Remove All Colliders/Terrain")]
        static void RemoveTerrainCollider()
        {
            EditorRemoveColliders.RemoveCollidersOfType<TerrainCollider>();
        }

        static void RemoveCollidersOfType<T>() where T : Collider
        {
            Undo.RegisterSceneUndo("Removed colliders of type " + typeof(T).ToString());

            List<GameObject> objectToToggle = new List<GameObject>(Selection.gameObjects);
            foreach (GameObject obj in Selection.gameObjects)
            {
                foreach (T objectWithCollider in obj.GetComponentsInChildren<T>(true))
                {
                    objectToToggle.Add(objectWithCollider.gameObject);
                }
            }

            foreach (GameObject obj in objectToToggle)
            {
                if (obj.collider != null)
                {
                    DestroyImmediate(obj.collider);
                }
            }
        }
    }
}
