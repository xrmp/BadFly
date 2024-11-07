using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] levelFragments;
    [SerializeField] private GameObject finishPrefab;
    [SerializeField] private int initialLevelLength = 5;

    private int currentLevel;

    private void Start()
    {
        currentLevel = ProgressManager.Instance.CurrentLevel;

        GenerateLevel(currentLevel);
    }

    public void GenerateLevel(int levelIndex)
    {
        int numFragments = initialLevelLength + levelIndex;

        for (int i = 0; i < numFragments; i++)
        {
            GenerateLevelFragment(i);
        }

        Instantiate(finishPrefab, new Vector3(numFragments * 10, 0, 0), Quaternion.identity);
    }

    private void GenerateLevelFragment(int fragmentIndex)
    {
        GameObject fragment = Instantiate(levelFragments[Random.Range(0, levelFragments.Length)]);
        fragment.transform.position = new Vector3(fragmentIndex * 10, 0, 0);
    }
}
