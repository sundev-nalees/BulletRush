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

        private void OnEnable()
        {
            Invoke("HideBullet", 2.0f);
        }
        private void OnDisable()
        {
            trail.Clear();
            CancelInvoke();
        }
        private void HideBullet()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            transform.Translate(transform.forward * (Time.deltaTime * 60f), Space.World);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == 3 ||collision.gameObject.layer==7)
            {

                var damageable = collision.gameObject.GetComponent<Idamagable>();
                damageable.TakeDamage();
                gameObject.SetActive(false);

            }
            if (collision.gameObject.layer != 8) return;
            gameObject.SetActive(false);

        }
    }
}
