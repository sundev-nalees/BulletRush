using UnityEngine;

namespace BulletRush
{
    public class MonoSingletonGeneric<T> : MonoBehaviour where T:MonoSingletonGeneric<T>
    {
        private static T instace;

        public static T Instance { get { return instace; } }

        protected virtual void Awake()
        {
            if (!instace)
            {
                instace = (T)this;
                DontDestroyOnLoad((T)this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
