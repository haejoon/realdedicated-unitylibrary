using UnityEngine;
using System.Collections;

public class AnimationDelayer : MonoBehaviour 
{
    [UnityEngine.SerializeField]
    private Vector2 startTime = new Vector2(0, 5);
    private float startTimeActual;

    private bool startedAnimation = false;

    private void Awake()
    {
        this.animation.playAutomatically = false;
        this.animation.Stop();

        this.PickStartTime();
    }

    private void PickStartTime()
    {
        float randomedStartTime = Random.Range(startTime.x, startTime.y);

        this.startTimeActual = Time.time + randomedStartTime;
    }

    private void Update()
    {
        if (!this.startedAnimation && Time.time >= this.startTimeActual)
        {
            this.animation.Play();
            this.startedAnimation = true;

            this.RemoveThisComponent();
        }
    }

    private void RemoveThisComponent()
    {
        Destroy(this);
    }
	
}
