using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class EditorMassAddColliders : MonoBehaviour
    {
        [MenuItem("Real Dedicated Controls/AddColliders/Mesh Colliders")]
        static void AddMeshColliders()
        {
            EditorMassAddColliders.AddCollidersOfType<MeshCollider>();
        }

        [MenuItem("Real Dedicated Controls/AddColliders/Box Colliders")]
        static void AddBoxColliders()
        {
            EditorMassAddColliders.AddCollidersOfType<BoxCollider>();
        }

        [MenuItem("Real Dedicated Controls/AddColliders/Sphere Colliders")]
        static void AddSphereColliders()
        {
            EditorMassAddColliders.AddCollidersOfType<SphereCollider>();
        }

        static void AddCollidersOfType<T>() where T : Collider
        {
            Undo.RegisterSceneUndo("Added colliders of type " + typeof(T).ToString());

            List<GameObject> objectsToAttachCollidersTo = new List<GameObject>(Selection.gameObjects);
            foreach (GameObject obj in Selection.gameObjects)
            {
                foreach (GameObject objectToAttach in objectsToAttachCollidersTo)
                {
                    Collider attachedCollider = objectToAttach.GetComponent<T>();
                    if (attachedCollider == null)
                    {
                        objectToAttach.AddComponent<T>();
                    }
                }
            }
        }
    }
}
