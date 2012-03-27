using UnityEngine;


namespace RealDedicated_UnityGameLibrary.Player
{

    [RequireComponent(typeof(Rigidbody))]
    class FreeMovementMotor : MovementMotor
    {

        //public var movement : MoveController;
        public float walkingSpeed = 5.0f;
        public float walkingSnappyness = 50.0f;
        public float turningSmoothing = 0.3f;

        private Rigidbody rigidbody;
        private Transform transform;
        void Awake()
        {

        }

        void FixedUpdate()
        {
            // Handle the movement of the character
            Vector3 targetVelocity = movementDirection * walkingSpeed;
            Vector3 deltaVelocity = targetVelocity - this.rigidbody.velocity;
            if (rigidbody.useGravity)
            {
                deltaVelocity.y = 0;
            }
            rigidbody.AddForce(deltaVelocity * walkingSnappyness, ForceMode.Acceleration);

            // Setup player to face facingDirection, or if that is zero, then the movementDirection
            Vector3 faceDir = facingDirection;
            if (faceDir == Vector3.zero)
            {
                faceDir = movementDirection;
            }

            // Make the character rotate towards the target rotation
            if (faceDir == Vector3.zero)
            {
                rigidbody.angularVelocity = Vector3.zero;
            }
            else
            {
                float rotationAngle = AngleAroundAxis(transform.forward, faceDir, Vector3.up);
                rigidbody.angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
            }
        }

        // The angle between dirA and dirB around axis
        public static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
        {
            // Project A and B onto the plane orthogonal target axis
            dirA = dirA - Vector3.Project(dirA, axis);
            dirB = dirB - Vector3.Project(dirB, axis);

            // Find (positive) angle between A and B
            float angle = Vector3.Angle(dirA, dirB);

            // Return angle multiplied with 1 or -1
            return (angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1));
        }
    }
}
