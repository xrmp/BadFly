using Game;
using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuUI;
        private bool isPaused = false;
        private IGameController gameController;

        private void Start()
        {
            gameController = FindObjectOfType<GameController>();

            if (gameController == null)
            {
                Debug.LogError("GameController not found! Make sure it's present in the scene.");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                    Resume();
                else
                    Pause();
            }
        }

        public void Resume()
        {
            gameController.UnpauseGame();
            pauseMenuUI.SetActive(false);
            isPaused = false;
        }

        public void Pause()
        {
            gameController.PauseGame();
            pauseMenuUI.SetActive(true);
            isPaused = true;
        }

        public void Restart()
        {
            gameController.RestartGame();
        }

        public void Quit()
        {
            gameController.QuitGame();
        }
    }
}
