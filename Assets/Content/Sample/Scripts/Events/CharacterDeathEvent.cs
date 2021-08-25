using Core.Events;
using UnityEngine;

namespace Sample.Events
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(Events) + "/" + nameof(CharacterDeathEvent))]
    public class CharacterDeathEvent : GameEvent
    {
        private CharacterBehaviour target = default;
        public CharacterBehaviour Target => target;

        public void Raise(CharacterBehaviour target)
        {
            this.target = target;
            base.Raise();
        }
    }
}
