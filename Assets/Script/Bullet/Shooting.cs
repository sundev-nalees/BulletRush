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

        

        private void Start()
        {
            for(var i = 0; i < BulletAmount; i++)
            {
                var obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                pooledBullets.Add(obj);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
            
        }
        public void Fire()
        {
            for(var i = 0; i < pooledBullets.Count; i++)
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
