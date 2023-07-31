using UnityEngine;
using TMPro;

namespace SkiRacer.UI
{
    public class Velocity : MonoBehaviour
    {
        [SerializeField] private FloatVariable velocity;

        private TMP_Text vel;

        private void Awake() {
            vel = GetComponent<TMP_Text>();
        }

        private void Update() {
            vel.text = "Velocity: " + Mathf.Round(velocity.Value) * -1 + " m/s";
        }
    }
}