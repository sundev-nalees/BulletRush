using UnityEngine;

namespace BulletRush
{
    public class LargeEnemy : EnemyManager,Idamagable
    {
        private int largeHealth;
        private ParticleSystem tParticleSystem;
        private float downScaleAmount = 0.02f;

        [SerializeField] Material material;
        [SerializeField] GameObject deathParticlePrefab;
        [SerializeField] AudioSource explosion;

        private void Awake()
        {
            material.color = Color.cyan;
        }

        private void OnEnable()
        {
            largeHealth = data.health;
            tParticleSystem = GetComponent<ParticleSystem>();
        }
        public void TakeDamage()
        {
            DownScale(downScaleAmount);
            material.color = Color.Lerp(material.color, new Color(0, 0.5f, 0), 0.08f);
            tParticleSystem.Play();
            largeHealth--;
            if (largeHealth > 0)
            {
                return;
            }
            CallDeathParticle(deathParticlePrefab);
            EventManager.Instance.InvokeOnEnemyDeath();
            explosion.Play();
            gameObject.SetActive(false);

        }
    }
}
