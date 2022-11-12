using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BulletRush
{
    public class PlayerShooting : MonoBehaviour
    {
        private bool isShooting;
        private GameObject bullet,bullet2;
        private WaitForSeconds fireDelay;
        [SerializeField] private Transform rightHand;
        [SerializeField] private Transform leftHand;
        [SerializeField] private Transform currentEnemy,currentEnemy2;
        [SerializeField] private Transform lookAtEnemy;
        [SerializeField] ParticleSystem explosionParticle;
        [SerializeField] ParticleSystem circleParticle;

        public Collider[] colliders;
        public static readonly List<Transform> Enemies = new List<Transform>();


        private void Awake()
        {
            colliders = new Collider[500];
            fireDelay = new WaitForSeconds(0.09f);
            Shoot();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                circleParticle.transform.localScale += Vector3.one * (Time.deltaTime);  
            }
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }
            DestroyCircle();
            explosionParticle.Play();
            circleParticle.transform.localScale = default;
            
        }

        private void FixedUpdate()
        {
            if (!isShooting)
            {
                return;
            }
            lookAtEnemy = Enemies.FirstOrDefault();
            if (lookAtEnemy == null)
            {
                return;
            }
            transform.LookAt(new Vector3(lookAtEnemy.position.x, 0, lookAtEnemy.position.z));
            if (Enemies.Count == 0)
            {
                isShooting = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 3 || other.gameObject.layer != 7)
            {
                return;
            }
            if (!Enemies.Contains(other.transform))
            {
                Enemies.Add(other.transform);
            }

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer != 7) return;
            if (!Enemies.Contains(other.transform))
            {
                Enemies.Add(other.transform);
            }
        }


        private void Shoot()
        {
            StartCoroutine(ShootingCoroutine());
        }

        private IEnumerator ShootingCoroutine()
        {
            while (true)
            {
                if (Enemies.Count > 0)
                {

                    isShooting = true;
                    currentEnemy = Enemies.First();
                    currentEnemy2 = Enemies.Last();

                    bullet = BulletPool.instance.GetPooledBullet();

                    if (bullet != null)
                    {
                        bullet.transform.position = leftHand.position;
                        bullet.transform.LookAt(new Vector3(currentEnemy.position.x, 0, currentEnemy.position.z));
                        bullet.SetActive(true);
                    }
                    bullet2 = BulletPool.instance.GetPooledBullet();

                    if (bullet2 != null)
                    {
                        bullet2.transform.position = rightHand.position;
                        bullet2.transform.LookAt(new Vector3(currentEnemy2.position.x, 0, currentEnemy2.position.z));
                        bullet2.SetActive(true);
                    }
                    yield return fireDelay;
                }
            }
           
        }
        private void DestroyCircle()
        {

            var results = Physics.OverlapSphereNonAlloc(transform.position, circleParticle.transform.localScale.x, colliders, LayerMask.GetMask("Enemy"));
            for (var i = 0; i < results; i++)
            {
                colliders[i].gameObject.SetActive(false);
            }
        }

    }
}
