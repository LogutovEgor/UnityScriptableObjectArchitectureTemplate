using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(LevelSystem))]
    public class LevelSystem : ScriptableObject
    {
        private LevelBehaviour currentLevel = null;

        public void CreateLevel(LevelInfo levelInfo)
        {
            if (currentLevel != null)
                currentLevel.Destroy();

            currentLevel = Instantiate(levelInfo.LevelPrefab.gameObject).GetComponent<LevelBehaviour>();
            currentLevel.Initialize(levelInfo);
        }

        public int GetCurrentLevelRemainingEnemiesCount() => currentLevel.LevelInfo.EnemiesQuantity - currentLevel.EnemiesDefeatedNumber;
    }
}
