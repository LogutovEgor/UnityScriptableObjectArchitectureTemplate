using UnityEngine;

namespace Core.UI
{
    public abstract class UISystem : ScriptableObject
    {
        public abstract void ShowUI(string name);
        public abstract void CloseTopUI();
    }
}
