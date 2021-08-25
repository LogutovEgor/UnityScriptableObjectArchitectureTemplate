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

        private void OnEnable()
        {
            if (gameEvent == null)
                throw new System.NullReferenceException($"GameEventListener on {this.gameObject.name} Event ref is null");
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            if (response != default)
                response.Invoke();
        }
    }
}
