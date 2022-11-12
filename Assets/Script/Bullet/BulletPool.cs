using System.Collections.Generic;
using UnityEngine;

namespace BulletRush
{
    public class BulletPool : MonoBehaviour
    {
        public static BulletPool instance;
        private readonly List<GameObject> pooledBullets = new List<GameObject>();
        private const int BulletAmount = 100;
        [SerializeField] private GameObject bulletPrefab;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            for(var i = 0; i < BulletAmount; i++)
            {
                var obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                pooledBullets.Add(obj);
            }
        }

        public GameObject GetPooledBullet()
        {
            for(var i = 0; i < pooledBullets.Count; i++)
            {
                if (!pooledBullets[i].activeInHierarchy)
                {
                    return pooledBullets[i];
                }
            }
            return null;
        }
    }
}
