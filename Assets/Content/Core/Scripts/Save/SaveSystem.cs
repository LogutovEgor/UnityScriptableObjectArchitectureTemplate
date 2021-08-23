using UnityEngine;

namespace Core.Save
{
    public abstract class SaveSystem : ScriptableObject
    {
        public abstract int Coins { get; set; }
        public abstract int Crystals { get; set; }

        public abstract T GetValue<T>(string id);
        public abstract void SetValue<T>(string id, T value);
    }
}
