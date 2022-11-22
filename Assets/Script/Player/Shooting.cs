using System.Collections.Generic;
using UnityEngine;

namespace BulletRush
{
    public class Shooting : MonoBehaviour
    {
        
        private readonly List<GameObject> pooledBullets = new List<GameObject>();
        private const int BulletAmount = 100;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private AudioSource shootingSound;
        

        private void Start()
        {
            for(int i = 0; i < BulletAmount; i++)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                pooledBullets.Add(obj);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
                shootingSound.Play();
            }
            
        }
        private void Fire()
        {
            for(int i = 0; i < pooledBullets.Count; i++)
            {
                if (!pooledBullets[i].activeInHierarchy)
                {
                    pooledBullets[i].transform.position = transform.position;
                    pooledBullets[i].transform.rotation = transform.rotation;
                    pooledBullets[i].SetActive(true);
                    Rigidbody tempRigidBodyBullet = pooledBullets[i].GetComponent<Rigidbody>();
                    tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                    break;
                }
            }
            
        }

    }
}
