using UnityEngine;
using UnityEngine.Events;

namespace Sample
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onAwakeEvent = default;

        private void Awake() => onAwakeEvent.Invoke();
    }
}
