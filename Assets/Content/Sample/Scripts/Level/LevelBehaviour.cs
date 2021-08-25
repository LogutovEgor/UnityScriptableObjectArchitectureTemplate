using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System.Linq;
using Sample.Events;

namespace Sample
{
    public class LevelBehaviour : MonoBehaviour, IInitialize<LevelInfo>
    {
        [SerializeField]
        private Transform playerSpawn = default;
        private CharacterBehaviour player = default;
        [SerializeField]
        private Transform[] enemySpawns = default;
        private List<(Transform, CharacterBehaviour)> enemies = new List<(Transform, CharacterBehaviour)>();

        private LevelInfo levelInfo = default;
        public LevelInfo LevelInfo => levelInfo;

        private int enemiesDefeatedNumber = default;
        public int EnemiesDefeatedNumber => enemiesDefeatedNumber;

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Initialize(LevelInfo levelInfo)
        {
            this.levelInfo = levelInfo;
            SpawnPlayer();
            SpawnEnemy();
        }



        private void SpawnPlayer() => player = SpawnCharacter(playerSpawn, levelInfo.PlayerCharacter);

        private void SpawnEnemy()
        {
            if (!EnemySpawningPossible)
                return;

            Transform spawn = GetRandomEmptySpawn();
            ICharacter characterInfo = GetRandomEnemyCloneInfo();

            CharacterBehaviour character = SpawnCharacter(spawn, characterInfo);
            enemies.Add((spawn, character));
        }

        private CharacterBehaviour SpawnCharacter(Transform spawn, ICharacter characterInfo)
        {
            CharacterBehaviour character = Instantiate(characterInfo.CharacterPrefab.gameObject, transform).GetComponent<CharacterBehaviour>();
            character.Initialize(characterInfo);
            character.transform.position = spawn.transform.position;
            return character;
        }

        private bool EnemySpawningPossible => enemies.Count < enemySpawns.Length;

        private Transform GetRandomEmptySpawn()
        {
            Transform[] emptySpawns = enemySpawns
                .Except(enemies.Select(elem => elem.Item1))
                .ToArray();

            if (emptySpawns.Length == 0)
                throw new System.Exception($"Can not find empty spawn from {nameof(enemySpawns)}");

            int randomIndex = Random.Range(0, emptySpawns.Length);
            return emptySpawns[randomIndex];
        }

        private ICharacter GetRandomEnemyCloneInfo()
        {
            if (levelInfo.PossibleEnemies.Length == 0)
                throw new System.Exception($"Empty {levelInfo.PossibleEnemies} array.");

            int randomIndex = Random.Range(0, levelInfo.PossibleEnemies.Length);
            return levelInfo.PossibleEnemies[randomIndex].Clone();
        }

        public void CharacterDeathEventResponse(CharacterDeathEvent characterDeathEvent)
        {
            if (characterDeathEvent.Target != player)
            {
                for (int i = 0; i < enemies.Count; i++)
                    if (enemies[i].Item2 == characterDeathEvent.Target)
                    {
                        enemies.RemoveAt(i);
                        break;
                    }
                enemiesDefeatedNumber++;
                if (enemiesDefeatedNumber < levelInfo.EnemiesQuantity)
                    SpawnEnemy();
            }
        }
    }
}
