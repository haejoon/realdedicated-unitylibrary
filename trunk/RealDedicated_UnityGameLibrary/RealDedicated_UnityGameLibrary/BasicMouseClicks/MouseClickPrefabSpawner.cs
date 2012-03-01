using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class MouseClickPrefabSpawner : MonoBehaviour
    {
        public GameObject prefabToSpawn;

        public void OnMouseDown()
        {
            this.SpawnPrefab();
        }

        private void SpawnPrefab()
        {
            if (this.prefabToSpawn != null)
                Instantiate(this.prefabToSpawn, this.transform.position, this.transform.rotation);
        }
    }
}
