using UnityEngine;

public class Physics : MonoBehaviour
{
    [SerializeField] private FloatVariable velocity;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mountainSlope = 35f;

    private float accX;

    private void Start() {
        velocity.Value = 0;
    }

    private void Update() {
        CalculateAccX();
        float distance = KinematicDisplacement(velocity.Value, Time.deltaTime, accX);

        transform.Translate(new Vector3(0f, distance, 0f));

        float velF = KinematicVelocity(velocity.Value, accX, Time.deltaTime);
        velocity.Value = velF;
    }

    private void CalculateAccX() {
        float rad = mountainSlope * Mathf.Deg2Rad;
        accX = gravity * Mathf.Sin(rad);
    }

    private float KinematicDisplacement(float u, float t, float a) {
        return (u * t) + (.5f * a * t * t);
    }
    
    private float KinematicVelocity(float u, float a, float t) {
        return u + a * t;
    }
}
