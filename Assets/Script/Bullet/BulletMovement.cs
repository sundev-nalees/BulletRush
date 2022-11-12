using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletRush
{
    public class BulletMovement : MonoBehaviour
    {
        private Rigidbody rb;
        private TrailRenderer trail;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            trail = GetComponent<TrailRenderer>();
        }

        private void OnDisable()
        {
            trail.Clear();
        }

        private void Update()
        {
            transform.Translate(transform.forward * (Time.deltaTime * 60f), Space.World);
        }

        private void OnTriggerEnter(Collider collision)
        {
            gameObject.SetActive(false);
        }
    }
}
