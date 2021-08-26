using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Sample.Events;

namespace Sample
{
    [RequireComponent(typeof(CharacterBehaviour))]
    public class EnemyLogic : MonoBehaviour, IInitialize<CharacterBehaviour>
    {
        [SerializeField]
        private CharacterAttackEvent characterAttackEvent = default;
        private CharacterBehaviour targetEnemy = default;
        private CharacterBehaviour currentCharacter = default;

        [SerializeField]
        private float defaultAttackDelay = 1f;
        private float timer = default;

        private void Awake()
        {
            currentCharacter = GetComponent<CharacterBehaviour>();
        }

        public void Initialize(CharacterBehaviour targetEnemy)
        {
            this.targetEnemy = targetEnemy;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= defaultAttackDelay)
            {
                characterAttackEvent.Raise(currentCharacter, targetEnemy);
                timer = default;
            }
        }
    }
}
