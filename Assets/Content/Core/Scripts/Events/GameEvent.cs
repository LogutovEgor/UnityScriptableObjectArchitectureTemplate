using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    [CreateAssetMenu(menuName = nameof(Core) + "/" + nameof(Events) + "/" + nameof(GameEvent))]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IEventListener> eventListeners = new List<IEventListener>();

        public void Raise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                if (eventListeners.Count == 0)
                    Debug.Log("Event listners count = 0.");
                else
                    eventListeners[i].OnEventRaised();
        }


        public void RegisterListener(IEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(IEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
