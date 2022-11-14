using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletRush
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private Vector3 spawnValues;
        [SerializeField] private float spawnWait;
        [SerializeField] private float spawnMostWait;
        [SerializeField] private float spawnLeastWait;
        [SerializeField] private int startWait;
        [SerializeField] private int totalEnemies;
        [SerializeField] private bool stop;

        int randEnemy;
        int count;
        private void Start()
        {
            stop = false;
            count = 0;
            StartCoroutine(WaitSpawner());
        }

        private void update()
        {
            
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);   
        }

        IEnumerator WaitSpawner()
        {
            yield return new WaitForSeconds(startWait);
            if (totalEnemies <= count)
            {
                stop = true;
            }
            while (!stop)
            {
                randEnemy = Random.Range(0, 2);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
                Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                count++;
                yield return new WaitForSeconds(spawnWait);
            }
        }

    }
}
