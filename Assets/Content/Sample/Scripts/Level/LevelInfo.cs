using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(LevelInfo))]
    public class LevelInfo : ScriptableObject
    {
        [SerializeField]
        private int enemiesQuantity = default;
        public int EnemiesQuantity => enemiesQuantity;

        [SerializeField]
        private LevelBehaviour levelPrefab = default;
        public LevelBehaviour LevelPrefab => levelPrefab;

        [SerializeField]
        private PlayerCharacter playerCharacter = default;
        public PlayerCharacter PlayerCharacter => playerCharacter;
        
        [SerializeField]
        private EnemyCharacter[] possibleEnemies = default;
        public EnemyCharacter[] PossibleEnemies => possibleEnemies;

        
    }
}
