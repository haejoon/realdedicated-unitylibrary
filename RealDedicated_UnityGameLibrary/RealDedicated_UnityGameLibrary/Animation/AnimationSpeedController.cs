using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class AnimationSpeedController : MonoBehaviour
    {
        public float animationSpeed = 1;

        public bool usingRandomSpeed = false;
        public Vector2 randomSpeedRange = new Vector2(.5f, 3);

        private void Start()
        {
            if (this.animation.clip != null)
            {
                if (!this.usingRandomSpeed)
                    this.animation[this.animation.clip.name].speed = this.animationSpeed;
                else
                    this.animation[this.animation.clip.name].speed = Random.Range(randomSpeedRange.x, randomSpeedRange.y);

                this.RemoveThisComponent();
            }
        }

        private void RemoveThisComponent()
        {
            Destroy(this);
        }
    }
}
