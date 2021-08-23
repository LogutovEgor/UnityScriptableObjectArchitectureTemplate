using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class GameEventListener : MonoBehaviour, IEventListener
    {
        [Tooltip(nameof(GameEvent) + " to register with.")]
        [SerializeField]
        private GameEvent gameEvent = default;

        [Tooltip("Response to invoke when " + nameof(GameEvent) + " is raised.")]
        [SerializeField]
        private UnityEvent response = default;

        public void OnEventRaised()
        {
            if (gameEvent == null)
                throw new System.NullReferenceException($"{nameof(GameEventListener)} on {gameObject.name} {nameof(GameEvent)} ref is null");
            gameEvent.RegisterListener(this);
        }
    }
}
