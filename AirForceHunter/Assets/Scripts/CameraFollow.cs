using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spacefighter
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform spaceFighter;

        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - spaceFighter.position;
        }

        private void LateUpdate()
        {
            transform.position = spaceFighter.position + offset;
        }
    }
}

