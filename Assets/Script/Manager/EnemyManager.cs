using UnityEngine;
namespace BulletRush
{
    public class EnemyManager : MonoBehaviour
    {
        public EnemyDataContainer data;
        public void DownScale(float downScaleAmount)
        {
            transform.localScale -= Vector3.one * downScaleAmount;
            transform.position += Vector3.down * downScaleAmount;

        }

        public void CallDeathParticle(GameObject deathParticlePrefab)
        {
            var particle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            particle.SetActive(true);
            Destroy(particle, 1f);
        }
    }
}
