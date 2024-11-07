using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    private const string LevelKey = "CurrentLevel";
    private const int DefaultStartLevel = 1;

    public static ProgressManager Instance { get; private set; }

    public int CurrentLevel { get; private set; } = DefaultStartLevel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadProgress();
    }

    public void LoadProgress()
    {
        CurrentLevel = PlayerPrefs.GetInt(LevelKey, DefaultStartLevel);
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt(LevelKey, CurrentLevel);
        PlayerPrefs.Save();
    }

    public void NextLevel()
    {
        CurrentLevel++;
        SaveProgress();
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }
}
