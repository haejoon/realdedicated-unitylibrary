using UnityEngine;
using System.Collections;

public class AnimationSpeedController : MonoBehaviour 
{
    public float animationSpeed = 1;

    public bool randomSpeed = false;
    public Vector2 randomSpeedRange = new Vector2(.5f, 3);

    private void Start()
    {
        if (this.animation.clip != null)
        {
            if (!this.randomSpeed)
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
