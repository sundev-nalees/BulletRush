using System;


namespace BulletRush
{
    public class EventManager : MonoSingletonGeneric<EventManager>
    {
        public event Action OnEnemyDeath;
        public event Action OnGameOver;

        public void InvokeOnGameOver()
        {
            OnGameOver?.Invoke();
        }

        public void InvokeOnEnemyDeath()
        {
            OnEnemyDeath?.Invoke();
        }
    }
}
