using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace BulletRush
{
    public class EnemyManager : MonoBehaviour
    {
        public EnemyDataContainer data;
        [SerializeField] GameObject dropMoney;
        private float dropRate = 0.1f;
        private float dropChance;

        protected void DropMoneyOnDeath(float chance)
        {
            if (chance <= dropRate)
            {
                Instantiate(dropMoney, transform.position, Quaternion.Euler(-90, 0, -90));
            }
        }
    }
}
