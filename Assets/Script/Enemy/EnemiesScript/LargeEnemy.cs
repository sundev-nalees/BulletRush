using UnityEngine;
using System.Collections.Generic;

namespace BulletRush
{
    public class LargeEnemy : EnemyManager, Idamagable
    {
        private int largeHealth;
        private ParticleSystem tParticleSystem;

        [SerializeField] Material material;
        [SerializeField] GameObject deathParticlePrefab;

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
            DownScale();
            material.color = Color.Lerp(material.color, new Color(0, 0.5f, 0), 0.008f);
            tParticleSystem.Play();
            largeHealth--;
            if (largeHealth > 0)
            {
                return;
            }
            CallDeathParticle();
            EventManager.Instance.InvokeOnEnemyDeath();
            gameObject.SetActive(false);
        }

        private void DownScale()
        {
            transform.localScale -= Vector3.one * 0.02f;
            transform.position += Vector3.down * 0.02f;

        }

        private void CallDeathParticle()
        {
            var particle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            particle.SetActive(true);
            Destroy(particle, 1f);

        }
    }
}
