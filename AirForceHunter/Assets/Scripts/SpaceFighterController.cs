using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace spacefighter
{
    public class SpaceFighterController : MonoBehaviour
    {
        [SerializeField] private Transform spaceFighter;

        private SpaceFighterControls spaceFighterControls;

        private Vector2 flyVector = Vector2.zero;

        private float flyDirection = 0.0f;
        private float flySpeed = 1.0f;
        private float turnSpeed = 10.0f;
        private float tilt = 25.0f;

        private void Awake()
        {
            spaceFighterControls = new SpaceFighterControls();
        }

        private void OnEnable()
        {
            spaceFighterControls.Enable();
        }

        private void OnDisable()
        {
            spaceFighterControls.Disable();
            spaceFighterControls.SpaceFighter.Fly.performed -= OnFlyPerformed;
            spaceFighterControls.SpaceFighter.Fly.canceled -= OnFlyCanceled;
        }

        private void OnFlyPerformed(InputAction.CallbackContext context)
        {
            flyVector = context.ReadValue<Vector2>();
            flyDirection = flyVector.x;
        }

        private void OnFlyCanceled(InputAction.CallbackContext context)
        {
            flyVector = Vector2.zero;
            flyDirection = 0.0f;
        }

        private void Start()
        {
            spaceFighterControls.SpaceFighter.Fly.performed += OnFlyPerformed;
            spaceFighterControls.SpaceFighter.Fly.canceled += OnFlyCanceled;
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
            if (flyDirection == 1)
            {
                SpaceFighterTurn(transform.right);
                SpaceFighterRotation(-flyDirection * tilt);
            }
            else if (flyDirection == -1)
            {
                SpaceFighterTurn(-transform.right);
                SpaceFighterRotation(-flyDirection * tilt);
            }
            else
            {
                SpaceFighterRotation(0.0f);
            }

            if (spaceFighterControls.SpaceFighter.Fire.triggered)
            {
                Debug.Log("Strzelam");
            }
        }

        private void SpaceFighterTurn(Vector3 turnDirection)
        {
            transform.Translate(turnDirection * turnSpeed * Time.deltaTime);
        }

        private void SpaceFighterRotation(float fighterTilt)
        {
            spaceFighter.rotation = Quaternion.Euler(0.0f, 0.0f, fighterTilt);
        }
    }
}

