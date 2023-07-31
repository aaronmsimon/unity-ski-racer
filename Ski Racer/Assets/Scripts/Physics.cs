using UnityEngine;

public class Physics : MonoBehaviour
{
    [SerializeField] private FloatVariable velocity;

    [SerializeField] private FloatVariable mass;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mountainSlope = 35f;
    // [SerializeField] private float dragCoefficient = 1.05f;
    [SerializeField] private float mu = .05f;

    private void Start() {
        velocity.Value = 0;
    }

    private void FixedUpdate() {
        float accX = CalculateAccX();
        float drag = CalculateDrag(velocity.Value);
        float acc = accX + drag;

        float distance = KinematicDisplacement(velocity.Value, Time.deltaTime, acc);
        transform.Translate(new Vector3(0f, distance, 0f));

        float velF = KinematicVelocity(velocity.Value, acc, Time.deltaTime);
        velocity.Value = velF;
    }

    private float CalculateAccX() {
        float rad = mountainSlope * Mathf.Deg2Rad;
        float accX = mass.Value * gravity * (Mathf.Sin(rad) - mu * Mathf.Cos(rad));
        return accX;
    }

    private float CalculateDrag(float velocity) {
        float C = .2f;
        float ro = 1.225f;
        float A = 1f;
        float drag = .5f * C * ro * A * velocity * velocity;
        return drag;
    }

    private float KinematicDisplacement(float u, float t, float a) {
        return (u * t) + (.5f * a * t * t);
    }
    
    private float KinematicVelocity(float u, float a, float t) {
        return u + a * t;
    }
}
