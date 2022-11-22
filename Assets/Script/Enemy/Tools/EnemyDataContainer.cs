using UnityEngine;

namespace BulletRush
{
    public enum EnemyType
    {
       None,
       Small,
       Large
    }

    [CreateAssetMenu(fileName ="EnemyData",menuName ="Enemy Data")]
    public class EnemyDataContainer : ScriptableObject
    {
        public EnemyType type;
        public int health;
        public Material material;
    }
}
