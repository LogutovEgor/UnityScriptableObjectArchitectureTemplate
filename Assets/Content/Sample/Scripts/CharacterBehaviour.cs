using UnityEngine;
using Core;
using Sample.Events;

namespace Sample
{
    [RequireComponent(typeof(Animator))]
    public class CharacterBehaviour : MonoBehaviour, IInitialize<ICharacter>
    {
        [SerializeField]
        private CharacterDeathEvent characterDeathEvent = default;
        [SerializeField]
        private CharacterReceivedDamageEvent characterReceivedDamageEvent = default;
        [SerializeField]
        private string damagedAnimName = default;
        [SerializeField]
        private string deathAnimName = default;

        private Animator animator = default;
        private ICharacter character = default;
        public ICharacter Character => character;

        public void Initialize(ICharacter character)
        {
            this.character = character;
        }

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void CharacterAttackEventResponse(CharacterAttackEvent characterAttackEvent)
        {
            if (characterAttackEvent.Target == this && character.HealthPoints > 0)
            {
                character.HealthPoints -= (int)characterAttackEvent.Attacker.character.DamagePoints;
                characterReceivedDamageEvent.Raise(this);
                if (character.HealthPoints > 0)
                {
                    animator.Play(damagedAnimName);
                }
                else
                {
                    characterDeathEvent.Raise(this);
                    animator.Play(deathAnimName);
                }
            }
        }

        public void OnDeathAnimEnd() => Destroy(gameObject);
    }
}
