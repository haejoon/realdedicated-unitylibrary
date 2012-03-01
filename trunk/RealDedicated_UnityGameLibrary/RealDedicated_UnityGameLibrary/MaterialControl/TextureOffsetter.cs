using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class TextureOffsetter : MonoBehaviour
    {
        public float offsetSpeed = .1f;
        public string textureNameToPan = "_MainTex";
        public Vector2 offsetVector = Vector2.one;


        public void Update()
        {
            float offset = Time.time * this.offsetSpeed;
            Vector2 vectorToOffset = new Vector2(this.offsetVector.x * offset, this.offsetVector.y * offset);
            this.renderer.material.SetTextureOffset(this.textureNameToPan, vectorToOffset);
        }
    }
}
