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
            if (this.animation != null)
            {
                this.SetSpeedOfClips();
            }

            this.RemoveThisComponent();
        }

        private void SetSpeedOfClips()
        {
            foreach (AnimationState state in animation)
            {
                if (this.usingRandomSpeed)
                    this.SetSpeedActual(state, this.GetRandomSpeed());
                else
                    this.SetSpeedActual(state, this.animationSpeed);
            }
        }

        private void SetSpeedActual(AnimationState clipToSet, float speedToUse)
        {
            clipToSet.speed = speedToUse;
        }

        private float GetRandomSpeed()
        {
            return Random.Range(randomSpeedRange.x, randomSpeedRange.y);
        }

        private void RemoveThisComponent()
        {
            Destroy(this);
        }
    }
}
