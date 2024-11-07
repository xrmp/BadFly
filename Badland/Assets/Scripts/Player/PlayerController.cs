using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float thrustForce = 10f;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotationSpeed = 100f;

        private Rigidbody2D rb2d;
        private bool isFlying = false;
        private bool isDead = false;

        [Header("Rotation Settings")]
        [SerializeField] private float maxRotationAngle = 90f;

        public event Action OnSpacePressed;
        public event Action OnSpaceReleased;
        public event Action OnHorizontalInput;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();

            OnSpacePressed += ThrustUp;
            OnSpaceReleased += StopThrust;
            OnHorizontalInput += MoveHorizontally;
        }

        private void OnDestroy()
        {
            OnSpacePressed -= ThrustUp;
            OnSpaceReleased -= StopThrust;
            OnHorizontalInput -= MoveHorizontally;
        }

        public void TriggerSpacePressed()
        {
            if (!isFlying)
                OnSpacePressed?.Invoke();
        }

        public void TriggerSpaceReleased()
        {
            if (isFlying)
                OnSpaceReleased?.Invoke();
        }

        public void TriggerHorizontalInput(float moveDirection)
        {
            if (isFlying)
                OnHorizontalInput?.Invoke();
        }

        private void ThrustUp()
        {
            isFlying = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, thrustForce);
        }

        private void StopThrust()
        {
            isFlying = false;
        }

        private void MoveHorizontally()
        {
            float moveDirection = Input.GetAxis("Horizontal"); // Используем ось для ввода
            rb2d.velocity = new Vector2(moveDirection * moveSpeed, rb2d.velocity.y);
        }

        private void HandleRotation()
        {
            if (isFlying)
            {
                float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;
                angle = Mathf.Clamp(angle, -maxRotationAngle, maxRotationAngle);
                rb2d.rotation = Mathf.LerpAngle(rb2d.rotation, angle, Time.deltaTime * rotationSpeed);
            }
            else
            {
                rb2d.rotation += rb2d.angularVelocity * Time.deltaTime;
            }
        }

        public void Die()
        {
            if (isDead) return;

            isDead = true;
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
            Debug.Log("Player has died!");

            ProgressManager.Instance.RestartLevel();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isDead) return;

            if (collision.gameObject.layer == LayerMask.NameToLayer("DeadlyObstacle"))
            {
                Die();
            }
        }
    }
}
