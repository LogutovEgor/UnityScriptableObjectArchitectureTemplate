using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Sample
{
    public class LevelBehaviour : MonoBehaviour, IInitialize<LevelInfo>
    {
        [SerializeField]
        private Transform playerSpawn = default;
        [SerializeField]
        private Transform[] enemySpawns = default;

        private LevelInfo levelInfo = default;

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Initialize(LevelInfo levelInfo)
        {
            this.levelInfo = levelInfo;
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            GameObject playerCharacter = Instantiate(levelInfo.PlayerCharacter.CharacterPrefab.gameObject, transform);
            playerCharacter.transform.position = playerSpawn.transform.position;
        }
    }
}
