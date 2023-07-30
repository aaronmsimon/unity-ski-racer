using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatVariable steerAngle;
    [SerializeField] private FloatVariable rotateSpeed;

    private Transform graphics;

    private void Awake() {
        graphics = transform.Find("Graphics");
    }

    private void Start() {
        steerAngle.Value = 0;
    }

    private void Update() {
        graphics.eulerAngles = Vector3.forward * steerAngle.Value;
    }
}
