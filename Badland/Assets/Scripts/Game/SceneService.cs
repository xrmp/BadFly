using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public static class SceneService
    {
        public static void LoadScene(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
