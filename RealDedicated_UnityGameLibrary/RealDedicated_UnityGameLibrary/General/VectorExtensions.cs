using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public static class VectorExtensions
    {
        public static Vector2 random(this Vector2 vector2)
        {
            float randX = Random.Range(0, 1);
            float randY = Random.Range(0, 1);

            return new Vector2(randX, randY);
        }

        public static Vector2 random(this Vector2 vector2, float min, float max)
        {
            float randX = Random.Range(min, max);
            float randY = Random.Range(min, max);

            return new Vector2(randX, randY);
        }

        public static Vector3 random(this Vector3 vector3)
        {
            float randX = Random.Range(0, 1);
            float randY = Random.Range(0, 1);
            float randZ = Random.Range(0, 1);

            return new Vector3(randX, randY, randZ);
        }

        public static Vector3 random(this Vector3 vector3, float min, float max)
        {
            float randX = Random.Range(min, max);
            float randY = Random.Range(min, max);
            float randZ = Random.Range(min, max);

            return new Vector3(randX, randY, randZ);
        }


    }
}
