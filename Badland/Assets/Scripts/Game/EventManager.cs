using System;

namespace Game.Events
{
    public static class EventManager
    {
        public delegate void PlayerDeathHandler();
        public static event PlayerDeathHandler OnPlayerDeath;

        public static void TriggerPlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
