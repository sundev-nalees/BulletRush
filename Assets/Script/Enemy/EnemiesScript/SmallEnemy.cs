using UnityEngine;

namespace BulletRush
{
    public class SmallEnemy : EnemyManager,Idamagable
    {
        

        private int smallHealth;
        [SerializeField] GameObject deathParticlePrefab;
        private float smallDropChance;

        private void OnEnable()
        {
            smallHealth = data.health;      
        }
        public void TakeDamage()
        {
            --smallHealth;
            if (smallHealth <= 0)
            {
                smallDropChance = Random.value;
                DropMoneyOnDeath(smallDropChance);
                gameObject.SetActive(false);

            }
        }

        private void OnDisable()
        {
            var particle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            particle.SetActive(true);
            Destroy(particle, 1f);
        }
    }
}
