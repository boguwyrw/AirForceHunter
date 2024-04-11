using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace spacefighter
{
    public class SpaceFighterController : MonoBehaviour
    {
        [SerializeField] private Transform leftBoundaries;
        [SerializeField] private Transform rightBoundaries;
        [SerializeField] private Transform spaceFighter;

        private SpaceFighterControls spaceFighterControls;

        private Vector2 flyVector = Vector2.zero;

        private float flyDirection = 0.0f;
        private float flySpeed = 1.0f;
        private float turnSpeed = 10.0f;
        private float tilt = 30.0f;

        private void Awake()
        {
            spaceFighterControls = new SpaceFighterControls();
        }

        private void OnEnable()
        {
            spaceFighterControls.Enable();
            spaceFighterControls.SpaceFighter.Fly.performed += OnFlyPerformed;
            spaceFighterControls.SpaceFighter.Fly.canceled += OnFlyCanceled;
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

        }

        private void Update()
        {
            transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
            if (flyDirection == 1 && transform.position.x < rightBoundaries.position.x)
            {
                transform.Translate(transform.right * turnSpeed * Time.deltaTime);
                spaceFighter.rotation = Quaternion.Euler(0.0f, 0.0f, -flyDirection * tilt);
            }
            else if (flyDirection == -1 && transform.position.x > leftBoundaries.position.x)
            {
                transform.Translate(-transform.right * turnSpeed * Time.deltaTime);
                spaceFighter.rotation = Quaternion.Euler(0.0f, 0.0f, -flyDirection * tilt);
            }
            else
            {
                spaceFighter.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }

            if (spaceFighterControls.SpaceFighter.Fire.triggered)
            {
                Debug.Log("Strzelam");
            }
        }
    }
}

