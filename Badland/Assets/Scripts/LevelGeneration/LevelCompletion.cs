using Game.Services;
using UnityEngine;

namespace Game.Level
{
    public class LevelCompletion : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ProgressManager.Instance.NextLevel();
            }
        }
    }
}