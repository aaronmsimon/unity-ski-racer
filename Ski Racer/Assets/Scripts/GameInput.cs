using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField] private FloatVariable steerAngle;
    [SerializeField] private FloatVariable rotateSpeed;
    [SerializeField] private float maxRotAngle = 45;

    private PlayerControls playerControls;

    private void Awake() {
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    private void Update() {
        SetSteerInput();
    }

    public void SetSteerInput() {
        float steerInput = playerControls.Player.Steer.ReadValue<float>();
        steerAngle.Value = Mathf.Clamp(steerAngle.Value + steerInput * rotateSpeed.Value * Time.deltaTime,-maxRotAngle,maxRotAngle);
    }
}
