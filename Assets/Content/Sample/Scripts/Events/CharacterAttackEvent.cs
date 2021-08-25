using Core.Events;
using UnityEngine;

namespace Sample.Events
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(Events) + "/" + nameof(CharacterAttackEvent))]
    public class CharacterAttackEvent : GameEvent
    {
        private CharacterBehaviour attacker = default;
        public CharacterBehaviour Attacker => attacker;

        private CharacterBehaviour target = default;
        public CharacterBehaviour Target => target;

        public void Raise(CharacterBehaviour attacker, CharacterBehaviour target)
        {
            this.attacker = attacker;
            this.target = target;
            base.Raise();
        }
    }
}
