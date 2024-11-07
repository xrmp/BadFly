using Game.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameController gameController;

        private void Start()
        {
            if (gameController == null)
            {
                gameController = FindObjectOfType<GameController>();
            }

            if (gameController == null)
            {
                Debug.LogError("GameController is missing in the scene!");
            }
        }

        public void StartGame()
        {
            ProgressManager.LoadProgress();
            SceneService.LoadScene(ProgressManager.CurrentLevel);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            ProgressManager.RestartLevel();
        }
    }
}
