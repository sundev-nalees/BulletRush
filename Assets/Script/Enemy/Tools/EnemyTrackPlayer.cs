using UnityEngine;

namespace BulletRush
{
    public class EnemyTrackPlayer : MonoBehaviour
    {
        [SerializeField] private Transform playerPos;
        [SerializeField] private float speedConstant=150f;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            TrackPlayer();
        }

        private void TrackPlayer()
        {
            transform.LookAt(new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z));
            rb.velocity = transform.forward * (Time.fixedDeltaTime * speedConstant);
        }
    }
}
