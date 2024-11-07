using UnityEngine;

namespace Game
{
    public interface IGameController
    {
        void PauseGame();
        void UnpauseGame();
        void RestartGame();
        void QuitGame();
    }

    public class GameController : MonoBehaviour, IGameController
    {
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1f;
        }

        public void RestartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
