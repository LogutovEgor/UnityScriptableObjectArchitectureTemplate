using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(LevelSystem))]
    public class LevelSystem : ScriptableObject
    {
        [SerializeField]
        private LevelInfo[] levelInfos = default;

        private LevelBehaviour currentLevel = null;
        private bool lastLevelResult = default;
        public bool LastLevelResult => lastLevelResult;
        [SerializeField]
        private int currentLevelIndex = -1;

        public void OnEnable()
        {
            currentLevelIndex = -1;
        }

        public void CreateNextLevel()
        {
            currentLevelIndex++;
            if (currentLevelIndex >= levelInfos.Length)
                return;

            CreateLevel(levelInfos[currentLevelIndex]);
        }

        public void CreateLevel(LevelInfo levelInfo)
        {
            if (currentLevel != null)
                currentLevel.Destroy();

            currentLevel = Instantiate(levelInfo.LevelPrefab.gameObject).GetComponent<LevelBehaviour>();
            currentLevel.Initialize(levelInfo);
        }

        public void DestroyCurrentLevel() => currentLevel.Destroy();
        public void ResetCurrentLevelIndex() => currentLevelIndex = -1;

        public int GetCurrentLevelRemainingEnemiesCount() => currentLevel.LevelInfo.EnemiesQuantity - currentLevel.EnemiesDefeatedNumber;
        public string GetCurrentLevelDisplayName() => currentLevel.LevelInfo.DisplayName;
        public void SetLastLevelResult(bool value) => lastLevelResult = value;
        public bool NextLevelExists => currentLevelIndex + 1 < levelInfos.Length;
    }
}
