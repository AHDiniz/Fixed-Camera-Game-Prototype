using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PPI.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float runSpeed = 7f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private Transform pivot = null;

        private Rigidbody physics;
        private Transform cameraTransform;
        private Vector3 forward, right;
        private Vector2 moveInput;
        private float rotAngle = 0f, rotAmount = 0f, currentSpeed = 0f;

        private void Start()
        {
            physics = GetComponent<Rigidbody>();
            cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");

            currentSpeed = Input.GetButton("Fire2") ? runSpeed : walkSpeed;
        }

        private void FixedUpdate()
        {
            if (moveInput == Vector2.zero)
            {
                right = cameraTransform.right;
                forward = cameraTransform.forward;
            }

            physics.velocity = currentSpeed * (moveInput.x * right + moveInput.y * forward).normalized;
            if (physics.velocity != Vector3.zero)
            {
                rotAngle = 2 * Mathf.PI * Time.fixedDeltaTime;
                rotAmount = rotationSpeed * Time.fixedDeltaTime;
                pivot.forward = Vector3.RotateTowards(pivot.forward, physics.velocity.normalized, rotAngle, rotAmount).normalized;
            }
        }
    }
}