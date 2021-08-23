using UnityEngine;

namespace Core.UI
{
    public abstract class Page : MonoBehaviour, IInitialize<UISystem>
    {
        protected UISystem UISystem = default;

        public void Initialize(UISystem param1)
        {
            UISystem = param1;
        }

        public abstract void Hide();
        public abstract void Show();
        public abstract void Destroy();
    }
}
