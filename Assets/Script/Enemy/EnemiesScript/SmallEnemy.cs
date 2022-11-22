using UnityEngine;

namespace BulletRush
{
    public class SmallEnemy : EnemyManager,Idamagable
    {
        private int smallHealth;
        [SerializeField] GameObject deathParticlePrefab;
        [SerializeField] AudioSource explosion;
        
        private void OnEnable()
        {
            smallHealth = data.health;      
        }

        public void TakeDamage()
        {
            --smallHealth;
            if (smallHealth <= 0)
            {
                CallDeathParticle(deathParticlePrefab);
                EventManager.Instance.InvokeOnEnemyDeath();
                explosion.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
