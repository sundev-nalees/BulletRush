using UnityEngine;

namespace BulletRush.Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float speed=60f;
        
        private const int EnemyLayer= 3;
        private const int ObstacleLayer = 6;
        private Rigidbody rigidBody;
        private TrailRenderer trail;
        
        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            trail = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            Invoke("HideBullet", 2.0f);
        }

        private void HideBullet()
        {
            trail.Clear();
            CancelInvoke();
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer== EnemyLayer)
            {
                Idamagable damageable = collision.gameObject.GetComponent<Idamagable>();
                damageable.TakeDamage();
                gameObject.SetActive(false);
            }
            else if (collision.gameObject.layer != ObstacleLayer)
            {
                return;
            }
            gameObject.SetActive(false);
        }
    }
}
