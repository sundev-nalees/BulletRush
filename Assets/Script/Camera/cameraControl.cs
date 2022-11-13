using UnityEngine;

namespace BulletRush
{
    public class cameraControl : MonoBehaviour
    {
        private Vector3 offSet, targetPosition;
        [SerializeField] private Transform target;
        [SerializeField] private float smoothness;
        private Vector3 velocity = Vector3.zero;

        private void Awake()
        {
            offSet = transform.position - target.position;
        }
        private void LateUpdate()
        {
            targetPosition = target.position + offSet;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothness);
        }
    }
}
