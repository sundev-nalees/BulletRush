using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletRush
{
    public class PlayerShooting : MonoBehaviour
    {
        private bool isShooting;
        private GameObject bullet;
        private WaitForSeconds fireDelay;
        [SerializeField] private Transform gunPoint;


        private void Awake()
        {
            fireDelay = new WaitForSeconds(0.09f);
            Shoot();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                isShooting = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isShooting = false;
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
                
                bullet = BulletPool.instance.GetPooledBullet();

                if (bullet != null)
                {
                    bullet.transform.position = gunPoint.position;
                    bullet.SetActive(true);
                }
                yield return fireDelay;
            }
           
        }

    }
}
