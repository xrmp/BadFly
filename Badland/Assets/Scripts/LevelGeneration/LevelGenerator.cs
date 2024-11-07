using UnityEngine;

namespace Game.Level
{
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
            float currentPosition = 0f;

            for (int i = 0; i < numFragments; i++)
            {
                currentPosition = GenerateLevelFragment(i, currentPosition);
            }

            Instantiate(finishPrefab, new Vector3(currentPosition, 0, 0), Quaternion.identity);
        }

        private float GenerateLevelFragment(int fragmentIndex, float currentPosition)
        {
            GameObject fragment = Instantiate(levelFragments[Random.Range(0, levelFragments.Length)]);
            float fragmentWidth = GetFragmentWidth(fragment);
            fragment.transform.position = new Vector3(currentPosition, 0, 0);

            return currentPosition + fragmentWidth;
        }

        private float GetFragmentWidth(GameObject fragment)
        {
            var collider = fragment.GetComponent<Collider2D>();
            return collider ? collider.bounds.size.x : 10f;
        }
    }
}
