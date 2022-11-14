using UnityEngine;

namespace BulletRush
{
    public class SmallEnemy : EnemyManager,Idamagable
    {
        

        private int smallHealth;
        [SerializeField] GameObject deathParticlePrefab;
        

        private void OnEnable()
        {
            smallHealth = data.health;      
        }
        public void TakeDamage()
        {
            --smallHealth;
            if (smallHealth <= 0)
            {
                
                CallDeathParticle();
                EventManager.Instance.InvokeOnEnemyDeath();
                gameObject.SetActive(false);

            }
        }

        private void CallDeathParticle()
        {
            var particle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            particle.SetActive(true);
            Destroy(particle, 1f);
        }
    }
}
