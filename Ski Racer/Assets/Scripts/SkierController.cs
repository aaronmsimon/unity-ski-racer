using UnityEngine;

public class SkierController : MonoBehaviour
{
    public float mass = 70f; // Mass of the skier in kilograms
    public float dragCoefficient = 0.2f; // Drag coefficient
    public float frontalArea = 1f; // Frontal area in square meters
    public float skiSpeed = 0f; // Initial speed of the skier
    private float gravity = 9.81f; // Acceleration due to gravity in m/s^2
    private float airDensity = 1.225f; // Air density in kg/m^3

    private Vector3 velocity;
    [SerializeField] private FloatVariable velSO;

    private void Start()
    {
        velocity = transform.forward * skiSpeed; // Initial ski speed
    }

    private void Update()
    {
        // Calculate air resistance force
        float airResistanceMagnitude = 0.5f * airDensity * frontalArea * dragCoefficient * velocity.sqrMagnitude;
        Vector3 airResistanceForce = -velocity.normalized * airResistanceMagnitude;

        // Calculate gravity force
        Vector3 gravityForce = Vector3.down * mass * gravity;

        // Calculate acceleration based on forces
        Vector3 acceleration = (gravityForce + airResistanceForce) / mass;

        // Integrate velocity and update position
        velocity += acceleration * Time.deltaTime;
        velSO.Value = velocity.y;
        Vector3 positionChange = velocity * Time.deltaTime;
        transform.position += positionChange;
    }
}
